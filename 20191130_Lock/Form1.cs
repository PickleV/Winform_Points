using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _20191130_Lock
{
    public partial class Form1 : Form
    {

        public static DataTable dt;
        public static int ID;
        private static object lockDataTable=new object();

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            //init variable
            ID = 0;

            InitDataTable();
            Thread tDisplay = new Thread(
                () =>
                {
                    while (true)
                    {
                        Thread.Sleep(100);
                        DataTable dt1 = new DataTable();
                        lock (lockDataTable)
                        {
                            dt1 = dt.Copy();
                        }
                        this.Invoke(new MethodInvoker(()=>
                        {
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = dt1.DefaultView;
                        }
                        ));
                    }

                }
                
                );
            tDisplay.Start();

        }
        private void InitDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("ID",typeof(int));
            dt.Columns.Add("Time", typeof(DateTime));
            dt.Columns.Add("Check", typeof(bool));
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread tInsert = new Thread(InsertData);
            tInsert.Start();
        }

        private void InsertData()
        {
            while (true)
            {
                lock (lockDataTable)
                {
                    DataRow dr = dt.NewRow();
                    dr["ID"] = ID;
                    dr["Time"] = DateTime.Now;
                    dr["Check"] = true;
                    dt.Rows.Add(dr);
                }
               
                ID++;

                Thread.Sleep(500);
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread tUpdate = new Thread(UpdateData);
            tUpdate.Start();
        }
        private void UpdateData()
        {
            while (true)
            {
                Thread.Sleep(10);
                lock (lockDataTable)
                {
                    if (dt.Rows.Count > 10)
                    {
                        dt.Rows.RemoveAt(0);
                    }
                    if (dt.Rows.Count > 10)
                    {
                        dt.Rows.RemoveAt(0);
                    }
                }
               
            }
        }
    }
}
