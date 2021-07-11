using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _20190812_Class1_Start
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]  //特性说明，起始线程
        static void Main()  //静态类
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false); //设置样式
            Application.Run(new Form1()); //加载窗体
        }
    }
}
