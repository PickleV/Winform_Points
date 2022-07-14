using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20220713_Dev_Layout_2201
{
    public partial class FormLaunch : Form
    {
        public FormLaunch()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Shown += FormLaunch_Shown;
        }

        private void FormLaunch_Shown(object sender, EventArgs e)
        {
            this.Hide();
            FormMain winMain = new FormMain();
            winMain.ShowDialog();
        }
    }
}
