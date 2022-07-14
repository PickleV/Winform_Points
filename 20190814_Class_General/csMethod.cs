using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _20190814_Class_General
{
    public class csMethod
    {
        /// <summary>
        /// Whether form is opened
        /// </summary>
        /// <param name="CustomForm"></param>
        /// <returns></returns>
        public static bool IsFormExist(Type FormType)
        {
            //Init variable
            bool IsExist = false;

            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == FormType)
                {
                    IsExist = true;
                }
            }

            //Get result
            return IsExist;
        }
    }
}
