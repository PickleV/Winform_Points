using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20201130_Bit_Operation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ushort a = 0xFF;
            int b = a & 1;
            int Value1 = Convert.ToInt32("11111111", 2);
            int Value2 = Convert.ToInt32("10001110", 2);
            int Result1 = Value1 & 1;  //Result 1
            int Result2 = Value2 & 1;  //Result 0
            int Result3=  Value1 >> 1;
            Console.WriteLine(Convert.ToString(Result3,2)); //转成二进制显示,注意这里面高位的0不会显示

            //List<List<string>> ab = new List<List<string>>();
            int x1 = 8 ^ 2;  //1010
            Console.WriteLine("x1:"+Convert.ToString(x1,2));

            //注意，不同长度做位运算
            //都正常

            //正常流程＂^＂, 0^0=0,  0^1=1, 1^1=0
            //注意 16位做异或时，前8位保留（0与任何数异或，都是原来的数），后8位开始计算
            ushort Test1 = 0xF0FF;
            int a1= (Test1 ^ 0x0F);
            Console.WriteLine("a1:"+Convert.ToString(a1,2)); //1111000011110000

            //正常流程 "&"，0&0=0， 0&1=0， 1&1=1
            //16位做与运算，如果对方只有8位，高8位为零（0与任何数与，结果都为0），只会保留后8位
            ushort Test2 = 0xF0FF;
            ushort a2 = (ushort)(Test2 & 0x0F); // 16位对11
            Console.WriteLine("a2:" + Convert.ToString(a2, 2)); //1111

            //正常流程 "|"，0|0=0，0|1=1，1|1=1
            //16位做或运算，如果对方只有8位， 高8位不娈（0与任何数或都是原来的值），后8位做运算
            ushort Test3 = 0xF0FF;
            ushort a3 = (ushort)(Test3 | 0x0F); // 高8位不娈，后8位做运算
            Console.WriteLine("a3:" + Convert.ToString(a3, 2)); //1111000011111111

        }
    }
}
