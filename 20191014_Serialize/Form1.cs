using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace _20191014_Serialize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image a = null;
                a = Image.FromFile(ofd.FileName);
                //新建文件流
                FileStream fs = new FileStream(@"C:\Users\multiverse\Desktop\Temp\a.jpg", FileMode.Create);
                //生成binary对象
                BinaryFormatter bFormat = new BinaryFormatter();
                bFormat.Serialize(fs, a);
                fs.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image a = null;
                //新建文件流
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                a = (Image)(bf.Deserialize(fs));
                pictureBox1.Image = a;
            }
        }

        private void serialize()
        {
            //序列化
            object a = null;
            FileStream fs1 = new FileStream("path", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs1, a);
            //反序列化
            object b = null;
            FileStream fs2 = new FileStream("path", FileMode.Open);
            BinaryFormatter bf2 = new BinaryFormatter();
            b = bf2.Deserialize(fs2);




        }


        public class Config
        {
            public string x1;
            public string x2;
            public string x3;
            public ABC enum1;
            public enum ABC
            {
                A, B, C
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Config config = new Config();
            config.x1 = "v1";
            config.x2 = "v22";
            config.x3 = "v3334";
            config.enum1 = Config.ABC.B;

            string sPath = Directory.GetCurrentDirectory() + @"\xml1.xml";


            //方法2：在ContinueWith中处理异常
            var tSave = Task.Run(() => SerializeXML(config, typeof(Config), sPath));
            tSave.ContinueWith(t1 =>
            {
                //Handle exception first!!!
                if (t1.IsFaulted)
                {
                    MessageBox.Show("Error");
                    Console.WriteLine(t1.Exception.GetBaseException());
                    return;
                }
            });


            ////简写
            //Task.Run(() => SerializeXML(config, typeof(Config), sPath)).ContinueWith(t1=> {
            //    //Handle exception first!!!
            //    if (t1.IsFaulted)
            //    {
            //        MessageBox.Show("Error");
            //        Console.WriteLine(t1.Exception.GetBaseException());
            //        return;
            //    }
            //});

            ////方法1：使用Wait处理异常（会阻塞线程）
            //var tSave1 = Task.Run(() => SerializeXML(config, typeof(Config), sPath));

            //try
            //{
            //    //This will block the thread
            //    tSave1.Wait();
            //}

            //catch (AggregateException e2)
            //{

            //    Console.WriteLine(e2);
            //}
        }

        private void SerializeXML(object TargetObject, Type ClassType, string FilePath)
        {
            //Init values
            XmlSerializer xmlSerializer = new XmlSerializer(ClassType);

            //Check file existance
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }

            //Write to XML
            using (TextWriter write = new StreamWriter(FilePath))
            {
                xmlSerializer.Serialize(write, TargetObject);
            }
        }

        private object DeserializeXML(Type ClassType, string FilePath)
        {
            //Init values
            XmlSerializer xmlSerializer = new XmlSerializer(ClassType);

            //Check file existance
            if (!File.Exists(FilePath))
            {
                throw new Exception();
            }

            //Write to XML
            using (FileStream reader = new FileStream(FilePath,FileMode.Open))
            {
              var Result= xmlSerializer.Deserialize(reader);
              return Result;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {


            string sPath = Directory.GetCurrentDirectory() + @"\xml1.xml";
            object configObject = new Config();
            Task.Run(() => DeserializeXML(typeof(Config), sPath)).ContinueWith(t1=> {
                //Check error
                if (t1.IsFaulted)
                {
                    Console.WriteLine(t1.Exception.GetBaseException());
                    return;
                }

                //get result
                try
                {
                    Config config =(Config)t1.Result;
                }
                catch (Exception)
                {

                    throw;
                }
               
            
            });
        }
    }
}
