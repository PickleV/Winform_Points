using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace _20190813_Class2_PictureLoop
{
    public partial class Form1 : Form
    {

        string[] path;


        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             //Random rd = new Random();
             //int n = rd.Next(0, path.Length-1);

            //using (FileStream fs=new FileStream(path[n],FileMode.Open,FileAccess.Read))   //主动释放资源
            //{
            //    pictureBox1.Image = Image.FromStream(fs);
            //}



            Random rd = new Random();
            int n = rd.Next(0, path.Length - 1);

            pictureBox1.Image = Image.FromFile(path[n]);

            n = rd.Next(0, path.Length - 1);
            pictureBox2.Image = Image.FromFile(path[n]);

            n = rd.Next(0, path.Length - 1);
            pictureBox3.Image = Image.FromFile(path[n]);

            n = rd.Next(0, path.Length - 1);
            pictureBox4.Image = Image.FromFile(path[n]);

            GC.Collect();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            path = Directory.GetFiles(@"D:\Documents\Backup\My Pictures\plane");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
