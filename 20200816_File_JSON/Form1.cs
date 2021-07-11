using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20200816_File_JSON
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sData = "";
            FileStream fs = File.Open("xxx.json",FileMode.Open);
            using (StreamReader sr=new StreamReader(fs))
            {
               sData=sr.ReadToEnd();
            }
            fs.Close();
            JObject jData = JObject.Parse(sData);
            Console.WriteLine(jData["Header"]);

            //Check property existance
            if (jData.ContainsKey("Header"))
            {
                //Check property name
                if (jData["Header"].ToString()== "PerfectCue")
                {
                    Console.WriteLine("Test.OK");
                }
               
            }
       
            

            //MeetingInfo jData = JsonConvert.DeserializeObject<MeetingInfo>(sData);
            //Console.WriteLine(jData.Header);

        }

        public class MeetingInfo //When login success
        {
            public bool LoginStatus;
            public string Header = "PerfectCue";
            public string Message;
            public int MeetingID;
            public string MeetingName;
            public int PresID;
            public string PresName;
            public DateTimeOffset MeetingStart;
            public DateTimeOffset MeetingEnd;
            public string MeetingManagerName;
            public string MeetingManagerTel;
            public string MeetingIPPublic;
            public string MeetingIPLocal;
            public int MeetingPort;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Test string
            string s1 = "{\"datas\":[{\"pid\":96513996,\"articleid\":805439249}]}";
            string s2 = "{\"pid\":96513996,\"articleid\":805439249}";
            string s3 = "{\"datas\":[]}";

            //Get test string
            //string sPath=Directory.GetCurrentDirectory()+@"\test1.txt";         
            //FileStream fs = new FileStream(sPath,FileMode.Open);
            //StreamReader reader = new StreamReader(fs);
            //string sRead = reader.ReadToEnd();

            JObject jObject =JObject.Parse(s1);
            Console.WriteLine(jObject);         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            School theSchool = new School();
            for (int i = 0; i < 3; i++)
            {
                School.Student student = new School.Student();
                student.Name = i.ToString();
                student.Age = (i * 10).ToString();
                theSchool.students.Add(student);
            }

            string s = JsonConvert.SerializeObject(theSchool);
            JObject jObject = JObject.Parse(s);
            Console.WriteLine(jObject);

        }

        public class School
        {
            public string Name="QinHua University";
            public List<Student> students=new List<Student>();

            public struct Student
            {
                public string Name;
                public string Age;
            }
        }
    }
}
