using FluentEmail.Smtp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20210208_Email
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendEmailAsync();
        }


        private async void SendEmailAsync()
        {
            var sender = new SmtpSender();
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "localhost";
            smtpClient.EnableSsl = true;
            //Send to 
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            //smtpClient.PickupDirectoryLocation = "";
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;





        }
    }
}
