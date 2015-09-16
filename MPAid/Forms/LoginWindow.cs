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
            InitializeUI();

            fileMapper = new FileMapper();
            myUsers = new UserManagement(fileMapper.GetUserTempPath());
        }

        private void InitializeUI()
        {
            buttonSignUp.ImageNormal = Properties.Resources.ButtonYellow_0;
            buttonSignUp.ImageHighlight = Properties.Resources.ButtonYellow_1;
            buttonSignUp.ImagePressed = Properties.Resources.ButtonYellow_2;

            buttonLogin.ImageNormal = Properties.Resources.ButtonGreen_0;
            buttonLogin.ImageHighlight = Properties.Resources.ButtonGreen_1;
            buttonLogin.ImagePressed = Properties.Resources.ButtonGreen_2;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (myUsers.AuthenticateSuccess(userNameBox.Text, codeBox.Text))
            {
                Hide();
                MainForm mainWindow = new MainForm();
                mainWindow.SetUserManagement(myUsers);
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
            newUserWin.ShowDialog();

            if (newUserWin.validRegistration())
            {
                if (myUsers.CreateNewUser(newUserWin.getUsername(), newUserWin.getCode()))
                {
                    MessageBox.Show("Registration successful! ",
                        "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("User already exist, please use a different name! ",
                        "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }
    }
}
