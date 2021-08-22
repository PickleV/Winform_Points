using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace _20190813_Class1_Timer
{
    public partial class Form1 : Form
    {

        string[] path;
        int picSelection=0;
        string StringLoop = "abcde";
        int lifeSpan;
        bool bTimerStarted=false;
        int Counter = 0;
        Stopwatch sw1 = new Stopwatch();
        DateTime t1;
        // System.Threading.Timer tTest = new System.Threading.Timer(p=>TimerThread(),);
        System.Timers.Timer st1 = new System.Timers.Timer();

        public Form1()
        {
            InitializeComponent();
        }

        private static void TimerThread()
        {

        }
        enum abc
        {
            a=-1,
            b=3,
            c
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            
            timer1.Enabled = true;
            comboBox1.Items.Add("测试");
            comboBox1.SelectedIndex = 0;

            //Add year
            for (int i = 1900; i < 2100; i++)
            {
                cbYear.Items.Add(i + "年");
            }

            //picture
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
           // pictureBox1.Image = Image.FromFile(@"D:\Documents\Backup\My Pictures\plane\Canard.jpg");
            //path=Directory.GetFiles(@"D:\Documents\Backup\My Pictures\plane\");
            //pictureBox1.Image = Image.FromFile(path[picSelection]);
            //String loop
            tbLoop.Text = StringLoop;


            timerLifeSpanTest.Enabled = false;


            //system timers.timer
            st1.Interval = 1000;
            st1.Elapsed += st1Event;
            st1.Enabled = true;                
        }
     
        private void st1Event(object sender, ElapsedEventArgs e)
        {
            st1.Enabled = false;        
            Thread.Sleep(5000);
            st1.Enabled = true;
            MessageBox.Show("可以运行？");
        }
        private void TestTimer()
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("哈哈哈");
            textBox1.Text = DateTime.Now.ToString();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Add Month
            for (int i = 1; i < 13; i++)
            {
                cbMonth.Items.Add(i + "月");
            }

        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Get month
            int index_month = cbMonth.Text.IndexOf('月');
            string monthString = cbMonth.Text.Substring(0, index_month);
            int month = int.Parse(monthString);

            //Get yeat
            int indexYear=cbYear.Text.IndexOf("年");
            string yearString = cbYear.Text.Substring(0,indexYear);
            int year = int.Parse(yearString);



            //Add days
            int days = 0;

            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    days = 31;
                    break;


                case 4:

                case 6:

                case 9:

                case 11:
                    days = 30;
                    break;

                case 2:
                    if ((year%4==0||year%400==0)&&year%100!=0)
                    {
                        days = 29;
                    }
                    else
                    {
                        days = 28;
                    }
                    break;

                default:
                    break;
            }


            cbAddDays(days);

        }

        private void cbAddDays(int days)
        {
            cbDay.Items.Clear();
            //Add Days
            for (int i = 1; i < days+1; i++)
            {
                cbDay.Items.Add(i + "日");
            }
        }

        private void bNext_Click(object sender, EventArgs e)
        {
            if (picSelection<path.Length-1)
            {
                picSelection++;
            }
            else
            {
                picSelection = 0;
            }

            pictureBox1.Image = Image.FromFile(path[picSelection]);

        }

        private void tbLoop_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer_stringLoop_Tick(object sender, EventArgs e)
        {
            StringLoop=StringLoop.Substring(1, StringLoop.Length - 1)+StringLoop.Substring(0,1);
            tbLoop.Text = StringLoop;
            DateTime t1 = DateTime.Now;
        

        }

        object locker = new object();

        private void timerLifeSpanTest_Tick(object sender, EventArgs e)
        {
            //if (bTimerStarted==true)
            //{
            //    return;
            //}
            //bTimerStarted = true;

            //t1 = DateTime.Now;
            ////  Thread.Sleep(5000);
            //while ((DateTime.Now - t1).TotalMilliseconds < 5000)
            //{
            //    Application.DoEvents();
            //}

            //lifeSpan += 1;
            //tbLifeSpan.Text = lifeSpan.ToString();

            //// MessageBox.Show("运行了");


            //bTimerStarted = false;

            timerLifeSpanTest.Enabled = false;
            t1 = DateTime.Now;
            //  Thread.Sleep(5000);
            
                while ((DateTime.Now - t1).TotalMilliseconds < 5000)
                {
                    Application.DoEvents();
                }
            lifeSpan += 1;
            tbLifeSpan.Text = lifeSpan.ToString();

            timerLifeSpanTest.Enabled = true;
        }

        private void tbLifeSpan_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
            t1.Interval = 500;
            t1.Tick += T1_Tick;
            t1.Start();

        }

        private async void T1_Tick(object sender, EventArgs e)
        {
            var timer1 = (System.Windows.Forms.Timer)sender;
            timer1.Enabled = false;

            //Start
            Counter += 1;
            await Task.Delay(2000);


            //Finish
            Counter-= 1;

            Debug.WriteLine(DateTime.Now.ToString("HH':'mm':'ss':'fff") + $"Timer Test:{Counter}");

            timer1.Enabled = true;
        }
    }
}
