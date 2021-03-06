using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Shapes;
using System.Xml;
using System.Windows.Media;
using System.IO;
using System.Threading;
using System.Management;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace _20200614_UpWork_SerialPort_BitWise
{
    public partial class Form1 : Form
    {
        //变量
        SerialPort port1 = new SerialPort();//实例化串口类
        XmlDocument xml = new XmlDocument();//实例化XML配置
        bool cbSetupByXML = false;//ComboBox 初始设定Flag，读取XML后的设定


        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            SetupLayout(); //add pre set values
            ReadXMLConfig();//read xml to load previous config
            port1.DataReceived += Port1Receive; //port receive event method
        }

        private void Port1Receive(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] data = new byte[port1.BytesToRead]; //real length   
            port1.Read(data, 0, data.Length);
            string s = ""; //info

            if (rbRecString.Checked == true)
            {
                s = Encoding.UTF8.GetString(data);
                //Invoke(new MethodInvoker(() => tbReceive.AppendText( s+"\r\n" )));
            }
            else
            {
                // MessageBox.Show(data.Length.ToString()); //Display received length
                s = BitConverter.ToString(data).Replace("-", " ");
                Invoke(new MethodInvoker(() => tbReceive.AppendText(s)));
                Console.WriteLine(DateTime.Now.ToString("HH':'mm':'ss':'fff") + " : " + s);
            }
        }

        //String to Hex Byte
        public byte[] strToHexByte(string str)
        {
            str = str.Replace(" ", "");  //去掉空格
            int count = (int)(Math.Ceiling(((double)str.Length) / 2)); //算出位数，如果是单数也算成双数
            if (count == 0)
            {
                return null;
            }

            byte[] data = new byte[count];


            for (int i = 0; i < count - 1; i++)
            {
                data[i] = Convert.ToByte(str.Substring(i * 2, 2), 16);
            }

            if (str.Length % 2 != 0)
            {
                data[count - 1] = Convert.ToByte(str.Substring(str.Length - 1, 1), 16);
            }
            else
            {

                data[count - 1] = Convert.ToByte(str.Substring(str.Length - 2, 2), 16);
            }

            return data;
        }


        //byte to hex
        public string bytesToHexStr(byte[] data)
        {
            if (data == null)
                return "";
            StringBuilder stringbuffer = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                //注意如果"00"--会转成"0"，所以先做前四位，再做后四位
                //stringbuffer.Append(Convert.ToString(data[i]&0x, 16));
                stringbuffer.Append(Convert.ToString(data[i], 16));
            }
            return stringbuffer.ToString();
        }

        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        private void bPortOpen_Click(object sender, EventArgs e)
        {
            if (port1.IsOpen == false)
            {
                port1.PortName = (string)cbPortNumber.Text;
                port1.BaudRate = int.Parse(cbPortRate.Text);
                port1.Parity = (System.IO.Ports.Parity)(cbVerify.SelectedIndex);
                port1.StopBits = (StopBits)cbStopBits.SelectedIndex + 1;

                port1.DataBits = Convert.ToInt32(cb_Bits.Text);
                try
                {
                    port1.Open();
                    bPortOpen.Text = "Close Port";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    // MessageBox.Show(Exception.);                                    
                }

            }//

            else
            {
                //Put port close in thread so UI won't freeze
                Thread tTemp = new Thread(() =>
                {
                    port1.Close();
                });
                tTemp.IsBackground = true;
                tTemp.Start();

                bPortOpen.Text = "Open Port";
            }

            //

        }

        private void bPortSend_Click(object sender, EventArgs e)
        {
            SendInfo(tbSend.Text);
        }



        private void SendInfo(string theInfo)
        {
            {
                if (!port1.IsOpen) //make sure port is open
                {
                    Console.WriteLine("Please Open The Port！");
                    return;
                }

                if (rbHex.Checked)
                {   //if its hex communication, convert to hex before send.
                    try
                    {
                        port1.Write(strToHexByte(theInfo), 0, strToHexByte(theInfo).Length);
                    }
                    catch (Exception EX)
                    {

                        MessageBox.Show(EX.Message);
                    }

                }

                else
                {  //if it's string cummuniation direct send info.
                    port1.Write(theInfo);
                }


            }
        }

        private void SetupLayout()
        {
            LoadSerialPorts(); //Get local serial ports

            //baud rate
            cbPortRate.Items.Clear();
            cbPortRate.Items.Add(2400);
            cbPortRate.Items.Add(4800);
            cbPortRate.Items.Add(9600);
            cbPortRate.Items.Add(11520);
            cbPortRate.Items.Add(19200);
            cbPortRate.Items.Add(38400);
            cbPortRate.SelectedIndex = 2;

            //data bits 
            cb_Bits.Items.Clear();
            cb_Bits.Items.Add(6);
            cb_Bits.Items.Add(7);
            cb_Bits.Items.Add(8);
            //stop bits
            cbStopBits.Items.Clear();
            //cbStopBits.Items.Add("None");//Stop bits none should never be used, will cause error
            cbStopBits.Items.Add("1");
            cbStopBits.Items.Add("1.5");
            cbStopBits.Items.Add("2");
            //verification
            cbVerify.Items.Clear();
            cbVerify.Items.Add("None");
            cbVerify.Items.Add("Odd");
            cbVerify.Items.Add("Even");
            //

        }


        private void LoadSerialPorts()
        {
            //Get local serial ports
            string[] sPorts = SerialPort.GetPortNames();

            //Check result
            if (sPorts.Length < 1)
            {
                cbPortNumber.Items.Clear();
                cbPortNumber.Items.Add("N/A");
                return;
            }

            //Add ports
            cbPortNumber.Items.Clear();
            for (int i = 0; i < sPorts.Length; i++)
            {
                cbPortNumber.Items.Add(sPorts[i]);
            }

            //Select first port
            cbPortNumber.SelectedIndex = 0;
        }

        private void ReadXMLConfig()
        {
            try
            {
                xml.Load(Directory.GetCurrentDirectory() + @"\SerialPort.xml");
                XmlNode theNode = xml.SelectSingleNode("SerialPort");
                //read port nums
                if (int.Parse(theNode.SelectSingleNode("PortName").InnerText) < (cbPortNumber.Items.Count - 1))
                {//make sure previous selected port not bigger than current computer's com status
                    cbPortNumber.SelectedIndex = int.Parse(theNode.SelectSingleNode("PortName").InnerText);
                }
                cbPortRate.SelectedIndex = int.Parse(theNode.SelectSingleNode("BaudRate").InnerText);
                cbStopBits.SelectedIndex = int.Parse(theNode.SelectSingleNode("StopBits").InnerText) - 1;
                cb_Bits.SelectedIndex = int.Parse(theNode.SelectSingleNode("DataBits").InnerText);
                cbVerify.SelectedIndex = int.Parse(theNode.SelectSingleNode("Parity").InnerText);
                cbSetupByXML = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("XML Read Error！");
                MessageBox.Show(ex.Message);
            }

        }

        //write info back to xml
        private void cbPortNumber_SelectedIndexChanged_CommonEvent(object sender, EventArgs e)
        {
            if (cbSetupByXML == true)
            {
                //MessageBox.Show("修改了！");
                XmlNode theNode = xml.SelectSingleNode("SerialPort");
                ComboBox cbChanged = (ComboBox)sender;
                theNode.SelectSingleNode(cbChanged.Tag.ToString()).InnerText = cbChanged.SelectedIndex.ToString();
                xml.Save(Directory.GetCurrentDirectory() + @"\SerialPort.xml");

            }

        }

        private void rbRecString_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbRecHex_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbString_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bClear_Click(object sender, EventArgs e)
        {
            tbReceive.Text = "";
        }

        private void bCMD1_Click(object sender, EventArgs e)
        {
            string s = "CD 01";
            SendInfo(s);
            tbSend.Text = s;   //display the command
        }

        private void bCMD2_Click(object sender, EventArgs e)
        {
            string s = "CD 02";
            SendInfo(s);
            tbSend.Text = s;   //display the command
        }

        private void bCMD3_Click(object sender, EventArgs e)
        {
            string s = "CD 03";
            SendInfo(s);
            tbSend.Text = s;   //display the command
        }

        private void bFind_Click(object sender, EventArgs e)
        {
            LoadSerialPorts();
        }

        private void bSearchDevice_Click(object sender, EventArgs e)
        {
            //Variables
            string sHardwareID = @"VID_10C4&PID_EA60";//Get DeviceID


            //if fail, getting port wrong
            if (!FindComDeviceByDeviceID(sHardwareID, out string thePort))
            {
                string errMSG = "Device not connected.."; //get error message
                MessageBox.Show(errMSG);
            }
            else
            {
                string errMSG = $"Device connected on port {thePort}..";
            }
        }


        //Find device
        public static bool FindComDeviceByDeviceID(string sDeviceID, out string ComName)
        {
            //Init Variables
            ComName = "";
            sDeviceID = sDeviceID.ToUpper();//The default is with lowercase but device has upper case, so I switch it to upper case;        
            string sResult = "";
            int count = 0;

            //Init finder
            ManagementObject matchedObject = null; //store matched object if found
            ManagementObjectSearcher theFinder = new ManagementObjectSearcher("SELECT * FROM WIN32_PnPEntity");
            ManagementObjectCollection deviceList = theFinder.Get(); //Get device list
            Console.WriteLine("PNP devices found:" + deviceList.Count); //Display count of devices found

            //Match by device ID
            //Match one by one in use hardwareID
            foreach (ManagementObject theObject in deviceList)
            {

                //Use device ID
                ////avoid instance error ， “Use hardware ID”
                if (theObject["DeviceID"] == null)
                {
                    continue;
                }
                else
                {
                    //maintain all upper case to avoid missing match!!!
                    if (theObject["DeviceID"].ToString().Contains(sDeviceID))
                    {
                        count += 1;//add Count
                        matchedObject = theObject; //Save matched object!
                        sResult += theObject["DeviceID"].ToString() + "\r\n";
                        break; //No need to check all string of a hardwareID group.
                    }
                }
            }

            //Check result coun=0/>1 will be stopped!
            if (count == 0)
            {
                Console.WriteLine("Method \"FindDeviceByHardwareID\":\r\n Cable not recognized.");
                return false;
            }

            //Get captain
            string sCaption = matchedObject["Caption"].ToString().ToUpper(); //Get display name of the device
            string sExp = @"^.*\((COM[0-9]{1,2})\)$";

            //Check if name ends with "COM"
            if (!Regex.IsMatch(sCaption, sExp))
            {
                Debug.WriteLine("Method \"FindDeviceByHardwareID\":\r\n  Device detected,  but found no match COM port");
                return false;
            }


            //Get COM port
            string[] Result = Regex.Split(sCaption, sExp);//Get result 
            ComName = Result[1]; //Get COM name of that device
            Debug.WriteLine($"Found device on port:{ComName}");
            return true;
        }
    }
}

