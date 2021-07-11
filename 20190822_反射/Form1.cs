using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _20190822_Interface;

namespace _20190822_反射
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //定义实现接口的动态连接库路径
            //string path = @"D:\Documents\Backup\Docs\Apps.Win\ChaoRen.20190812.Winform\20190821_Class\bin\Debug\20190821_Class.dll";
            ////使用接口直接定义类中的方法,ICal为Interface中的类名，_20190821_Class.Calculator为实现的类库中的对应类
            //ICal CalFun = (ICal)Assembly.LoadFrom(path).CreateInstance("_20190821_Class.Calculator");
            //int result = CalFun.Add(1, 2);
            //MessageBox.Show(result.ToString());  
        }
    }
}
