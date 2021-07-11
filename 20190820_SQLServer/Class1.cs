using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190820_SQLServer
{
   

    class ClassDB
    {
        public static SqlConnection dbVision;
        public static readonly string connectionString = "Server=localhost;User Id=Vision;Pwd=Password1!;DataBase=Vision";
       
        public static DataTable GetDataTable()
           
        {
            //构建连接
            dbVision = new SqlConnection(connectionString);
            dbVision.Open();
            if (dbVision.State==ConnectionState.Open)  //确认打开
            {
                string cmdString = "select * from student";
                //SqlCommand cmd = new SqlCommand(cmdString, connectionVision);
                SqlDataAdapter theAdapter = new SqlDataAdapter(cmdString, dbVision);
                DataTable theTable = new DataTable();
                theAdapter.Fill(theTable);
                dbVision.Close();
                return theTable;
            }
            else
            {
               
                MessageBox.Show("数据库连接错误！");
                return null;
            }
            
        }
    }

   class TheForm
    {
       // public static Main MainForm;
        
    }
}
