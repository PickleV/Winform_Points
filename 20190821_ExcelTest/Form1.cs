using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190821_ExcelTest
{
    public partial class Form1 : Form
    {


        //string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + _path + ";" + "Extended Properties=\"Excel 12.0;HDR=No\"";
        string conString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source = " + "a.xls" + ";" + "Extended Properties = 'Excel 12.0;HDR=Yes;IMEX=2'";
        //IMEX=0(写)，1（读），2（读写）
        //OleDbCommand oleCMD;
      

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            using (OleDbConnection oleCon=new OleDbConnection(conString))
            {
                oleCon.Open();
                if (oleCon.State== ConnectionState.Open)
                {
                    string sql= "CREATE TABLE 学生信息([学号] INT,[姓名] VarChar,[班级] VarChar,[号码] VarChar,[状态] VarChar)";
                    OleDbCommand oleCMD = new OleDbCommand(sql, oleCon);              
                    oleCMD.ExecuteNonQuery();
                }
            }
            
        }

        private void bSelect_Click(object sender, EventArgs e)
        {
            using (OleDbConnection oleCon = new OleDbConnection(conString))
            {
                try
                {
                    oleCon.Open();
                    string sql = "select top 100 * from '学生信息'";
                   // OleDbCommand oleCMD = new OleDbCommand(sql, oleCon);
                    OleDbDataAdapter oldAdapter = new OleDbDataAdapter(sql,oleCon);
                    DataSet dataSet = new DataSet();
                    oldAdapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];




                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
