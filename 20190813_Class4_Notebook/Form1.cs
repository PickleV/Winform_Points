using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace _20190813_Class4_Notebook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void 隐藏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();

            textBox1.ForeColor = cd.Color;
                    }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            
            
            fd.ShowDialog();
            textBox1.Font = fd.Font;
        }

        private void 自动换行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.WordWrap = true;
        }

        private void 不换行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.WordWrap = false;
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter=@"文本文件|*.txt";
            openFileDialog1.Multiselect = true;
            openFileDialog1.InitialDirectory = @"D:\Documents\Backup\My Pictures\plane";
            openFileDialog1.Title = "打开找到的文件：";
            if (openFileDialog1.FileName=="")
            {
                return;
            }
            string path = openFileDialog1.FileName;
            FileStream fs = new FileStream(path,FileMode.Open);
            byte[] data = new byte[1024];
            fs.Read(data,0,data.Length);
            string info=Encoding.Default.GetString(data);
            textBox1.Text = info;

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
