using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _20210125_Socket
{
    public class ClassSocket
    {
        //Flag
        public static bool m_bServerStartFlag = false; //Start/close server
        
        //Server
        public static Socket socketServer;

        //clients
        public static ConcurrentDictionary<string, Socket> ClientList = new ConcurrentDictionary<string, Socket>(); //Store socket 
        public static ConcurrentDictionary<string, List<string>> ClientMessages = new ConcurrentDictionary<string, List<string>>(); //store message

        //Thread
        static Thread tListen;  //Listen request
        static Thread tKeep;  //Keep client alive

        public static bool StartServer(string IP,int Port)
        {
            //Init socket
            socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //Get IP
            string sIP = IP;
            int iPort = Port;
            //Enable flag
            m_bServerStartFlag = true;

            //Open port
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(sIP), iPort);  //Get endpoints
                socketServer.Bind(endPoint);//Bind port
                socketServer.Listen(3333);//Start to listen

                //Listen thread
                tListen = new Thread(ProcessListen);
                tListen.IsBackground = true;
                tListen.Start();

                //Keep alive thread
                tKeep = new Thread(ProcessKeep);
                tKeep.IsBackground = true;
                tKeep.Start();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Method:ServerStart\r\n" + e.Message);
                return false;
            }

            //Pass all steps
            return true;
        }

        public static void ProcessListen()
        {
            while (m_bServerStartFlag)
            {
                try
                {
                    Socket socketClient = socketServer.Accept(); //Get client socket
                    socketClient.Send(Encoding.UTF8.GetBytes("Server connected."));

                    //Start receiving data
                    Thread tReceive = new Thread(ProcessReceive);   //Use thread instead, faster than task
                    tReceive.IsBackground = true;
                    tReceive.Start(socketClient);

                    //Start sending thread
                    Thread tSend = new Thread(ProcessSend);   //Use thread instead, faster than task
                    tSend.IsBackground = true;
                    tSend.Start(socketClient);

                }
                catch (Exception e)
                {
                    Debug.WriteLine("Method:ServerStart\r\n" + e.Message);
                    //return false; //Don't return to jump out loop in any case
                }
            }
        }

        private static void ProcessKeep()
        {
            //Init  variables
            string sRemote = "";

            while (m_bServerStartFlag)
            {
                Thread.Sleep(1000);
                try
                {
                    foreach (var item in ClientList)
                    {
                        //Get socket info
                        sRemote = item.Key;

                        //Add keep alive message
                        if (ClientMessages[sRemote].Count<1)
                        {
                            ClientMessages[sRemote].Add("ping");
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Method:ProcessKeep\r\n"+e.Message);
                }
            }
        }

        private static void ProcessReceive(object theSocket)
        {
            //Init variables
            Socket socketClient; //socket
            string sRemote; //Remote end point
            byte[] buffer = new byte[4096];//buffer to store data, UTF8=Size/2 maximum

            //Get socket
            try
            {
                socketClient = (Socket)theSocket; //Get the socket
                sRemote = socketClient.RemoteEndPoint.ToString();
                //Update the socket pool
                //If not exist just add, if exist change value to "clientSocket"
                ClientList.AddOrUpdate(sRemote, socketClient, (key, value) => socketClient);
            }
            catch (Exception e1)
            {
                Debug.WriteLine("Method:ProcessReceive.\r\n" + e1.Message);
                return;
            }

            //Receive data
            while (true)
            {
                try
                {
                    int iCount = socketClient.Receive(buffer);
                    string sResult = Encoding.UTF8.GetString(buffer, 0, iCount); //Get data
                    string[] sData = ParsingData(sResult); //parsing data

                    //Read data
                    for (int i = 0; i < sData.Length; i++)
                    {
                        Debug.WriteLine("Received message from:" + sRemote + "\r\n" + sResult);
                    }
                }
                catch (Exception)
                {
                    //Receive error, disconnect
                    CloseSocket(socketClient); //close socket
                    RemoveFromList(sRemote);//remove from list                  
                    return; //End loop
                }
            }

        }

        public static void ProcessSend(object theSocket)
        {
            //Init variables
            string sRemote = "";
            string sMessage = "";
            Socket socketClient; //socket

            //Try to get socket information
            try
            {
                socketClient = (Socket)theSocket;
                sRemote = socketClient.RemoteEndPoint.ToString();
                ClientMessages.AddOrUpdate(sRemote, (v) => new List<string>(), (k, v) => new List<string>());    //Save to message list
                ClientMessages[sRemote].Add("Server Say Hello!");   //Welcome message
            }
            catch (Exception e1)
            {
                Debug.WriteLine("Method:ProcessSend\r\n" + e1.Message);
                RemoveFromList(sRemote);
                return;
            }

            //Send message
            while (true)
            {

                //avoid sticky package and increase performance
                Thread.Sleep(10);

                //Try to send command
                try
                {
                    //check message list
                    if (ClientMessages[sRemote].Count < 1)
                    {
                        continue;
                    }

                    //Get the first message
                    sMessage = ClientMessages[sRemote][0];

                    SendMessage(socketClient, sMessage);
                    ClientMessages[sRemote].RemoveAt(0); //Remove first message

                    //Remove stacked messages if exceed certain amount
                    if (ClientMessages[sRemote].Count > 10)
                    {
                        //remove old message
                        ClientMessages[sRemote].RemoveAt(0);
                    }
                }
                catch (Exception e2)
                {
                    //error message
                    Debug.WriteLine("Send message error to:"+sRemote+"\r\n"+sMessage);
                    Debug.WriteLine(e2.Message);

                    //Remove this client
                    RemoveFromList(sRemote);

                    //close the client socket
                    CloseSocket(socketClient);

                    return;
                }
            }
        }

        private static void SendMessage(Socket theSocket, string sMessage)
        {
            //Get message
            StringBuilder sb = new StringBuilder();
            sb.Append("��");
            sb.Append(sMessage);
            sb.Append("��");
            sMessage = sb.ToString();
            theSocket.Send(Encoding.UTF8.GetBytes(sMessage));
        }

        //Get messages
        private static string[] ParsingData(string sData)
        {

            string[] stringPattern = new string[] { "��" }; //To separate commands

            string[] sResult = sData.Split(stringPattern, StringSplitOptions.RemoveEmptyEntries);

            return sResult;
        }

        //Close the socket if it's open
        private static void CloseSocket(Socket theSocket)
        {
            if (theSocket == null)
            {//avoid none error, avoid multiple exec error.
                return;
            }

            //Make sure socket has content
            if (!theSocket.Connected)
            {
                theSocket.Close();
                theSocket = null; //clear socket
                return;
            }

            //Close the socket and remove from list
            try
            {
                theSocket.Shutdown(SocketShutdown.Both);//disconnect the socket
                theSocket.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Method:CloseSocket:\r\n" + e.Message);
            }
        }

        private static void RemoveFromList(string sRemote)
        {
            //Try to remove from current list
            ClientList.TryRemove(sRemote, out Socket RemovedSocket);

            //Try to remove message list
            ClientMessages.TryRemove(sRemote, out List<string> RemovedMessages);
        }

    }
}
