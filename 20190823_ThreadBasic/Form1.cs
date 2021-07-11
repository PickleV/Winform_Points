using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190823_ThreadBasic
{
    public partial class Form1 : Form
    {
        //variables
        int DictionaryMax = 999999; //max value for dictionary update
        int DictionaryCurrent = 0; //current dictionary max value


        public Form1()
        {
            InitializeComponent();
        }

        bool flag1 = true;

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(funT1);
            //t1.IsBackground = true;

            //    Invoke(new MethodInvoker(delegate ()
            //    {
            //        for (long i = 0; i < 999999999999; i++)
            //        {
            //            textBox1.Text = i.ToString();
            //            Thread.Sleep(100);
            //        }
            //    }));          
            //});
            t1.Start();
            //
            //Process.GetCurrentProcess().Kill();            
        }

        private void funT1()
        {
            long i = 0;
            while (flag1)
            {

                Control.CheckForIllegalCrossThreadCalls = false;
                textBox1.Text = i.ToString();
                Thread.Sleep(100);
                i++;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Thread t2 = new Thread(() =>
            {

                Thread.Sleep(5000);
                MessageBox.Show("Delay");
            });
            t2.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (flag1)
            {
                flag1 = false;
            }
            else
            {
                flag1 = true;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        Thread tTest3;

        private void button5_Click(object sender, EventArgs e)
        {
            Thread tTemp = new Thread(
            () =>
            {
                while (true)
                {
                    Thread.Sleep(10);
                    if (tTest3 == null)
                    {
                        cbTest3_Null.Invoke(new MethodInvoker(() =>
                        {
                            cbTest3_Null.Checked = true;
                        }));


                    }
                    else
                    {
                        cbTest3_Null.Invoke(new MethodInvoker(() =>
                        {
                            cbTest3_Null.Checked = false;
                        }));

                        //
                        if (tTest3.IsAlive)
                        {
                            cbTest3_IsAlive.Invoke(new MethodInvoker(() =>
                            {
                                cbTest3_IsAlive.Checked = true;
                            }));


                        }
                        else
                        {
                            cbTest3_IsAlive.Invoke(new MethodInvoker(() =>
                            {
                                cbTest3_IsAlive.Checked = false;
                            }));
                        }
                    }



                }

            }
                );
            tTemp.IsBackground = true;
            tTemp.Start();
        }

        bool bTest3 = false;
        private void button4_Click(object sender, EventArgs e)
        {
            tTest3 = new Thread(() =>
            {
                while (bTest3)
                {
                    Thread.Sleep(5000);
                    MessageBox.Show("test3!");
                }

            });
            tTest3.IsBackground = true;
            tTest3.Start();
        }

        private void cb_bTest3_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_bTest3.Checked)
            {
                bTest3 = true;
            }
            else
            {
                bTest3 = false;
            }

        }


        Dictionary<int, string> d1;
        object lock_Dictionary = new object();
        private void button6_Click(object sender, EventArgs e)
        {
            d1 = new Dictionary<int, string>();
            for (int i = 0; i < 10; i++)
            {
                //d1.TryAdd(i," value:"+i.ToString());
                d1.Add(i, " value:" + i.ToString());

            }
            DictionaryDisplay();
        }


        private void DictionaryDisplay()
        {
            StringBuilder sb = new StringBuilder();
            lock (lock_Dictionary)
            {
                foreach (var item in d1)
                {
                    sb.Append(item.Key.ToString() + item.Value + "\r\n");
                }
            }


            this.Invoke(new MethodInvoker(() =>
            {
                tbDictionary.Text = sb.ToString();
            }));

            lock (lock_Dictionary)
            {
                if (d1.Keys.Max() == DictionaryMax)
                {
                    Thread.CurrentThread.Abort();    //kill current thread
                }
            }

        }

        private void DictionaryDisplayConcurrent()
        {
            StringBuilder sb = new StringBuilder();
            lock (lock_concurrentoperation)
            {
                foreach (var item in d2)
                {
                    sb.Append(item.Key.ToString() + item.Value + "\r\n");
                }
            }

            this.Invoke(new MethodInvoker(() =>
            {
                tbDictionary.Text = sb.ToString();
            }));

            if (DictionaryCurrent == DictionaryMax)
            {
                Thread.CurrentThread.Abort();    //kill current thread
            }
        }

        private void DictionaryUpdate()
        {

            int iMin = d1.Keys.Min();
            DictionaryCurrent = d1.Keys.Max();
            d1.Remove(iMin);
            d1.Add(DictionaryCurrent + 1, " value:" + DictionaryCurrent);

            if (DictionaryCurrent == DictionaryMax - 1)
            {
                sw1.Stop();
                d1[DictionaryMax] = " Value:" + sw1.Elapsed.TotalMilliseconds.ToString() + "ms";
            }


        }


        object lock_concurrentoperation = new object();
        private void DictionaryUpdateConcurrent()
        {

            int iMin = d2.Keys.Min();
            int DictionaryCurrent = d2.Keys.Max();
            if (!d2.TryRemove(iMin, out string Value))
            {
                Console.WriteLine("Remove Fail:" + iMin);
            }

            if (!d2.TryAdd(DictionaryCurrent + 1, " value:" + DictionaryCurrent))
            { //Try to add if not exist
                Console.WriteLine("Add Fail:" + DictionaryCurrent);
            }

            if (DictionaryCurrent == DictionaryMax - 1)
            {
                sw1.Stop();
                d2[DictionaryMax] = " Value:" + sw1.Elapsed.TotalMilliseconds.ToString() + "ms";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Thread tUpdate = new Thread(ProcessDictionaryUpdate);
            Thread tUpdate2 = new Thread(ProcessDictionaryUpdate);
            Thread tDisplay = new Thread(ProcessDictionaryDisplay);
            tDisplay.IsBackground = true;
            tUpdate.IsBackground = true;
            tUpdate2.IsBackground = true;
            tUpdate.Start();
            tUpdate2.Start();
            tDisplay.Start();
        }


        Stopwatch sw1 = new Stopwatch();
        private void ProcessDictionaryUpdate()
        {
            sw1.Reset();
            sw1.Start();

            while (DictionaryCurrent < DictionaryMax)
            {
                Thread.Sleep(1);
                lock (lock_Dictionary)
                {
                    DictionaryUpdate();
                }

            }



        }

        private void ProcessDictionaryDisplay()
        {
            while (true)
            {
                Thread.Sleep(10);
                DictionaryDisplay();
            }
        }

        private void ProcessDictionaryUpdateConcurrent()
        {
            sw1.Reset();
            sw1.Start();
            while (DictionaryCurrent < DictionaryMax)
            {
                //Thread.Sleep(1);
                lock (lock_concurrentoperation)
                {
                    DictionaryUpdateConcurrent();
                }

            }
        }

        private void ProcessDictionaryDisplayConcurrent()
        {
            while (true)
            {
                Thread.Sleep(10);
                DictionaryDisplayConcurrent();
            }
        }

        ConcurrentDictionary<int, string> d2;
        private void button9_Click(object sender, EventArgs e)
        {
            d2 = new ConcurrentDictionary<int, string>();
            for (int i = 0; i < 10; i++)
            {
                d2.TryAdd(i, " value:" + i.ToString());
            }
            DictionaryDisplayConcurrent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Thread tUpdate = new Thread(ProcessDictionaryUpdateConcurrent);
            Thread tUpdate2 = new Thread(ProcessDictionaryUpdateConcurrent);
            Thread tDisplay = new Thread(ProcessDictionaryDisplayConcurrent);
            tDisplay.IsBackground = true;
            tUpdate.IsBackground = true;
            tUpdate2.IsBackground = true;
            tUpdate.Start();
            tUpdate2.Start();
            tDisplay.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (ClassDB.CheckDBConnectionTimeout(out string err,1000))
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Bad");
            }
        }

        class Student : IDisposable
        {
            public int ID { get; set; }
            public string Name { get; set; }

            ~Student()
            {

            }

            public void Dispose()
            {

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (ClassDB.CheckDBConnection(out string err))
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Bad");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (ClassDB.CheckDBConnectionTimeout2(out string err,2000))
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Bad");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
         
            while (watch.ElapsedMilliseconds<5000)
            {
                Application.DoEvents();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            while (watch.ElapsedMilliseconds < 5000)
            {
                Thread.Sleep(1);
                Application.DoEvents();
            }
        }
    }
}
