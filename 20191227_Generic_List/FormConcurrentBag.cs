using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Concurrent;


namespace _20191227_Generic_List
{
    public partial class FormConcurrentBag : Form
    {
        ConcurrentBag<string> theBag = new ConcurrentBag<string>();


        public FormConcurrentBag()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 10; i++)
            {
                theBag.Add(DateTime.Now.ToString()+":"+i);
            }

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (var item in theBag)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            theBag.Add(DateTime.Now.ToString() + ":" + tbInput.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
           // theBag.RemoveAt(int.Parse(tbRemove.Text));

          
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Try to remove, default is the last one.
            theBag.TryTake(out string s1);
            MessageBox.Show("Removed:"+s1);
        }
    }
}
