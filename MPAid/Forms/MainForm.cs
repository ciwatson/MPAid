using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using MPAid.Forms.Config;
using MPAid.Cores;
using MPAid.Models;
using System.Data.Entity;
using MPAid.UserControls;

namespace MPAid
{
    public partial class  MainForm : Form
    {
        public static MainForm self;
        private UserManagement allUsers;
        public UserManagement AllUsers
        {
            get { return allUsers; }
        }
        private IoController systemIO;

        private List<string> recordedWavFiles = new List<string>();
        private BindingList<string> listREC = new BindingList<string>();

        private LoginWindow loginForm;

        private SystemConfig systemConfigForm;

        private RecordingUploadConfig recordingUploadForm;

        private RecordingRenameConfig recordingRenameForm;

        public MPAidModel DBModel;

        //public TestForm test = new TestForm();

        public UserManagement UserManager
        {
            get { return allUsers; }
        }

        public OperationPanel OperationPanel
        {
            get { return operationPanel; }
        }

        public RecordingPanel RecordingList
        {
            get { return recordingPanel; }
        }
        public MainForm(UserManagement users)
        {
            MainForm.self = this;
            InitializeDB();
            InitializeConfig();

            SplashScreen splash = new SplashScreen();
            splash.Show();

            SetUserManagement(users);
            InitializeComponent();
            InitializeUI();

            splash.Close();
        }

        private void SetUserManagement(UserManagement users)
        {
            allUsers = users;
        }

        public void SetHomeWindow(LoginWindow loginWin)
        {
            loginForm = loginWin;
        }

        private void InitializeUI()
        {
            Icon = Properties.Resources.MPAid;
            Text += " " + GetVersionString();

            systemIO = new IoController();
            //myUsers = new UserManagement(ResMan.GetUserTempPath());

            InitializeUserProfile();

            FillLists();        
        }

        //this method is called when allUsers has been initialized
        private void InitializeUserProfile()
        {
            usersToolStripMenuItem.Text = allUsers.getCurrentUser().getName(true);

            // the administrator account is not advised to change its password
            changePasswordToolStripMenuItem.Visible = !allUsers.currentUserIsAdmin();
            administratorConsoleToolStripMenuItem.Visible = allUsers.currentUserIsAdmin();
        }

        private void InitializeConfig()
        {          
            this.systemConfigForm = new SystemConfig();
            this.systemConfigForm.InitializeContent();
            this.recordingUploadForm = new RecordingUploadConfig();
            this.recordingRenameForm = new RecordingRenameConfig();
        }

        private void InitializeDB()
        {
            try
            {
                this.DBModel = new MPAidModel();
                this.DBModel.Database.Initialize(false);
                this.DBModel.Recording.Load();
                this.DBModel.Speaker.Load();
                this.DBModel.Category.Load();
                this.DBModel.Word.Load();
                this.DBModel.SingleFile.Load();
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message, "Database linking error!");
            }
        }
        private void FillLists()
        {
            this.recordingPanel.DataBinding();
        }

        private string GetVersionString()
        {
            return ("[Version " + Application.ProductVersion + "]");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormantPlotController.CloseFormantPlot();

            // this method will decide if the application is exiting
            CloseOtherForms();
        }

        private void CloseOtherForms()
        {
            if (doCloseLogin)
            {
                loginForm.Close();
                doCloseLogin = true;
            }
        }

        private void showAbout()
        {
            MessageBox.Show(this, "Maori Pronunciation Aid "
                  + GetVersionString() + "\n\n" +
                  "Dr. Catherine Watson\n" +
                  "The University of Auckland",
                  "About",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private void headerBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                showAbout();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HMMsConfigForm hmmsConfig = new HMMsConfigForm();
            //hmmsConfig.SetWorkingFolder(ResMan.GetAnnieDir());
            hmmsConfig.ShowDialog();
            HMMsController.SetHMMsValue(hmmsConfig.GetHMMsValue());
        }

        private void openHMMsFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //systemIO.ShowInExplorer();
        }

        bool doCloseLogin = true;

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doCloseLogin = false;
            //loginForm.ResetUserInput();
            loginForm.Show();
            Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordWindow changePswdForm = new ChangePasswordWindow(allUsers);
            changePswdForm.ShowDialog();
        }

        private void administratorConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminConsole adminForm = new AdminConsole(allUsers);
            adminForm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showAbout();
        }

        private void submitFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                const string email = "c.watson@auckland.ac.nz";
                Process.Start(string.Format("mailto:{1}?subject=MPAi Feedback from {0}&body=",
                    allUsers.getCurrentUser().getName(true), email));
            }
            catch (Exception)
            {
                
            }

        }

        private void systemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.systemConfigForm.ShowDialog(this);
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.recordingUploadForm.ShowDialog(this);
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.recordingRenameForm.ShowDialog(this);
        }
    }
}
