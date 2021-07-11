using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _20190812_Class2_RunAway
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            int x, y;
            x = button1.Parent.Size.Width - button1.Size.Width;//注意横着的是X
            y = panel1.Size.Height-button1.Size.Height;//竖着的是Y

            //get limit
            Random rd = new Random();
            int a, b;
            a = rd.Next(0,x);
            b = rd.Next(0,y);

            //update display
            lX.Text = a.ToString();
            lY.Text = b.ToString();


            //RESET LOCATION
            button1.Location = new Point(a, b);






        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.SystemColors.Control;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
