using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using MPAid.Forms.Config;
using MPAid.Cores;
using MPAid.Models;
using System.Data.Entity;
using MPAid.UserControls;
using Vlc.DotNet.Core;
using MPAid.Forms;

namespace MPAid
{
    public partial class MainForm : Form
    {
        public static MainForm self;
        private UserManagement allUsers;
        public UserManagement AllUsers
        {
            get { return allUsers; }
        }
        private IoController systemIO;

        private Thread AsyncPlayer;
        private string CurrentSoundPath = null;

        private int CurrentNumPlayback = 1;
        private int CurrentSoundId = 0;
        private int CurrentAudioSource = 0;
        //private int DefaultInterval = 200;

        private List<string> recordedWavFiles = new List<string>();
        private BindingList<string> listREC = new BindingList<string>();

        private LoginWindow loginForm;

        private SystemConfig systemConfigForm;

        private RecordingUploadConfig recordingUploadForm;

        private RecordingRenameConfig recordingRenameForm;

        public SysCfg configContent;

        public MPAidModel DBModel;

        public TestForm test = new TestForm();

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
            InitializeDB();

            Icon = Properties.Resources.MPAid;
            Text += " " + GetVersionString();

            systemIO = new IoController();
            //myUsers = new UserManagement(ResMan.GetUserTempPath());

            InitializeUserProfile();

            RefreshAnimationSpeed();

            FillLists();

            // Add Volume Meter to the form
            InitializeNAudioController();
            VisualizeVolumeMeter();         
            InitializeConfig();           
        }

        //this method is called when allUsers has been initialized
        private void InitializeUserProfile()
        {
            usersToolStripMenuItem.Text = allUsers.getCurrentUser().getName(true);

            // the administrator account is not advised to change its password
            changePasswordToolStripMenuItem.Visible = !allUsers.currentUserIsAdmin();
            administratorConsoleToolStripMenuItem.Visible = allUsers.currentUserIsAdmin();
        }

        private void InitializeHMMsController()
        {
            // this methods actually load user settings for HMMsController
        }

        private void InitializeConfig()
        {          
            configContent = Serializer<SysCfg>.Load<BinaryFormatter>(SysCfg.path);
            this.systemConfigForm = new SystemConfig();
            this.recordingUploadForm = new RecordingUploadConfig();
            this.recordingRenameForm = new RecordingRenameConfig();
        }

        private void InitializeDB()
        {
            this.DBModel = new MPAidModel();
            this.DBModel.Recording.Load();
            this.DBModel.Speaker.Load();
            this.DBModel.Category.Load();
            this.DBModel.Word.Load();
            this.DBModel.SingleFile.Load();
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

        private void ShowPleaseSelectMsgBox(string objName)
        {
            MessageBox.Show(this, string.Format("Please select a {0}! ", objName),
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }


        private const string strCorrectness = "Correctness";
        private const string strNoWordSelected = "No word has been selected";

        /// <summary>
        /// This number indicates the number of recordings that will be taken from the user for analysis
        /// </summary>
        private int numSamples = 1;

        private void SetPaLabel(string text)
        {
            //labelCorrectness.Text = text;
        }

        private void ResetRecordings()
        {
            recordedWavFiles.Clear();
            //buttonRecord.Enabled = true;
            //buttonLoadFromFile.Enabled = true;
            //buttonAnalyze.Enabled = false;
        }

        private void ResetPAid()
        {
            ResetRecordings();
            //wordSelectedLabel.Text = strNoWordSelected;

            //listBoxREC.Items.Clear();
            listREC.Clear();

            SetPaLabel(strCorrectness);
        }

        private bool RecordingsReady()
        {
            if (recordedWavFiles.Count >= numSamples)
                return true;
            else
                return false;
        }

        private string CurrentVoicePath;

        //private string GetNextUserRecordingName(MaoriObj word)
        //{
        //    string result;

        //    FileMapper fileMapper = new FileMapper(0, word.WordSoundId);
        //    int index = recordedWavFiles.Count + 1;
        //    result = systemIO.GetAppDataDir(allUsers.getCurrentUser())
        //        + fileMapper.GetWordSoundName(index);
        //    return result;
        //}

        private void ShowInExplorer(string dirPath)
        {
            Process explorer = new Process();
            explorer.StartInfo.FileName = "explorer";
            explorer.StartInfo.Arguments = dirPath;
            explorer.Start();
        }

        //private string GetUserScore()
        //{
        //    int total = listREC.Count;
        //    string score = null;
        //    if (total > 0)
        //    {
        //        int i = 0;
        //        MaoriObj m = GetSelectedMaoriObj(MaoriObjType.Word);
        //        foreach (string item in listREC)
        //            if (new Examiner(item, m.Name).wordsMatch())
        //                i += 1;
        //        score = (100 * i / total).ToString();
        //        score += "%";
        //    }
        //    else
        //    {
        //        score = "Unavailable";
        //    }
        //    return score;
        //}

        private void speedController_Scroll(object sender, EventArgs e)
        {
            RefreshAnimationSpeed();
        }

        private void RefreshAnimationSpeed()
        {
            //animationTimer.Interval = DefaultInterval / speedController.Value;
        }

        private string ReportPath = null;

        //private void buttonShowReport_Click(object sender, EventArgs e)
        //{
        //    MaoriObj word = GetSelectedMaoriObj(MaoriObjType.Word);
        //    HtmlConfig hConfig = new HtmlConfig(systemIO.GetAppDataDir(allUsers.getCurrentUser()))
        //    {
        //        myWord = word.Name,
        //        correctnessValue = GetUserScore()
        //    };

        //    if ((listREC != null) && (listREC.Count > 0))
        //        hConfig.listRecognized = listREC.ToList();

        //    HtmlGenerator htmlWriter = new HtmlGenerator(hConfig);
        //    htmlWriter.Run();

        //    // Show the HTML file in system browser
        //    //ReportPath = hConfig.GetHtmlFullPath();
        //    //if (File.Exists(ReportPath))
        //    //    systemIO.ShowInBrowser(ReportPath);
        //    //else
        //    //    buttonShowReport.Enabled = false;
        //}

//        private void buttonLoadFromFile_Click(object sender, EventArgs e)
//        {
//            MaoriObj word = GetSelectedMaoriObj(MaoriObjType.Word);
//            if (word != null)
//            {
//                OpenFileDialog openWavFileDialog = new OpenFileDialog()
//                {
//                    Title = "Please select your wav files",
//                    Filter = "Wave Files|*.wav",
//                    Multiselect = true,
//                    InitialDirectory = ResMan.GetSoundDir()
//                };
//                if (openWavFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
//                {
//                    foreach (string wavFile in openWavFileDialog.FileNames)
//                    {
//                        try
//                        {
//                            CurrentVoicePath = GetNextUserRecordingName(word);
//                            recordedWavFiles.Add(CurrentVoicePath);
//                            ResMan.SuperCopy(wavFile, CurrentVoicePath, true);
//                            if (RecordingsReady())
//                                break;
//                        }
//                        catch { }
//                    }

//                    //CheckIfRecordingsReady();

//                    try
//                    {
//                        DoAnalysis();
//                    }
//                    catch (Exception ex)
//                    {
//#if DEBUG
//                        MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//#endif
//                    }
//                }
//            }
//            else
//                ShowPleaseSelectMsgBox("word");
//        }

        private void wordSelectedLabel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //MaoriObj word = GetSelectedMaoriObj(MaoriObjType.Word);
                //if (word != null)
                //    wordSelectedLabel.Text = string.Format("{0} ({1})",
                //        word.Name, word.WordSoundId);
            }
        }

        private VerticalProgressBar volumeMeter;

        private void VisualizeVolumeMeter()
        {
            //// Make space for the volume meter
            //Width += 25;

            //// Visualize the volume meter
            //volumeMeter = new VerticalProgressBar()
            //{
            //    Size = new Size(20, groupBox3.Height + groupBox4.Height),
            //    Location = new Point(groupBox4.Left + groupBox4.Width + 6,
            //                         groupBox4.Top + mainMenuStrip.Height + headerBox.Height + 6)
            //};

            //Controls.Add(volumeMeter);
            //volumeMeter.BringToFront();
        }

        //private NAudioController volumeMeterController;

        private void InitializeNAudioController()
        {
            //volumeMeterController = new NAudioController();
        }

        private void NAudioTimer_Tick(object sender, EventArgs e)
        {
            //volumeMeter.Value = volumeMeterController.GetValue();
        }

        private void StopNAudioController()
        {
            //NAudioTimer.Stop();
            volumeMeter.Value = 0;
        }

        private bool NAudioFailureShown = false;

        private void StartNAudioController()
        {
            //try
            //{
            //    if (volumeMeterController.StatusOK())
            //        NAudioTimer.Start();
            //}
            //catch (Exception ex)
            //{
            //    if (!NAudioFailureShown)
            //    {
            //        NAudioFailureShown = true;
            //        MessageBox.Show("There is something wrong with the component NAudio.dll. \n" +
            //            "The Volume Meter feature will be disabled. \n"
            //            + ex.Message, "Ooops",
            //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
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
            //systemIO.ShowInExplorer(ResMan.GetAnnieDir());
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

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.test.ShowDialog(this);
        }
    }
}
