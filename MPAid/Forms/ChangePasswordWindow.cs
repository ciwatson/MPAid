using System.Windows.Forms;

namespace MPAid
{
    public partial class ChangePasswordWindow : Form
    {
        private UserManagement allUsers;
        private MPAiUser currentUser;
        private const string title = "Change your password";

        public ChangePasswordWindow(UserManagement users)
        {
            InitializeComponent();

            SetUserManagement(users);
            InitUI();
        }

        private void SetUserManagement(UserManagement users)
        {
            allUsers = users;
            currentUser = allUsers.getCurrentUser();
        }

        private void InitUI()
        {
            Text = title + " - " + allUsers.getCurrentUser().getName();
        }

        private void buttonOK_Click(object sender, System.EventArgs e)
        {
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
            
            allUsers.ChangeUserCode(currentUser.getName(), codeBox.Text);
            MessageBox.Show("Password changed! ",
                  "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
