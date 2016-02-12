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
using MPAid.Cores;

namespace MPAid.Forms.MSGBox
{
    public partial class FeedbackMSGBox : Form
    {
        public FeedbackMSGBox()
        {
            InitializeComponent();
        }

        private void mailSendButton_Click(object sender, EventArgs e)
        {
            try
            {
                MailSender send = new MailSender();
                if(send.ValidateEmail(customerEmialTextBox.Text))
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(customerEmialTextBox.Text);
                    mail.To.Add("c.watson@auckland.ac.nz");
                    mail.To.Add("syu702@aucklanduni.ac.nz");
                    mail.Subject = mailSubjectTextBox.Text;
                    mail.Body = string.Format("{0}{1}{2}{3}This email is sent from {4}", mailContentTextBox.Text, Environment.NewLine, Environment.NewLine, Environment.NewLine, customerEmialTextBox.Text);
                    send.Send(mail);
                    MessageBox.Show("Mail has been sent!", "Thanks!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Please enter a valid email address!", "Email Address Error!");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Message Sending Error!");
            }
        }
    }
}
