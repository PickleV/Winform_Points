using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using _20190814_Class_General;

namespace _20191227_Generic_List
{
    public partial class FormList : Form
    {
        List<string> theList = new List<string>();

        public FormList()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 10; i++)
            {
                theList.Add(DateTime.Now.ToString()+":"+i);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (var item in theList)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            theList.Add(DateTime.Now.ToString() + ":" + tbInput.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            theList.RemoveAt(int.Parse(tbRemove.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] List2=new string[theList.Count];
            theList.CopyTo(List2);
            theList.Clear();
            Debug.WriteLine(List2.Length);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Test1(Value saved)
            var sGroup1 = CreateStudentGroup();
            var sGroup2 = sGroup1.ToList();//Create a new list instead of reference
            sGroup1.Clear();
            Debug.WriteLine("Test1:"+sGroup2.Count); //Same number

            //Test2(value cleared)
            sGroup1= CreateStudentGroup();
            sGroup2 = sGroup1;
            sGroup1.Clear();
            Debug.WriteLine("Test2:"+sGroup2.Count);

        }

        private List<Student> CreateStudentGroup()
        {
            List<Student> sGroup = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                var student = new Student() { Name = "Name_" + i.ToString(), Age = i, Grade = i };
                sGroup.Add(student);
            }

            return sGroup;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<int> theList = new List<int>();
            for (int i = 0; i < 50; i++)
            {
                theList.Add(i);
            }
            theList.Add(3);
            theList.Add(4);
            MessageBox.Show("num of elements is:" + theList.Count.ToString());
            theList.Sort();
            MessageBox.Show("Capacity is:" + theList.Capacity.ToString());
        }
    }
}
