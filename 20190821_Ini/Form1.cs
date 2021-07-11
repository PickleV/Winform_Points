using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20190821_Ini
{
    public partial class Form1 : Form
    {

  /*
---读操作：
[DllImport( " kernel32 " )]
 private   static   extern   int  GetPrivateProfileString( string  section,  string  key,  string  defVal, StringBuilder retVal,  int  size,  string  filePath); 
section：要读取的段落名
key: 要读取的键
defVal: 读取异常的情况下的缺省值
retVal: key所对应的值，如果该key不存在则返回空值
size: 值允许的大小
filePath: INI文件的完整路径和文件名
---写操作：
[DllImport( " kernel32 " )] 
 private   static   extern   long  WritePrivateProfileString( string  section,  string  key,  string  val,  string  filePath); 
section: 要写入的段落名
key: 要写入的键，如果该key存在则覆盖写入
val: key所对应的值
filePath: INI文件的完整路径和文件名
*/
        
        #region 
//写INI文件
[DllImport("kernel32")] 
private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
//读INI文件StringBuilder
[DllImport("kernel32")]
private static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath); 
 //读取INI文件Byte
[DllImport("kernel32")]
private static extern int GetPrivateProfileString(string section, string key, string defVal, Byte[] retVal, int size, string filePath);
#endregion

        string path = @"D:\Documents\Backup\Docs\Apps.Win\ChaoRen.20190812.Winform\20190821_Ini\bin\Debug\abc.ini";
        
        

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void bWrite_Click(object sender, EventArgs e)
        {
            
            WritePrivateProfileString("测试Section", "Key值", "数值", path);
            for (int i = 0; i < 10; i++)
            {
                WritePrivateProfileString("测试Section", i.ToString(), "数值", path);
            }
            for (int i = 0; i < 10; i++)
            {
                WritePrivateProfileString("测试Section1", i.ToString(), "数值", path);
            }
        }

        private void bRead_Click(object sender, EventArgs e)
        {
            StringBuilder value = new StringBuilder();
            //value.Append("");
            GetPrivateProfileString("测试Section", "Key值", "读取失败",value,100,path);
            MessageBox.Show(value.ToString());
        }

        private void bSerialize_Click(object sender, EventArgs e)
        {
            Student s1 = new Student();
            s1.Name = tbSName.Text;
            s1.Cell = long.Parse(tbSCell.Text);
            s1.Born = dateTimePicker1.Value;
            s1.Gender = cbGender.Text;
            //创建文件流
            FileStream fileStream = new FileStream("s1.txt",FileMode.Create);
            //转成二进制
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, s1);

            //关闭文件流
            fileStream.Close();


        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

   

        private void bDeSerialize_OnClick(object sender, EventArgs e)
        {
            //打开文件流
            FileStream fileStream = new FileStream("s1.txt", FileMode.Open);
            //创建二进制格式化器
            BinaryFormatter theFormatter = new BinaryFormatter();
            Student s2 = (Student)theFormatter.Deserialize(fileStream);
            //
            tbSCell.Text = s2.Cell.ToString();
            tbSName.Text = s2.Name;
            cbGender.Text = s2.Gender;
            dateTimePicker1.Value = s2.Born;
            fileStream.Close();
        }

        private void bXML_Click(object sender, EventArgs e)
        {
            FormXML winXMl = new FormXML();
            winXMl.ShowDialog();
        }
    }
}
