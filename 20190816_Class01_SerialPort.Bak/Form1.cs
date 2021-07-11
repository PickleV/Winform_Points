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



namespace _20190816_Class01_SerialPort
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
            SetupLayout();
            ReadXMLConfig();
            port1.DataReceived += Port1Receive;
        }

        private void Port1Receive(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] data = new byte[port1.ReadBufferSize];
            port1.Read(data,0,data.Length);

            if (rbRecString.Checked==true)
            {
            Invoke(new MethodInvoker(() =>tbReceive.Text = Encoding.UTF8.GetString(data)));
            }
            if (rbRecHex.Checked==true)
            {
                // Convert.ToString(data[0], 16); 只能一个个转
                MessageBox.Show(data.Length.ToString());
                
                string s = string.Concat(data.Select(b => b.ToString("X2")));
                s= BitConverter.ToString(data).Replace("-"," ");
                Invoke(new MethodInvoker(() => tbReceive.Text = s));
                //Invoke(new MethodInvoker(() =>tbReceive.Text = bytesToHexStr(data) ));
               
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
            

            for (int i = 0; i < count-1; i++)
                {
                    data[i] = Convert.ToByte(str.Substring(i*2,2),16);
                }

                if (str.Length % 2 != 0)
                {
                data[count - 1] = Convert.ToByte(str.Substring(str.Length-1, 1), 16);
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
                port1.StopBits = (StopBits)cbStopBits.SelectedIndex;              
                port1.DataBits = Convert.ToInt32(cb_Bits.Text);
                try
                {
                    port1.Open();
                    bPortOpen.Text = "关闭端口";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    // MessageBox.Show(Exception.);                                    
                }          

            }//

            else
            {
                port1.Close();
                bPortOpen.Text = "打开端口";
            }

            //

        }

        private void bPortSend_Click(object sender, EventArgs e)
        {
            if (port1.IsOpen)
            {
                if (rbHex.Checked)
                {
                    try
                    {
                        port1.Write(strToHexByte(tbSend.Text), 0, strToHexByte(tbSend.Text).Length);
                    }
                    catch (Exception EX)
                    {

                        MessageBox.Show(EX.Message);
                    }
                    
                    
                    // port1.Write();
                   // string text = "AA BB";
                    //port1.Write();
                }

                else
                {
                    
                    port1.Write(tbSend.Text);
                }
            }
            else
            {
                Console.WriteLine("请先打开端口！");
            }
        }

        private void SetupLayout()
        {
            //
            for (int i = 1; i < 21; i++)
            {
                cbPortNumber.Items.Add("COM" + i.ToString());
            }
            //
            cbPortRate.Items.Add(2400);
            cbPortRate.Items.Add(4800);
            cbPortRate.Items.Add(9600);
            cbPortRate.Items.Add(11520);
            cbPortRate.Items.Add(19200);
            //
            //
            cb_Bits.Items.Add(7);
            cb_Bits.Items.Add(8);
            cb_Bits.Items.Add(9);

          //
            cbVerify.Items.Add("None");
            cbVerify.Items.Add("奇校验");
            cbVerify.Items.Add("偶校验");
            //
            // System.Windows.Shapes.Ellipse
            //Ellipse Indicator01 = new Ellipse();
            //Indicator01.Width = 500;
            //Indicator01.Height = 500;
            //Indicator01.Fill = System.Windows.Media.Brushes.Red;
            //Indicator01.IsEnabled = true;
            //Indicator01.Visibility = System.Windows.Visibility.Visible;
            //this.Controls.Add(Indicator01);
            //Inc(,)
            
            


        }

        private void ReadXMLConfig()
        {
            try
            {
                xml.Load(@"D:\Documents\Backup\Config\SerialPort.xml");               
                XmlNode theNode = xml.SelectSingleNode("SerialPort");               
                cbPortNumber.SelectedIndex = int.Parse(theNode.SelectSingleNode("PortName").InnerText);
                cbPortRate.SelectedIndex = int.Parse(theNode.SelectSingleNode("BaudRate").InnerText);
                cbStopBits.SelectedIndex = int.Parse(theNode.SelectSingleNode("StopBits").InnerText);
                cb_Bits.SelectedIndex = int.Parse(theNode.SelectSingleNode("DataBits").InnerText);
                cbVerify.SelectedIndex = int.Parse( theNode.SelectSingleNode("Parity").InnerText);
                cbSetupByXML = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取配置文件错误！");
                MessageBox.Show(ex.Message);
            }

        }

        //write info back to xml
        private void cbPortNumber_SelectedIndexChanged_CommonEvent(object sender, EventArgs e)
        {
            if (cbSetupByXML==true)
            {
                //MessageBox.Show("修改了！");
                XmlNode theNode = xml.SelectSingleNode("SerialPort");
                ComboBox cbChanged = (ComboBox)sender;
                theNode.SelectSingleNode(cbChanged.Tag.ToString()).InnerText = cbChanged.SelectedIndex.ToString();
                xml.Save(@"D:\Documents\Backup\Config\SerialPort.xml");
                
            }
          
        }
    }
}
