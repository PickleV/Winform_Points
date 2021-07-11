using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190821_Ini
{
    //标记对象可序列化,标记下面的一个类，只有一个。
    [Serializable]
    class Student
    {
        public string Name{ set; get; }
        public string Gender { set; get; }
        public long Cell { set; get; }
        public DateTime Born { set; get; }

    }
}
