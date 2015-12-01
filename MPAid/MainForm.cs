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
using MPAid.Modules;
using MPAid.Models;
using System.Data.Entity;

namespace MPAid
{
    public partial class MainForm : Form
    {
        public static MainForm self;
        private ResManager ResMan;
        private UserManagement allUsers;
        private IoController systemIO;

        private Thread AsyncPlayer;
        private string CurrentSoundPath = null;

        private int CurrentNumPlayback = 1;
        private int CurrentSoundId = 0;
        private int CurrentAudioSource = 0;
        private int DefaultInterval = 200;

        private List<string> recordedWavFiles = new List<string>();
        private BindingList<string> listREC = new BindingList<string>();

        private LoginWindow loginForm;

        private SystemConfig systemConfigForm;

        private RecordingConfig recordingConfigForm;

        public SysCfg configContent;

        public MPAidModel DBModel;

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

            ResMan = new ResManager();
            systemIO = new IoController();
            //myUsers = new UserManagement(ResMan.GetUserTempPath());

            InitializeUserProfile();

            tdButtonFormantPlot.ImageNormal = Properties.Resources.ButtonYellow_0;
            tdButtonFormantPlot.ImageHighlight = Properties.Resources.ButtonYellow_1;
            tdButtonFormantPlot.ImagePressed = Properties.Resources.ButtonYellow_2;

            ButtonPlay.ImageNormal = Properties.Resources.ButtonGreen_0;
            ButtonPlay.ImageHighlight = Properties.Resources.ButtonGreen_1;
            ButtonPlay.ImagePressed = Properties.Resources.ButtonGreen_2;

            ButtonStop.ImageNormal = Properties.Resources.ButtonRed_0;
            ButtonStop.ImageHighlight = Properties.Resources.ButtonRed_1;
            ButtonStop.ImagePressed = Properties.Resources.ButtonRed_2;

            RefreshTabState();
            ResetPreviewBox();
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
            this.recordingConfigForm = new RecordingConfig();
        }

        private void InitializeDB()
        {
            this.DBModel = new MPAidModel();
            this.DBModel.Recording.Load();
            this.DBModel.Speaker.Load();
        }

        private void FillLists()
        {
            //VowelList.DataSource = DBModel.Recording.Local.ToBindingList();
            //VowelList.DisplayMember = "Name";
            VowelList.DataSource = ResMan.GetVowelList();
            WordList.DataSource = ResMan.GetWordList();
            listBoxREC.DataSource = listREC;
        }

        private string GetVersionString()
        {
            return ("[Version " + Application.ProductVersion + "]");
        }

        private void tdButtonFormantPlot_Click(object sender, EventArgs e)
        {
            tdButtonFormantPlot.Enabled = false;
            this.WindowState = FormWindowState.Minimized;

            // Start formant plot
            FormantPlotController.RunFormantPlot();

            tdButtonFormantPlot.Enabled = true;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopSoundPlayer();
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

        private enum MaoriObjType
        {
            Vowel = 0,
            Word = 1
        }

        private MaoriObj GetSelectedMaoriObj(MaoriObjType source)
        {
            if (source == MaoriObjType.Vowel)
                return (MaoriObj)(VowelList.SelectedItem);
            if (source == MaoriObjType.Word)
                return (MaoriObj)(WordList.SelectedItem);
            return null;
        }

        private void ShowPleaseSelectMsgBox(string objName)
        {
            MessageBox.Show(this, string.Format("Please select a {0}! ", objName),
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            if (GetTabState() == 0)
            {
                MaoriObj m = GetSelectedMaoriObj(MaoriObjType.Vowel);
                if (m != null)
                {
                    if (CanPlayAnimation(m))
                        StartAnimation();
                    PlayVowelSoundAsync(m.SoundFilePath, (int)NumPlayback.Value);
                }
                else
                    ShowPleaseSelectMsgBox("vowel");
            }

            if (GetTabState() == 1)
            {
                MaoriObj m = GetSelectedMaoriObj(MaoriObjType.Word);
                if (m != null)
                    PlayWordSoundAsync(GetAudioSource(), m.WordSoundId, (int)NumPlayback.Value);
                else
                    ShowPleaseSelectMsgBox("word");
            }
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            StopSoundPlayer();
        }

        private void StopSoundPlayer()
        {
            if (AsyncPlayer != null)
                AsyncPlayer.Abort();
        }

        private void PlayWordSoundAsync(int AudioSourceId, int SoundId, int nPlayback)
        {
            StopSoundPlayer();
            AsyncPlayer = new Thread(ThreadPlayWordSound);
            CurrentAudioSource = AudioSourceId;
            CurrentSoundId = SoundId;
            CurrentNumPlayback = nPlayback;
            AsyncPlayer.Start();
        }

        private string lastPlayedSound = null;

        private void ThreadPlayWordSound()
        {
            int i = 0, j = 0, lower = 0, upper = 0;

            List<string> filesPlayed = new List<string>();
            List<string> CurrentPlayList = ResMan.GetWordSoundList(CurrentAudioSource, CurrentSoundId);

            if ((CurrentPlayList == null)
                || (CurrentPlayList.Count == 0))
                return;

            lastPlayedSound = null;

            while (i < CurrentNumPlayback)
            {
                upper = CurrentPlayList.Count - 1;
                j = mathLib.RndInt(lower, upper);
                CurrentSoundPath = CurrentPlayList[j];

                if ((!filesPlayed.Contains(CurrentSoundPath))
                    && (lastPlayedSound != CurrentSoundPath))
                {
                    ResMan.PlaySound(CurrentSoundPath, true);

                    filesPlayed.Add(CurrentSoundPath);
                    lastPlayedSound = CurrentSoundPath;
                    i += 1;

                    if (filesPlayed.Count == CurrentPlayList.Count)
                        filesPlayed = new List<string>();

                    if (i < CurrentNumPlayback)
                        Thread.Sleep(GetAudioInterval());
                }
            }
        }

        private void PlayVowelSoundAsync(string SoundPath, int nPlayBack)
        {
            StopSoundPlayer();
            AsyncPlayer = new Thread(ThreadPlayVowelSound);
            CurrentSoundPath = SoundPath;
            CurrentNumPlayback = nPlayBack;
            AsyncPlayer.Start();
        }

        private void ThreadPlayVowelSound()
        {
            if (!File.Exists(CurrentSoundPath))
            {
                MessageBox.Show("Sound file doesn't exist! \n" + CurrentSoundPath,
                  Application.ProductName,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Warning);
                return;
            }

            for (int i = 1; i <= CurrentNumPlayback; i++)
            {
                ResMan.PlaySound(CurrentSoundPath, true);

                if (i < CurrentNumPlayback)
                    Thread.Sleep(GetAudioInterval());
            }
        }

        ///<summary>
        ///This function returns the state of the tab,
        ///Vowels as 0, Word as 1.
        ///</summary>
        private int GetTabState()
        {
            return myTabControl.SelectedIndex;
        }

        ///<summary>
        ///This function returns the audio source id,
        ///Female as 0, Senior Male as 1, Young Male as 2.
        ///</summary>
        private int GetAudioSource()
        {
            if (radioFemale.Checked)
                return 0;
            if (radioOldMale.Checked)
                return 1;
            if (radioYoungMale.Checked)
                return 2;
            if (radioYoungFemale.Checked)
                return 3;
            return 0;
        }

        private void RefreshTabState()
        {
            if (GetTabState() == 0)
            {
                groupBox3.Enabled = false;
                panel2.Enabled = true;
                ResetPAid();
            }
            if (GetTabState() == 1)
            {
                groupBox3.Enabled = true;
                panel2.Enabled = false;
                RefreshPAid();
            }
        }

        private void myTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTabState();
            ResetAll();
        }

        private void ResetPreviewBox()
        {
            previewBox.BackgroundImage = previewBox.InitialImage;
        }

        private void RefreshPreviewBox()
        {
            if (GetTabState() == 1)
            {
                ResetPreviewBox();
                return;
            }
            if (GetTabState() == 0)
            {
                MaoriObj m = GetSelectedMaoriObj(MaoriObjType.Vowel);
                if ((m != null) && (m.DefaultImage != null))
                    previewBox.BackgroundImage = m.DefaultImage;
                else if ((m != null) && (m.AnimationImages != null))
                    previewBox.BackgroundImage = m.AnimationImages.Images[0];
                else
                    ResetPreviewBox();
            }
        }

        private void VowelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void ResetAll()
        {
            StopSoundPlayer();
            ResetAnimator();
            RefreshPreviewBox();
        }

        private void AudioDelay_ValueChanged(object sender, EventArgs e)
        {
            SetAudioInterval((int)AudioDelay.Value);
        }

        private int AudioInterval = 1000;

        private int GetAudioInterval()
        {
            return AudioInterval;
        }

        private void SetAudioInterval(int newValue)
        {
            AudioInterval = newValue;
        }

        private bool CanPlayAnimation(MaoriObj currentMaoriObj)
        {
            if (currentMaoriObj != null)
                return (currentMaoriObj.AnimationImages != null);
            else
                return false;
        }

        private void ResetAnimator()
        {
            animationTotalFrames = 0;
            animationCurrentFrame = 0;
            animationCurrentPlay = null;
            animationTimer.Stop();
        }

        private int animationTotalFrames = 0;
        private int animationCurrentFrame = 0;
        private MaoriObj animationCurrentPlay = null;

        private void StartAnimation()
        {
            if (GetTabState() == 0)
            {
                MaoriObj m = GetSelectedMaoriObj(MaoriObjType.Vowel);
                if (m != null)
                {
                    animationCurrentPlay = m;
                    animationCurrentFrame = 0;
                    animationTotalFrames = m.AnimationImages.Images.Count;
                    animationTimer.Start();
                }
            }
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            if (GetTabState() == 0)
            {
                previewBox.BackgroundImage = animationCurrentPlay.AnimationImages.Images[animationCurrentFrame];
                animationCurrentFrame += 1;
                if (animationCurrentFrame == animationTotalFrames)
                    ResetAnimator();
            }
            else
            {
                ResetAnimator();
            }
        }

        private const string strCorrectness = "Correctness";
        private const string strNoWordSelected = "No word has been selected";

        /// <summary>
        /// This number indicates the number of recordings that will be taken from the user for analysis
        /// </summary>
        private int numSamples = 1;

        private void SetPaLabel(string text)
        {
            labelCorrectness.Text = text;
        }

        private void ResetRecordings()
        {
            recordedWavFiles.Clear();
            buttonRecord.Enabled = true;
            buttonLoadFromFile.Enabled = true;
            //buttonAnalyze.Enabled = false;
        }

        private void ResetPAid()
        {
            ResetRecordings();
            wordSelectedLabel.Text = strNoWordSelected;

            //listBoxREC.Items.Clear();
            listREC.Clear();

            SetPaLabel(strCorrectness);
        }

        private void RefreshPAid()
        {
            MaoriObj m = GetSelectedMaoriObj(MaoriObjType.Word);
            if (m != null)
                wordSelectedLabel.Text = m.Name;
        }

        private bool RecordingsReady()
        {
            if (recordedWavFiles.Count >= numSamples)
                return true;
            else
                return false;
        }

        private void WordList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetPAid();
            RefreshPAid();
        }

        private string CurrentVoicePath;
        private VoiceRecorder myVoice;

        private void buttonRecord_Click(object sender, EventArgs e)
        {
            MaoriObj word = GetSelectedMaoriObj(MaoriObjType.Word);
            if (word != null)
            {
                SetPaLabel(strCorrectness);
                buttonRecord.Enabled = false;
                buttonLoadFromFile.Enabled = false;
                //buttonAnalyze.Enabled = false;

                CurrentVoicePath = GetNextUserRecordingName(word);

                // Start the Volume Meter and recorder
                StartNAudioController();
                myVoice = new VoiceRecorder(CurrentVoicePath);
                myVoice.Start();

                buttonStopRecording.Enabled = true;
            }
            else
                ShowPleaseSelectMsgBox("word");
        }

        private string GetNextUserRecordingName(MaoriObj word)
        {
            string result;

            FileMapper fileMapper = new FileMapper(0, word.WordSoundId);
            int index = recordedWavFiles.Count + 1;
            result = systemIO.GetAppDataDir(allUsers.getCurrentUser())
                + fileMapper.GetWordSoundName(index);
            return result;
        }

        private void buttonStopRecording_Click(object sender, EventArgs e)
        {
            // Stop recording and stop the time for the Volume Meter
            myVoice.StopAndSave();
            StopNAudioController();

            if (File.Exists(CurrentVoicePath))
                recordedWavFiles.Add(CurrentVoicePath);

            buttonRecord.Enabled = true;
            buttonLoadFromFile.Enabled = true;
            buttonStopRecording.Enabled = false;

            try
            {
                DoAnalysis();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
#endif
            }
        }

        private void CheckIfRecordingsReady()
        {
            if (RecordingsReady())
            {
                buttonAnalyze.Enabled = true;
                buttonRecord.Enabled = false;
                buttonLoadFromFile.Enabled = false;
                SetPaLabel("Please click on Analyze");
            }
            else
                SetPaLabel("One more time :) ");
        }

        private void buttonPlayUserRecording_Click(object sender, EventArgs e)
        {
            HtmlConfig fileLocator = new HtmlConfig(systemIO.GetAppDataDir(allUsers.getCurrentUser()));
            if (listBoxREC.Items.Count == 0)
                return;
            if (listBoxREC.SelectedItem == null)
                return;
            string targetSoundPath = fileLocator.GetRecPath(listBoxREC.SelectedIndex + 1,
                HtmlConfig.pathType.fullUserRecPath);
            if (File.Exists(targetSoundPath))
                ResMan.PlaySound(targetSoundPath, false);
        }

        private void ShowInExplorer(string dirPath)
        {
            Process explorer = new Process();
            explorer.StartInfo.FileName = "explorer";
            explorer.StartInfo.Arguments = dirPath;
            explorer.Start();
        }

        private void RefreshListRecBox()
        {
            listBoxREC.SelectedIndex = listBoxREC.Items.Count - 1;
        }

        private void DoAnalysis()
        {
            MaoriObj word = GetSelectedMaoriObj(MaoriObjType.Word);

            PaConfig config = new PaConfig()
            {
                currentWord = word.Name,
                AnnieDir = ResMan.GetAnnieDir(),
                batFilePath = ResMan.GetAnnieDir() + "\\Process.bat",
                audioList = recordedWavFiles
            };

            PaEngine engine = new PaEngine(config);
            if (engine.wavFilesOK())
            {
                // The Main thread will wait until the process finishes
                engine.Start();

                //listBoxREC.Items.Add(engine.GetRecognizedWord());
                listREC.Add(engine.GetRecognizedWord());
                RefreshListRecBox();

                //copies the user recording files to the HTML report resource folder
                HtmlConfig hConfig = new HtmlConfig(systemIO.GetAppDataDir(allUsers.getCurrentUser()));
                ResMan.SuperCopy(CurrentVoicePath,
                          hConfig.GetRecPath(listREC.Count,
                          HtmlConfig.pathType.fullUserRecPath), true);

                //prepare to copy the sample recording file to the HTML report res folder

                //make sure the sample recording is different from each other
                string soundToPlay = null;
                int counter = 0;
                do
                {
                    counter += 1;
                    soundToPlay = ResMan.GetWordSound(GetAudioSource(), word.WordSoundId, true);
                    if (soundToPlay == null)
                        break;
                } while ((soundToPlay == lastPlayedSound) && (counter < 255));

                lastPlayedSound = soundToPlay;

                //copies the sample recording files to the HTML res folder
                ResMan.SuperCopy(soundToPlay, hConfig.GetRecPath(listREC.Count,
                    HtmlConfig.pathType.fullSampleRecPath), true);

                //change the UI
                buttonShowReport.Enabled = true;
                ReportPath = engine.GetReportPath();
            }

            ResetRecordings();
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            SetPaLabel(string.Format("{0} = {1}", strCorrectness, GetUserScore()));
        }

        private string GetUserScore()
        {
            int total = listREC.Count;
            string score = null;
            if (total > 0)
            {
                int i = 0;
                MaoriObj m = GetSelectedMaoriObj(MaoriObjType.Word);
                foreach (string item in listREC)
                    if (new Examiner(item, m.Name).wordsMatch())
                        i += 1;
                score = (100 * i / total).ToString();
                score += "%";
            }
            else
            {
                score = "Unavailable";
            }
            return score;
        }

        private void speedController_Scroll(object sender, EventArgs e)
        {
            RefreshAnimationSpeed();
        }

        private void RefreshAnimationSpeed()
        {
            animationTimer.Interval = DefaultInterval / speedController.Value;
        }

        private string ReportPath = null;

        private void buttonShowReport_Click(object sender, EventArgs e)
        {
            MaoriObj word = GetSelectedMaoriObj(MaoriObjType.Word);
            HtmlConfig hConfig = new HtmlConfig(systemIO.GetAppDataDir(allUsers.getCurrentUser()))
            {
                myWord = word.Name,
                correctnessValue = GetUserScore()
            };

            if ((listREC != null) && (listREC.Count > 0))
                hConfig.listRecognized = listREC.ToList();

            HtmlGenerator htmlWriter = new HtmlGenerator(hConfig);
            htmlWriter.Run();

            // Show the HTML file in system browser
            ReportPath = hConfig.GetHtmlFullPath();
            if (File.Exists(ReportPath))
                systemIO.ShowInBrowser(ReportPath);
            else
                buttonShowReport.Enabled = false;
        }

        private void buttonLoadFromFile_Click(object sender, EventArgs e)
        {
            MaoriObj word = GetSelectedMaoriObj(MaoriObjType.Word);
            if (word != null)
            {
                OpenFileDialog openWavFileDialog = new OpenFileDialog()
                {
                    Title = "Please select your wav files",
                    Filter = "Wave Files|*.wav",
                    Multiselect = true,
                    InitialDirectory = ResMan.GetSoundDir()
                };
                if (openWavFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (string wavFile in openWavFileDialog.FileNames)
                    {
                        try
                        {
                            CurrentVoicePath = GetNextUserRecordingName(word);
                            recordedWavFiles.Add(CurrentVoicePath);
                            ResMan.SuperCopy(wavFile, CurrentVoicePath, true);
                            if (RecordingsReady())
                                break;
                        }
                        catch { }
                    }

                    //CheckIfRecordingsReady();

                    try
                    {
                        DoAnalysis();
                    }
                    catch (Exception ex)
                    {
#if DEBUG
                        MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
#endif
                    }
                }
            }
            else
                ShowPleaseSelectMsgBox("word");
        }

        private void wordSelectedLabel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MaoriObj word = GetSelectedMaoriObj(MaoriObjType.Word);
                if (word != null)
                    wordSelectedLabel.Text = string.Format("{0} ({1})",
                        word.Name, word.WordSoundId);
            }
        }

        private VerticalProgressBar volumeMeter;

        private void VisualizeVolumeMeter()
        {
            // Make space for the volume meter
            Width += 25;

            // Visualize the volume meter
            volumeMeter = new VerticalProgressBar()
            {
                Size = new Size(20, groupBox3.Height + groupBox4.Height),
                Location = new Point(groupBox4.Left + groupBox4.Width + 6,
                                     groupBox4.Top + mainMenuStrip.Height + headerBox.Height + 6)
            };

            Controls.Add(volumeMeter);
            volumeMeter.BringToFront();
        }

        private NAudioController volumeMeterController;

        private void InitializeNAudioController()
        {
            volumeMeterController = new NAudioController();
        }

        private void NAudioTimer_Tick(object sender, EventArgs e)
        {
            volumeMeter.Value = volumeMeterController.GetValue();
        }

        private void StopNAudioController()
        {
            NAudioTimer.Stop();
            volumeMeter.Value = 0;
        }

        private bool NAudioFailureShown = false;

        private void StartNAudioController()
        {
            try
            {
                if (volumeMeterController.StatusOK())
                    NAudioTimer.Start();
            }
            catch (Exception ex)
            {
                if (!NAudioFailureShown)
                {
                    NAudioFailureShown = true;
                    MessageBox.Show("There is something wrong with the component NAudio.dll. \n" +
                        "The Volume Meter feature will be disabled. \n"
                        + ex.Message, "Ooops",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HMMsConfigForm hmmsConfig = new HMMsConfigForm();
            hmmsConfig.SetWorkingFolder(ResMan.GetAnnieDir());
            hmmsConfig.ShowDialog();
            HMMsController.SetHMMsValue(hmmsConfig.GetHMMsValue());
        }

        private void openHMMsFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            systemIO.ShowInExplorer(ResMan.GetAnnieDir());
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

        private void recordingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.recordingConfigForm.ShowDialog(this);
        }
    }
}
