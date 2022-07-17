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
    public partial class FormMain : UIForm
    {
        public FormMain()
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

        private void bSample1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
