using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20200829_Datetime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime time1 = DateTime.UtcNow;  //Get current UTC time
            DateTime time2 = time1.ToLocalTime(); //Get local time
            Console.WriteLine(time1.ToString());
            Console.WriteLine(time2.ToString());


            //转成Datetimeoffset
            DateTime dt1 = DateTime.Now;

            Console.WriteLine("dt1:"+dt1.ToString()+"Type:"+dt1.Kind.ToString()); //默认为Local时间
            dt1 = DateTime.SpecifyKind(dt1,DateTimeKind.Local); //我们存的是本地时间
            DateTimeOffset dto1 = dt1;
            Console.WriteLine(dto1.ToLocalTime().ToString());


            //直接使用
            Console.WriteLine("Direct use datetimeoffset:");
            DateTimeOffset toff = DateTimeOffset.Now;
            Console.WriteLine(toff.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //直接使用
            Console.WriteLine("Button use datetimeoffset:");
            DateTimeOffset toff = dateTimePicker1.Value.Date;
            Console.WriteLine(toff.ToLocalTime().ToString()); //display time
            //注意要转成Local time，后再显示。
        }
    }
}
