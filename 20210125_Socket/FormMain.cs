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

namespace _20210125_Socket
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ClassSocket.StartServer("127.0.0.1", 6789))
            {
                MessageBox.Show("Open Server Error.");
            }
            else
            {
                MessageBox.Show("Server started.");
            }
            
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dynamic a = 1;
            string b = a.GetType().ToString();
            //Debug.WriteLine(a.GetType().ToString()); //无法直接显示
            Debug.WriteLine(b); //正常运行
        }
    }
}
