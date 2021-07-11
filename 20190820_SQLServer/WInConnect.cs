using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;

namespace _20190820_SQLServer
{
    public partial class WInConnect : Form
    {
        public WInConnect()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void WInConnect_Load(object sender, EventArgs e)
        {
            cbLoginType.SelectedIndex = 2;

            //本地数据库
            GetLocalDataBase();
        }

        private void cbLocal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GetLocalDataBase()
        {
            //  Microsoft.SqlServer.Management.Smo
            //DataTable instances=SqlDataSourceEnumerator.Instance.GetDataSources();
            //instances.
        }
    }
}
