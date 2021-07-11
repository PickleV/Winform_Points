using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace _20190821_Ini
{
    public partial class FormXML : Form
    {
        XmlDocument theXml;

        public FormXML()
        {
            InitializeComponent();
        }

        private void bDisplay_Click(object sender, EventArgs e)
        {
            //theXml.Load(@"D:\Documents\Backup\Config\test.xml");
            DataTable dt = new DataTable();
            FileStream fs = new FileStream(@"D:\Documents\Backup\Config\test.xml",FileMode.Open);
            dt.ReadXml(fs);
            dataGridView1.DataSource = dt.DefaultView;
            


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
