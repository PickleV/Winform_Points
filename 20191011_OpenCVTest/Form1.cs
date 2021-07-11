using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
//using DirectShowLib;

namespace _20191011_OpenCVTest
{
    public partial class Form1 : Form
    {

        VideoCapture cam;
        Mat frame=null;
        System.Timers.Timer t1 = new System.Timers.Timer(50);
        Timer t2 = new Timer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           
            t1.Elapsed += t1_tick;
       

            t2.Tick += t2_tick;
            t2.Interval = 100;


        }

        private void t1_tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (cam != null)
            {
                if (frame != null)
                {
                    frame.Dispose();
                }

                frame = cam.QueryFrame();
                pictureBox1.Image = frame.Bitmap;

            }

        }

        private void t2_tick(object sender, EventArgs e)
        {
         

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cam = new VideoCapture();  //摄像头初始化
            t1.Enabled = true;
        }
    }
}
