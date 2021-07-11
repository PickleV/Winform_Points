using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _20210125_Socket.Classes
{
    class ClassXML
    {
        //read xml
        public static object ReadXML(Type ClassType, string FilePath)
        {
            //Init values
            XmlSerializer xmlSerializer = new XmlSerializer(ClassType);

            //Check file existance
            if (!File.Exists(FilePath))
            {
                return null;
            }

            //Write to XML
            using (FileStream reader = new FileStream(FilePath, FileMode.Open))
            {
                var Result = xmlSerializer.Deserialize(reader);
                return Result;
            }
        }

        public void WriteXML(object TargetObject, Type ClassType, string FilePath)
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
    }
}
