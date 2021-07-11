using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20201203_DB_Dapper
{
    public partial class Form1 : Form
    {
        List<Person> result = new List<Person>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DB.GetConStr("Con01"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
           result = DB.GetPerson(tbInput.Text);
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            listBox1.DataSource = result;
            listBox1.DisplayMember = "FullInfo";
        }

        private void bInsert_Click(object sender, EventArgs e)
        {
            DB.InsertPerson(new Person 
            {FirstName=tbNameFirst.Text,LastName=tbNameLast.Text,EmailAddress=tbEmail.Text,Phone=tbPhone.Text});
            UpdateDisplay();
        }
    }
}
