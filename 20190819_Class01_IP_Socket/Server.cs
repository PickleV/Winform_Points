using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190819_Class01_IP_Socket
{
    public partial class Server : Form
    {
        Socket SocketServer;
        Socket[] SocketClient=new Socket[100];
        Client formCLient=new Client();
        byte[] buffer = new byte[1024];
        Thread tListen;
       
        Process proc;
        public delegate void delClient();



        public Server()
        {
            InitializeComponent();
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            string input = tbSend.Text;
            SocketClient[0].Send(Encoding.UTF8.GetBytes(input));
           
            //string ip = comboBox1.SelectedItem.ToString();
            //string sendmeessage = sendtxt.Text;
            //asock[ip].Send(Encoding.UTF8.GetBytes(sendmeessage));


            ////CilentSocket.Send(Encoding.UTF8.GetBytes(sendmeessage));

        }

        private void bClient_Click(object sender, EventArgs e)
        {
            bool opened = false;
            foreach (var item in Application.OpenForms)
            {
                if (item is Client)
                {
                    opened = true;
                }
            }
            if (opened==false)
            {
                formCLient.Show();

            }
        }

        private void Server_Load(object sender, EventArgs e)
        {

           

        }

        private void bStart_Click(object sender, EventArgs e)
        {

            //IPHostEntry Hostinfo = Dns.GetHostEntry(Dns.GetHostName());
            //Hostinfo.HostName = Dns.GetHostName();
            //IPAddress ip = HostName.AddressList[0];//从HostName里反向读取IP地址，感觉没什么用，不如直接读IP
            IPAddress ip = IPAddress.Parse(tbIP.Text);
            IPEndPoint ipEndPoint = new IPEndPoint(ip, int.Parse(tbPort.Text));   //绑定IP
            //初始化
            SocketServer = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            //初始化AddressFamily说明：
            //SocketServer = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            //IPv4:System.Net.Sockets.AddressFamily.InterNetwork
            //IPV6:System.Net.Sockets.AddressFamily.InterNetworkV6
            //使用ip.AddressFamily会根据IP自动返回IpV4或者IPV6,或者可以自己填写IPV4与IPV6
            SocketServer.Bind(ipEndPoint); //绑定IP端口
            SocketServer.Listen(100); //监听的数量

            
            tListen = new Thread(ListenMethod); //新开一个线程
            tListen.Start(); //开启线程


            MessageBox.Show(Dns.GetHostName());

            //Set Button
            bStart.Enabled = false;
            bStop.Enabled = true;

          

        }

        private void ListenMethod()
        {
            while (true)
            {
                if (SocketClient!=null)
                {
                    SocketClient[0] = SocketServer.Accept();
                    //Access main control
                    delClient del = new delClient(tbReceiveCLientSocketConnected);
                    this.Invoke(del);
                    //this.Invoke(new MethodInvoker(tbReceiveCLientSocketConnected));
                
                   
                    Thread tReceive = new Thread(ReceiveMedthod);
                    //前后台线程，如果能自动释放叫后台线程
                    //如果要手动放，就是前台线程
                    tReceive.IsBackground = true;
                    tReceive.Start(SocketClient[0]);
                }
                  
              
           
                
                
            }
        }

        private void tbReceiveCLientSocketConnected()
        {
            tbReceive.Text += SocketClient[0].RemoteEndPoint.ToString();
            tbReceive.Text += "\r\n";
        }

        private void ReceiveMedthod(object theSocket)
        {

            while (true)
            {
                Socket _receive = (Socket)theSocket;

                int count = _receive.Receive(buffer);

                if (count > 0)   //如果收到数据
                {
                    //显示数据,子线程禁止直接操作主线程的控件，所以要用invoke,让主线程去控制控件。
                    //invoke();
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        
                        tbReceive.Text += Encoding.UTF8.GetString(buffer, 0, count);
                        tbReceive.Text += "\r\n";
                        

                    }));
                }
                else
                {

                }
            }
            
        }

        private static void DisplayData()
        {

        }

        private void bStop_Click(object sender, EventArgs e)
        {
            // tListen.ex;
            //tReceive.Abort();
            //tListen.Abort();
           
           // SocketServer.Shutdown(SocketShutdown.Both);
            SocketServer.Close();
            //tReceive.Abort();
            //Set Button
            bStop.Enabled = false;
            bStart.Enabled = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Info WinInfo = new Info();
            WinInfo.Show();
        }
    }
}
