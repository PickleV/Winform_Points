using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace _20200719_Cotrol_Datetime
{
    public partial class Form1 : Form
    {

        bool m_bFlag = false;

        public Form1()
        {
            InitializeComponent();
           
            
        }

        private void uiDatetimePicker1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (m_bFlag)
            {
                UILocalizeHelper.SetEN();
                m_bFlag = false;
            }
            else
            {
                UILocalizeHelper.SetCH();
                m_bFlag = true;
            }
        }
    }
}
