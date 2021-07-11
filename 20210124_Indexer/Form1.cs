using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _20210124_Indexer
{
    public partial class Form1 : Form
    {
        //Variables
        int iCount;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IndexTest names = new IndexTest();
            names[0] = "Zara";
            names[1] = "Riz";
            names[2] = "Nuha";
            names[3] = "Asif";
            names[4] = "Davinder";
            names[5] = "Sunil";
            names[6] = "Rubic";
            for (int i = 0; i < names.size; i++)
            {
                Debug.WriteLine(names[i]);
            }


            Thread t1 = new Thread(ProcessUpdate);
            t1.IsBackground = true;
            t1.Start();
           
        }


        private void ProcessUpdate()
        {
            while (true)
            {
                Thread.Sleep(100);
                Random random = new Random();
                iCount = random.Next(1, 100);
                uiAnalogMeter1.Value = iCount;
            }
        }

        class IndexTest
        {
            public int size = 10;
            private List<string> namelist = new List<string>();
            public IndexTest()
            {
                for (int i = 0; i < size; i++)
                {
                    namelist.Add("Num:" + i);
                }
            }

            //定义索引器
            public string this[int index]
            {
                get
                {
                    string temp=string.Empty;
                    if (index>=0&&index<size)
                    {
                        temp = namelist[index];
                    }
                    return temp;
                }
                set
                {
                    if (index >= 0 && index < size)
                    {
                        namelist[index]=value;
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0); //exit all threads
        }

        private void uiAnalogMeter1_Click(object sender, EventArgs e)
        {

        }
    }
}
