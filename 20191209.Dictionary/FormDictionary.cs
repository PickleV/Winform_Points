using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _20191209.Dictionary
{
    public partial class FormDictionary : Form
    {
        public FormDictionary()
        {
            InitializeComponent();
        }

        Dictionary<DateTime, string> theDict = new Dictionary<DateTime, string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            theDict.Add(DateTime.Now,"1");
            Thread.Sleep(10);
            theDict.Add(DateTime.Now, "2");
            Thread.Sleep(10);
            theDict.Add(DateTime.Now, "3");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = "";
            foreach (var item in theDict)
            {
                textBox1.AppendText(item.Key.ToString()+"___"+item.Value+"\r\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            theDict.Add(DateTime.Now,tbInput.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            theDict.Remove(theDict.ElementAt(int.Parse(tbRemove.Text)).Key);
        }
    }
}
