using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace _20210822_InvokeSpeedTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool IsEnable { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            IsEnable = true;
            Thread t1 = new Thread(()=> {
                while (IsEnable)
                {
                    //Thread.Sleep(1);
                    label1.Invoke(new MethodInvoker(() =>
                    {
                        label1.Text = DateTime.Now.ToString();
                    }));

                    //label1.BeginInvoke(new MethodInvoker(() =>
                    //{
                    //    label1.Text = DateTime.Now.ToString();
                    //}));
                    Debug.WriteLine(DateTime.Now.ToString("HH':'mm':'ss':'fff"));

                    //Notice
                    //Invoke will block current thread
                    //BeginInvoke won't block, but it will causing overflow
                }

            });
            t1.Start();


     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IsEnable = false;
        }
    }
}
