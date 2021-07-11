using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _20210126_Dynamics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dynamic a=1;
            string b = a.GetType().ToString();
            Debug.WriteLine(b); //正常运行
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
