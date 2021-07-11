using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20200916_IP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            GetLocalIPList();
        }

        public List<IPAddress> GetLocalIPList(AddressFamily IPType=AddressFamily.InterNetwork) //Default to be IPV4
        {
            string sName = Dns.GetHostName();
            Console.WriteLine(sName);
            IPAddress[] ips = Dns.GetHostAddresses(sName);  //All local addresses

            List<IPAddress> ipListV4 = new List<IPAddress>(); //Store IPv4
            List<IPAddress> ipListV6 = new List<IPAddress>(); //Store IPv6


            //Get values
            for (int i = 0; i < ips.Length; i++)
            {
                if (ips[i].AddressFamily==AddressFamily.InterNetwork)//IPV4
                {
                    ipListV4.Add(ips[i]);
                }
                else if (ips[i].AddressFamily == AddressFamily.InterNetworkV6)//IPV6
                {
                    ipListV6.Add(ips[i]);
                }
            }

            //Return values
            if (IPType == AddressFamily.InterNetwork)//IPV4
            {
                return ipListV4;
            }
            else if (IPType == AddressFamily.InterNetworkV6)//IPV6
            {
                return ipListV6;
            }
            else
            {
                return ipListV4; //By default
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Get all interfaces
            NetworkInterface[] interfaceList = NetworkInterface.GetAllNetworkInterfaces();
            for (int i = 0; i < interfaceList.Length; i++)
            {
                Console.WriteLine("Count:"+i);
                Console.WriteLine(interfaceList[i].Name);

                IPInterfaceProperties ipProperties= interfaceList[i].GetIPProperties();    //Get network configurations
               UnicastIPAddressInformation[] unicastIPList=ipProperties.UnicastAddresses.ToArray();
                foreach (var item in unicastIPList)
                {
                    Console.WriteLine(item.Address.ToString());
                }
            }

            

        }
    }
}
