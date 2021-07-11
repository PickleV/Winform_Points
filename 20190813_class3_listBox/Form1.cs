using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _20190813_class3_listBox
{
    public partial class 图片查看器 : Form
    {

        string[] path;
        string fileName;

        public 图片查看器()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(path[(listBox1.SelectedIndex)]);
        }

        private void 图片查看器_Load(object sender, EventArgs e)
        {
            path = Directory.GetFiles(@"D:\Documents\Backup\My Pictures\plane");
            for (int i = 0; i < path.Length; i++)
            {
                fileName = Path.GetFileName(path[i]);
                listBox1.Items.Add(fileName);
            }
           
        }
    }
}
