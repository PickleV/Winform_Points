using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace _20200810_WebAPIClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bGet_Click(object sender, EventArgs e)
        {
         
            string s = WebRequest_Get(tbURL.Text,tbMeeting.Text,tbPres.Text);
            tbResult.Text = s;


            //https://localhost:44302/api/login/?input=admin
        }

        private string WebRequest_Get(string API_Url,string MeetingID,string PresID)
        {
            //http://127.0.0.1:99/api/login/?MeetingID=100&PresPass=123
            string url = API_Url+ @"/api/login/?MeetingID=" + MeetingID+ "&PresPass="+ PresID;
            //url = string.Format(url, API_Url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/json";
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception e)
            {

                return e.Message;
            }
 
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

    }
}
