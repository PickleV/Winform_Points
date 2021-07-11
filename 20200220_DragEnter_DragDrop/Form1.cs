using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _20200220_DragEnter_DragDrop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            //Console.WriteLine(e.Data.GetData("TEXT"));
            //Console.WriteLine(((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString());
            foreach (var obj in (System.Array)e.Data.GetData(DataFormats.FileDrop))
            {
                Console.WriteLine(obj.ToString());
            }
        }
    }
}
