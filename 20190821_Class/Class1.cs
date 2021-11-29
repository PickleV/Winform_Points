using _20190822_Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190821_Class
{
    public class FunWrite
    {
        public static void WriteLineContent(string path,string text)
        {
            using (StreamWriter SW=new StreamWriter(path,true,Encoding.UTF8))
            {
                SW.WriteLine(text);
                //SW.Close();
            }
        }
    }

  

    public class Calculator:ICal
    {
        public int Add(int a,int b)
        {
            return a + b;
        }
    }



}
