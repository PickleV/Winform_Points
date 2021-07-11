using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20210216_Chart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private double f(int i)
        {
            var f1 = 59894 - (8128 * i) + (262 * i * i) - (1.6 * i * i * i);
            return f1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            //chart1.Series
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                chart1.Series[0].Points.AddXY(i, f(i));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
