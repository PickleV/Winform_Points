using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190819_Class01_IP_Socket
{
    public partial class Client : Form
    {
       Socket socketClient;
        byte[] receivedByte;

        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void bConnect_Click(object sender, EventArgs e)
        {
            //初始化套接字
            socketClient = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            string ipAddress = tbIP.Text;
            int portClient = int.Parse(tbPort.Text);
            //连接服务器
           socketClient.Connect(ipAddress,portClient);
            //开启接收数据线程
            Thread threadConnect = new Thread(ClientConnect);
            threadConnect.Start();

        }

        public void ClientConnect()
        {
            while (true)
            {

                try
                {
                    // if (socketCLient.Receive())
                    int count = socketClient.Receive(receivedByte);
                    if (count > 0)
                    {
                        //Display info on the main thread
                        Invoke(new MethodInvoker(delegate () {
                            this.tbReceive.Text += Encoding.UTF8.GetString(receivedByte) + "\r\n";
                        }));
                    }
                }
                catch (Exception)
                {

                    
                }
               

                //if (receiveLength > 0)
                //{
                //    //显示数据到控件
                //    Invoke(new MethodInvoker(delegate ()
                //    {
                //        //this.txtReceived.Text = string.Format("接收服务器消息：{0}: ", Encoding.ASCII.GetString(_Result, 0, receiveLength));

                //        this.txtReceived.Text += string.Format("接收服务器消息：{0} ", Encoding.UTF8.GetString(_Result, 0, receiveLength));
                //        this.txtReceived.Text += "\r\n";

                //    }));

                }
        }

        private void Client_Leave(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();

        }
    }
}
