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
    public partial class LoginWindow : Form
    {

        private IoController fileMapper;
        private UserManagement myUsers;

        public LoginWindow()
        {
            InitializeComponent();

            fileMapper = new IoController();
            myUsers = new UserManagement(fileMapper.GetAppDataDir());

            InitializeUI();
        }

        private void InitializeUI()
        {
            buttonSignUp.ImageNormal = Properties.Resources.ButtonYellow_0;
            buttonSignUp.ImageHighlight = Properties.Resources.ButtonYellow_1;
            buttonSignUp.ImagePressed = Properties.Resources.ButtonYellow_2;

            buttonLogin.ImageNormal = Properties.Resources.ButtonGreen_0;
            buttonLogin.ImageHighlight = Properties.Resources.ButtonGreen_1;
            buttonLogin.ImagePressed = Properties.Resources.ButtonGreen_2;

            bool autoLog = autoLogin.Checked = Properties.Settings.Default.autoLoginSetting;

            if (autoLog)
            {
                MPAiUser lastUser = myUsers.getLastUser();
                if (lastUser != null)
                    VisualizeUser(lastUser);
            }
        }

        private void VisualizeUser(MPAiUser user)
        {
            userNameBox.Text = user.getName();
            codeBox.Text = user.getCode();
        }

        public void ResetUserInput()
        {
            userNameBox.Clear();
            codeBox.Clear();
        }

        public void PerformLogin()
        {
            MPAiUser tUser = new MPAiUser(userNameBox.Text, codeBox.Text);
            if (myUsers.AuthenticateUser(tUser))
            {
                Hide();
                MainForm mainWindow = new MainForm() { allUsers = myUsers };
                //mainWindow.SetUserManagement(myUsers);
                mainWindow.SetHomeWindow(this);
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("User does not exist or password incorrect! ",
                    "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            NewUserWindow newUserWin = new NewUserWindow();
            newUserWin.SetAllUsers(myUsers);
            newUserWin.ShowDialog();

            MPAiUser candidate = newUserWin.getCandidate();

            if (newUserWin.validRegistration())
            {
                if (myUsers.CreateNewUser(candidate))
                {
                    MessageBox.Show("Registration successful! ",
                        "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    myUsers.WriteSettings();

                    VisualizeUser(candidate);
                }
                else
                {
                    MessageBox.Show("Sorry, unknown error occurred! Please try again~ ",
                        "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void LoginWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            myUsers.WriteSettings();
            Properties.Settings.Default.Save();
        }
    }
}
