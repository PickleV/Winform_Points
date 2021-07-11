using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _20191227_Generic_List
{
    public partial class FormList : Form
    {
        List<string> theList = new List<string>();

        public FormList()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 10; i++)
            {
                theList.Add(DateTime.Now.ToString()+":"+i);
            }

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (var item in theList)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            theList.Add(DateTime.Now.ToString() + ":" + tbInput.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            theList.RemoveAt(int.Parse(tbRemove.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
