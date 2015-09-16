using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MPAid
{
    public partial class NewUserWindow : Form
    {
        public NewUserWindow()
        {
            InitializeComponent();
        }

        private void NewUserWindow_Load(object sender, EventArgs e)
        {

        }

        private string username = null;
        private string usercode = null;
        private bool valid = false;

        public string getUsername()
        {
            return username;
        }

        public bool validRegistration()
        {
            return valid;
        }

        public string getCode()
        {
            return usercode;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (userNameBox.Text.Trim() == "")
            {
                MessageBox.Show("Username should not be empty! ",
                  "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if ((codeBox.Text.Trim() == "") || (codeBox2.Text.Trim() == ""))
            {
                MessageBox.Show("Passwords should not be empty! ",
                   "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (codeBox.Text != codeBox2.Text)
            {
                MessageBox.Show("Passwords do not match! ",
                    "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            valid = true;
            username = userNameBox.Text;
            usercode = codeBox.Text;

            this.Close();
        }
    }
}
