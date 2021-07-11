using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HalconDotNet;

namespace _20191122_SpeedTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            double sum = 0;
            int Cal = 99999;
            DateTime dt1 = DateTime.Now;
            for (int i = 0; i <= Cal; i++)
            {
                for (int j = 0; j <= Cal; j++)
                {
                    sum += i * j;
                }
            }
            DateTime dt2 = DateTime.Now;
            TimeSpan dd = dt2 - dt1;

            textBox1.AppendText("C#计算"+ Cal + "结果:" + sum + "\r\n");

            textBox1.AppendText("C#用时:" + dd.TotalMilliseconds.ToString() + "\r\n");





            //
            Thread t1 = new Thread(ABC);
            t1.Start();
       

        }
        private void ABC()
        {
            double sum = 0;
            int Cal = 99999;
            DateTime dt1 = DateTime.Now;
            for (int i = 0; i <= Cal; i++)
            {
                for (int j = 0; j <= Cal; j++)
                {
                    sum += i * j;
                }
            }
            DateTime dt2 = DateTime.Now;
            TimeSpan dd = dt2 - dt1;

            this.Invoke(new MethodInvoker(()=>
            {
               
                textBox1.AppendText("C#线程计算"+ Cal + "结果:"+sum + "\r\n");

                textBox1.AppendText("C#线程用时:" + dd.TotalMilliseconds.ToString() + "\r\n");
            }));

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("Halcon 计算开始" + "\r\n");
            HTuple hv_Sum = null, hv_Index1 = null, hv_Index2 = new HTuple();
            // Initialize local and output iconic variables 
            int Cal = 99;
            DateTime dt1 = DateTime.Now;
            
            hv_Sum = new HTuple();
            for (hv_Index1 = 1; (int)hv_Index1 <= Cal; hv_Index1 = (int)hv_Index1 + 1)
            {
                for (hv_Index2 = 1; (int)hv_Index2 <= Cal; hv_Index2 = (int)hv_Index2 + 1)
                {
                    hv_Sum = hv_Sum.TupleConcat(hv_Index1 * hv_Index2);
                }
            }

            DateTime dt2 = DateTime.Now;
            TimeSpan dd = dt2 - dt1;
            textBox1.AppendText("Halcon计算"+Cal+"结果:" + hv_Sum + "\r\n");
            textBox1.AppendText("Halcon用时:" + dd.TotalMilliseconds.ToString() + "\r\n");
        }
    }
    
}
