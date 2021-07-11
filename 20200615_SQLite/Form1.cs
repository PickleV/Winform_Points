using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using Microsoft.VisualBasic;

namespace _20200615_SQLite
{
    public partial class Form1 : Form
    {
        static string DBpath = Directory.GetCurrentDirectory() + @"\data.db";
        static string conString = "data source="+DBpath;
        SQLiteConnection conDB = new SQLiteConnection(conString);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from userlist;";
            SelectAndDisplay(sql, listBox1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //accept the name
            string name = Interaction.InputBox("At least 2 characters!", "Please Input List Name", "");  
            if (name.Length<2)
            {
                MessageBox.Show("Please input a valid name!");
                return;
            }
            conDB.Open();
            string sql = "insert into playlist (userID,listName) values (100,'" + name + "')";
            SQLiteCommand theCMD = new SQLiteCommand(sql,conDB);
            theCMD.ExecuteNonQuery();
            conDB.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "select * from playlist;";
            SelectAndDisplay(sql,listBox1);
        }

        private void SelectAndDisplay(string sql,ListBox listboxDisplay)
        {
            listboxDisplay.Items.Clear();//clear display
            conDB.Open();
            //string sql = "select * from playlist;";
            SQLiteCommand CMD = new SQLiteCommand(sql, conDB);
            SQLiteDataReader dbReader = CMD.ExecuteReader();
            while (dbReader.Read())
            {
                string theData = "";
                for (int i = 0; i < dbReader.FieldCount; i++)
                {
                    theData += dbReader[i] + ",";
                }
                listboxDisplay.Items.Add(theData);
            }
            conDB.Close();
        }

        private void SelectAndDisplayAdaptor(string sql,DataGridView theView)
        {
            conDB.Open();
            SQLiteDataAdapter theAdapter = new SQLiteDataAdapter(sql,conDB);
            DataTable theTable = new DataTable();
            theAdapter.Fill(theTable);
            conDB.Close();
            dataGridView1.DataSource = theTable.DefaultView;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql = "select * from userlist;";
            SelectAndDisplayAdaptor(sql,dataGridView1);
        }
    }
}
