using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace _20191205_DataTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        DataTable dt1 = new DataTable();
        DataTable theTable1 = new DataTable();

        private void Form1_Load(object sender, EventArgs e)
        {
            Test1();
            Test2();

        }

        private void Test2()
        {
            theTable1.Columns.Add("Time", typeof(DateTime));
            theTable1.Columns.Add("ID", typeof(int));
            theTable1.Columns.Add("Value", typeof(string));
            DataColumn[] theColumns = { theTable1.Columns["ID"] };
            theTable1.PrimaryKey = theColumns;
            theTable1.Columns["ID"].AutoIncrement = true;//自动增加
            theTable1.Columns["ID"].AutoIncrementSeed = 1;//起始为1
            theTable1.Columns["ID"].AutoIncrementStep = 1;//步长为1

            for (int i = 0; i < 5; i++)
            {
                DataRow theRow = theTable1.NewRow();

                theRow["Time"] = DateTime.Now;
                theRow["Value"] = i.ToString();
                theTable1.Rows.Add(theRow);
            }

            dataGridView2.DataSource = theTable1.DefaultView;
        }

        /// <summary>
        /// Use different way to generate table
        /// </summary>
        private void GenerateTableMethods()
        {
           

        }

        private void Test1()
        {
            dt1.Columns.Add("ID", typeof(int));
            dt1.Columns.Add("Name", typeof(string));
            dt1.Columns.Add("Time", typeof(DateTime));
            dt1.Columns.Add("Error", typeof(bool));
            DataColumn[] theColumns = { dt1.Columns["ID"] };
            dt1.PrimaryKey = theColumns;
            dt1.Columns["ID"].AutoIncrement = true;
            dt1.Columns["ID"].AutoIncrementSeed = 1;
            dt1.Columns["ID"].AutoIncrementStep = 1;
            dt1.TableName = "TableTest1";



            //可以加入空的
            for (int i = 0; i < 5; i++)
            {
                DataRow dr = dt1.NewRow();
                
                dr["Time"] = DateTime.Now;
                dt1.Rows.Add(dr);
              
            }
            dataGridView1.DataSource = dt1.DefaultView;
        }




        private void button2_Click(object sender, EventArgs e)
        {

         
        }

        private void button3_Click(object sender, EventArgs e)
        {

          
        }

        int a = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
           //dataGridView2.DataSource = null;
           //dataGridView2.DataSource = theTable1.DefaultView;

            //medthod1
            if (dataGridView2.Rows.Count>2)
            {
                for (int i = 0; i < dataGridView2.Rows.Count-1; i++)
                {
                    dataGridView2.Rows[i].Cells[2].Value = a;
                   
                }
                a += 10;
            }


            //method2

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DataRow theRow = theTable1.NewRow();
            theRow["Time"] = DateTime.Now;
            theRow["Value"] = tbInput.Text;
            theTable1.Rows.Add(theRow);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // theTable1.Rows.RemoveAt(int.Parse(tbRemove.Text));
            DataRow[] theRows = theTable1.Select("ID="+ int.Parse(tbRemove.Text));
            theRows[0]["Value"] = 333;
            

           // theTable1.Rows.Remove(theRows[0]);

        }

        private void bSelect_Click(object sender, EventArgs e)
        {
            Stopwatch t1 = new Stopwatch();
            int num = 10;
            try
            {
                num =int.Parse( tbTest3Select.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }
            t1.Start();
            DataRow[] dr = dtTest3.Select("ID <"+num);
            t1.Stop();
            tbTest3.AppendText("Select used:"+t1.ElapsedMilliseconds+"ms\r\n");

        }


        DataTable dtTest3;

        private void bCreateTest3_Click(object sender, EventArgs e)
        {
                
            DateTime t1 = DateTime.Now;

            dtTest3 = new DataTable();
            
            dtTest3.Columns.Add("ID", typeof(int));
            dtTest3.Columns.Add("Value", typeof(int));
            dtTest3.Columns.Add("Time", typeof(DateTime));

            if (checkBox1.Checked)
            {
                DataColumn[] dc = { dtTest3.Columns["ID"] };
                dtTest3.PrimaryKey = dc;
            }


            int dt_ID = 0;
            int count = 0;
            try
            {
                count = int.Parse(tbTest3Count.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }

            for (int i = 0; i < count; i++)
            {
                DataRow theRow = dtTest3.NewRow();
                Random rd = new Random();
                int dt_Value = rd.Next(1,9999999);
                dt_ID++;
                theRow["ID"] = dt_ID;
                theRow["Time"] = DateTime.Now;
                theRow["Value"] = dt_Value;
                dtTest3.Rows.Add(theRow);
                
                //Console.WriteLine(i);
            }
            DateTime t2 = DateTime.Now;
            TimeSpan t3 = t2 - t1;

            tbTest3.AppendText(t3.TotalMilliseconds+" ms for:"+count+"行数据\r\n");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(dt1);
            string path = Directory.GetCurrentDirectory() +"/"+DateTime.Now.ToString("_yyyyMMdd_HHmmss") + ".log";
            FileStream fs = new FileStream(path,FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs,s);
            fs.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string path="";
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                path = ofd.FileName;
            }
            else
            {
                return;
            }

            //string path = Directory.GetCurrentDirectory() + "/test1.log";
            StreamReader sr = new StreamReader(path,Encoding.UTF8);
            string s = sr.ReadToEnd();
            sr.Close();
            //FileStream fs = new FileStream(path, FileMode.Open);
            //BinaryFormatter bf = new BinaryFormatter();
            //string s=(string)bf.Deserialize(fs);
            //fs.Close();
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(s,typeof(DataTable));
           
            dataGridView1.DataSource = dt.DefaultView;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(dt1);
            string path = Directory.GetCurrentDirectory() + "/" + DateTime.Now.ToString("_yyyyMMdd_HHmmss") + ".log";
            StreamWriter sw = new StreamWriter(path,true,Encoding.UTF8);
            sw.Write(s);
            sw.Close();
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string path = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
            }
            else
            {
                return;
            }

            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            string s = (string)bf.Deserialize(fs);
            fs.Close();
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(s, typeof(DataTable));

            dataGridView1.DataSource = dt.DefaultView;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "/" + DateTime.Now.ToString("_yyyyMMdd_HHmmss") + ".xml";
            FileStream fs = new FileStream(path,FileMode.Create);
            dt1.WriteXml(fs);
            fs.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string path = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
            }
            else
            {
                return;
            }
            FileStream fs = new FileStream(path, FileMode.Open);
            DataTable dtTemp = new DataTable();
            dtTemp = dt1.Clone();
            dtTemp.ReadXml(fs);
            fs.Close();
            dataGridView1.DataSource = dtTemp.DefaultView;
        }

        Dictionary<int, DateTime> theDictionnary;
        
        private void button10_Click(object sender, EventArgs e)
        {
            int n = int.Parse(tbTest3Count.Text);
            DateTime t1 = DateTime.Now;
            theDictionnary = new Dictionary<int, DateTime>();
            for (int i = 0; i < n; i++)
            {
                theDictionnary.Add(i + 1, DateTime.Now);
            }
            DateTime t2 = DateTime.Now;
            TimeSpan tSpan = t2 - t1;
            tbTest3.AppendText("生成Dictionary用时:"+tSpan.TotalMilliseconds + "ms \r\n");

        }

        private void button11_Click(object sender, EventArgs e)
        {
           
        }

        private void button12_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count-1; i++)
            {
                dataGridView2.Rows[i].Cells[2].Value = 10;
            }

            DataGridViewRow theRow = dataGridView2.Rows[2];
            theRow.Cells[2].Value = 20;


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Stopwatch t1 = new Stopwatch();
            int iIndex= dtTest3.Rows.Count/2;
            t1.Start();
            DataRow dr = dtTest3.Rows[iIndex];
            t1.Stop();
            tbTest3.AppendText("Select used:" + t1.ElapsedMilliseconds + "ms\r\n");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();


            dtTest3 = new DataTable();

            dtTest3.Columns.Add("ID", typeof(int));
            dtTest3.Columns.Add("Value", typeof(int));
            dtTest3.Columns.Add("Time", typeof(DateTime));

            if (checkBox1.Checked)
            {
                DataColumn[] dc = { dtTest3.Columns["ID"] };
                dtTest3.PrimaryKey = dc;
            }


            int dt_ID = 0;
            int count = 0;
            try
            {
                count = int.Parse(tbTest3Count.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }

            watch.Start();

            for (int i = 0; i < count; i++)
            {
                DataRow theRow = dtTest3.NewRow();
                Random rd = new Random();
                int dt_Value = rd.Next(1, 9999999);
                dt_ID++;
                theRow["ID"] = dt_ID;
                theRow["Time"] = DateTime.Now;
                theRow["Value"] = dt_Value;
                dtTest3.Rows.Add(theRow);

                //Console.WriteLine(i);
            }
            watch.Stop();

            dtTest3.Columns.Add("Status", typeof(string));
            tbTest3.AppendText(watch.ElapsedMilliseconds + " ms for:" + count + "行数据:Column Add After\r\n");

            dtTest3 = new DataTable();
            dtTest3.Columns.Add("ID", typeof(int));
            dtTest3.Columns.Add("Value", typeof(int));
            dtTest3.Columns.Add("Time", typeof(DateTime));
            dtTest3.Columns.Add("Status", typeof(string));
            watch.Restart();
            for (int i = 0; i < count; i++)
            {
                DataRow theRow = dtTest3.NewRow();
                Random rd = new Random();
                int dt_Value = rd.Next(1, 9999999);
                dt_ID++;
                theRow["ID"] = dt_ID;
                theRow["Time"] = DateTime.Now;
                theRow["Value"] = dt_Value;
                theRow["Status"] = null;
                dtTest3.Rows.Add(theRow);

                //Console.WriteLine(i);
            }
            watch.Stop();
            tbTest3.AppendText(watch.ElapsedMilliseconds + " ms for:" + count + "行数据:Column predefined.\r\n");
        }
    }
}
