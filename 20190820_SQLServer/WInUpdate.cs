using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190820_SQLServer
{
    public partial class WInUpdate : Form
    {
        DataTable dataTable=new DataTable();
        bool flagTime = false;

        public WInUpdate(DataGridView theView)
        {
            InitializeComponent();
            dataGridView1.DataSource =theView.DataSource;
            timer1.Enabled = true;

        }

        private void WInUpdate_Load(object sender, EventArgs e)
        {
            dataTable = (DataTable)dataGridView1.DataSource;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedCells[0].ColumnIndex;
            int Row = dataGridView1.SelectedCells[0].RowIndex;
            string item = dataGridView1.Columns[index].Name;
            string id = dataGridView1.Rows[index].Cells["学号"].Value.ToString();
            string sql = "update student set " + item + "=" + tbValue.Text + " where [学号]=" + id;
            SqlConnection sqlCon1 = new SqlConnection(ClassDB.connectionString);
            sqlCon1.Open();
            using (SqlCommand cmd = new SqlCommand(sql,sqlCon1))
            {
                try
                {
                    
                    int a=cmd.ExecuteNonQuery();
                    if (a>0)
                    {
                        MessageBox.Show("执行成功！");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                   
                }
            }

            sqlCon1.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (flagTime)
            {
                tbSelected.Text = dataGridView1.SelectedCells[0].Value.ToString();
            }
         

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            flagTime = true;
            timer1.Enabled = false;
        }
    }
}
