using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20200815_OpenTKTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void GameLoad(object sender, EventArgs e)
        {

        }

        private void GameFrameUpdate(object sender, EventArgs e)
        {
           
        }

        private void GameFrameRender(object sender, EventArgs e)
        {
           //kill buffer winform 可能不用
            //GL.ClearColor(Color.Blue);
         

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //GameWindow gw = new GameWindow(800, 600);           
            //gw.Load += GameLoad;
            //gw.UpdateFrame += GameFrameUpdate;
            //gw.RenderFrame += GameFrameRender;
            //gw.Run();

            ClassGame1 theGame = new ClassGame1(800,600,"Test Game");
            theGame.Run(30); //最高30 FPS


            
            
        }
    }
}
