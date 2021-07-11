using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _20200705_Custom_Window_Move
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //For window move
        Point pointOld; //record mouse
        Point pointNew; //Record current location

        private void uiPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            pointOld = new Point(e.X,e.Y); //Record start point
        }

        private void uiPanel1_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void uiPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left) //left click
            {
                
                pointNew.X = this.Location.X + (e.X - pointOld.X);//current x + offset
                pointNew.Y = this.Location.Y + (e.Y-pointOld.Y);//current y + offset
                this.Location = pointNew;
            }
        }
    }
}
