using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _20190813_Practice_FileOpen
{
    public partial class Form1 : Form
    {
        //Variables
        OpenFileDialog ofd = new OpenFileDialog();
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        SaveFileDialog saveFileDialog = new SaveFileDialog();

        //Save
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ofd.Title = "这是一个测试";
            ofd.FilterIndex =1;
            
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DirectoryInfo[] directoryInfos = new DirectoryInfo(@"C:\Users\multiverse\Desktop").GetDirectories();

            if (saveFileDialog.ShowDialog()==DialogResult.OK)
            {
               

                using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName))
                {
                    streamWriter.WriteLine("test!!!!!!!!!!!!!!");
                    foreach (var item in directoryInfos)
                    {
                        streamWriter.Write(item+"\t"+item.FullName+"\n");
                       
                    }
                  
                }


            }
        }
    }
}
