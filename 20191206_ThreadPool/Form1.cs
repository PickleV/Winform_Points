using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _20191206_ThreadPool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WaitCallback waitCallback = new WaitCallback(MyThreadWork);  //WaitCallback 是一个委托，表示线程池线程要执行的回调方法

            ThreadPool.QueueUserWorkItem(waitCallback, "第一个线程"); //可经=以传入一个object
            ThreadPool.QueueUserWorkItem(waitCallback, "第二个线程");
            ThreadPool.QueueUserWorkItem(waitCallback, "第三个线程");
            ThreadPool.QueueUserWorkItem(waitCallback, "第四个线程");
            
        }
        public static void MyThreadWork(object state)
        {
            MessageBox.Show("线程现在开始启动…… {0}", (string)state);       
            Thread.Sleep(10000);
            MessageBox.Show("运行结束…… {0}", (string)state);
        }
    }
}
