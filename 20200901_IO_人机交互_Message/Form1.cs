using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20200901_IO_人机交互_Message
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           DialogResult dr=MessageBox.Show("Content","Title",MessageBoxButtons.YesNo);
            if (dr==DialogResult.Yes)
            {
                MessageBox.Show("Yes");
            }
            else
            {
                MessageBox.Show("No");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          //IWin32Window可以直接用Form转
            DialogResult dr = MessageBox.Show(this,"Content", "Title");
            MessageBox.Show("With icon","Info",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
          
        }
    }
}
