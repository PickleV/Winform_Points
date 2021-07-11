using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace _20200714_DB_MySQL
{
    public partial class Form1 : Form
    {
        static string conStr = "server=localhost;User Id=root;password='Password1!';Database=world";
        MySqlConnection dbCon = new MySqlConnection(conStr);
       


        public Form1()
        {
            InitializeComponent();
        }

        private void bSelect_Click(object sender, EventArgs e)
        {
            //reader
            dbCon.Open();
            string sql = "select * from city limit 10";
            MySqlCommand cmd = new MySqlCommand(sql,dbCon);

            //Define data storage
            DataTable theTable = new DataTable();
            theTable.Columns.Add("Name",typeof(string));//column里要有值，不然赋值时会报错。
            theTable.Columns.Add("Population", typeof(string));

            MySqlDataReader theReader = cmd.ExecuteReader();
            while (theReader.Read())
            {
                DataRow dr = theTable.NewRow();
          
                dr[0] = theReader[1]; //Name
                dr[1] = theReader[4]; //Population

                theTable.Rows.Add(dr);
            }
            dbCon.Close();

            //Value display
            uiDataGridView1.DataSource = null;
            uiDataGridView1.DataSource = theTable.DefaultView;

           
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            dbCon.Open();
            MessageBox.Show("connected!");
            dbCon.Close();
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            //scalar/ˈskeɪlə(r)/ 标量的；数量的；
            dbCon.Open();
            string sql = "select name from city limit 1";
            MySqlCommand cmd = new MySqlCommand(sql, dbCon);
            string a=cmd.ExecuteScalar().ToString();
            dbCon.Close();

            MessageBox.Show(a);
        }
    }
}
