using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _20200220_DragEnter_DragDrop
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
