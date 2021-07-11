using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sunny.UI;

namespace _20200627_SunnyUI_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitControls();
        }
        private void InitControls()
        {
            InitTreeView();
            InitNavMenu();
        }

        private void InitTreeView()
        {
            //uiTreeView1.ShowNodeToolTips = true; //Allow Tip Display
            
        }

        private void InitNavMenu()
        {
            
        }
    }
}
