using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _20191114A_CameraSDK
{
    public partial class Form1 : Form
    {
        FormMindVision winMindVision;
        FormHikVision winHikVision;
        FormBasler winBasler;
        public Form1()
        {
            InitializeComponent();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            bool bOpened = false;
            foreach (Form item in Application.OpenForms)
            {
                if (item is FormMindVision)
                {
                    bOpened = true;
                }

            }
            if (bOpened == false)
            {
                winMindVision = new FormMindVision();
                winMindVision.Show();
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //打开HikVision窗口
            bool bOpened = false;
            foreach (Form item in Application.OpenForms)
            {
                if (item is FormHikVision)
                {
                    bOpened = true;
                }

            }
            if (bOpened == false)
            {
                winHikVision = new FormHikVision();
                winHikVision.Show();
            }
            //------------------------

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //打开HikVision窗口
            bool bOpened = false;
            foreach (Form item in Application.OpenForms)
            {
                if (item is FormBasler)
                {
                    bOpened = true;
                }

            }
            if (bOpened == false)
            {
                winBasler = new FormBasler();
                winBasler.Show();
            }
            //------------------------
        }
    }
}
