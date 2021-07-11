using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _20190812_Practice01_window
{
    public partial class Form1 : Form
    {
        sub02 win02 = new sub02();


        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool bFlagSub01 = false;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i] is sub01)
                {
                    MessageBox.Show("窗口已经打开！");
                    bFlagSub01 = true;
                }
            }
            if (bFlagSub01 == false)
            {
                sub01 win01 = new sub01();
                win01.Show();
               
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool bFlagSub01 = false;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i] is sub01)
                {
                    Application.OpenForms[i].Close();
                    bFlagSub01 = true;

                }
            }
            if (bFlagSub01 == false)
            {
                MessageBox.Show("没有打开的窗口！");
            }
        }

        private void bWin02Show_Click(object sender, EventArgs e)
        {
            win02.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bWin02_Hide_Click(object sender, EventArgs e)
        {
            win02.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //using (sub03 win03=new sub03())
            //{
            //    win03.ShowDialog();
            //}

            sub03 win03 = new sub03();
            win03.ShowDialog();
            win03.Dispose(); //只会在新窗口关闭后dispose!!!

        }





        //private void WinFormExist(object theForm)
        //{
        //    bool bFlagSub01 = false;
        //    for (int i = 0; i < Application.OpenForms.Count; i++)
        //    {
        //        if (Application.OpenForms[i] is theForm)
        //        {
        //            Application.OpenForms[i].Close();
        //            bFlagSub01 = true;
        //        }
        //    }

        //}
    }
}
