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

namespace _20210125_Try_Catch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> a = new List<string>();

            try
            {
                Debug.WriteLine(a[1]);
                try
                {

                }
                catch (Exception)
                {

                    throw;
                }
            }

            //catch (Exception)
            //{

            //    throw;
            //}
            finally
            {
               //Do sth
            }
        }
    }
}
