using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190819_Class01_IP_Socket
{
    public partial class Info : Form
    {

        StringBuilder infoText = new StringBuilder(1024);

        public Info()
        {
            InitializeComponent();
        }

        private void Info_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {

                Process proc = Process.GetCurrentProcess();


                int count = proc.Threads.Count;
                infoText.Clear();
                infoText.AppendLine("线程数为" + count);
               

                for (int i = 0; i < proc.Threads.Count; i++)
                {
                    infoText.AppendLine(proc.Threads[i].ToString());
                }


                tbInfo.Text = infoText.ToString();
             

            }
            catch (Exception ex)
            {

                tbInfo.Text += ex.Message;
            }
            
        }
    }
}
