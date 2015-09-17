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
        
        private string username = null;
        private string usercode = null;
        private bool valid = false;
        private UserManagement allUsers;

        public MPAiUser getCandidate()
        {
            username = userNameBox.Text;
            usercode = codeBox.Text;

            return (new MPAiUser(username, usercode));
        }

        public bool validRegistration()
        {
            return valid;
        }
        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void SetAllUsers(UserManagement console)
        {
            allUsers = console;
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
            
            MPAiUser candidate = getCandidate();

            if (allUsers.ContainUser(candidate))
            {
                MessageBox.Show("User already exist, please use a different name! ",
                    "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                valid = true;
                this.Close();
            }

        }
        
    }
}
