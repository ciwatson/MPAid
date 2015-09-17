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

        private FileMapper fileMapper;
        private UserManagement myUsers;

        public LoginWindow()
        {
            InitializeComponent();
            
            fileMapper = new FileMapper();
            myUsers = new UserManagement(fileMapper.GetUserTempPath());

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
                if (myUsers.getLastUser() != null)
                {
                    MPAiUser lastUser = myUsers.getLastUser();
                    userNameBox.Text = lastUser.getName();
                    codeBox.Text = lastUser.getCode();
                }
            }
        }

        public void ResetUserInput()
        {
            userNameBox.Clear();
            codeBox.Clear();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            MPAiUser tUser = new MPAiUser(userNameBox.Text, codeBox.Text);
            if (myUsers.AuthenticateUser(tUser))
            {
                Hide();
                MainForm mainWindow = new MainForm();
                mainWindow.SetUserManagement(myUsers);
                mainWindow.SetHomeWindow(this);
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("User does not exist or password incorrect! ",
                    "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            NewUserWindow newUserWin = new NewUserWindow();
            newUserWin.SetAllUsers(myUsers);
            newUserWin.ShowDialog();

            if (newUserWin.validRegistration())
            {
                if (myUsers.CreateNewUser(newUserWin.getCandidate()))
                {
                    MessageBox.Show("Registration successful! ",
                        "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    myUsers.WriteSettings();
                }
                else
                {
                    MessageBox.Show("User already exist, please use a different name! ",
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
