﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using NAudio.CoreAudioApi;
using NAudio.Wave;
using MPAi.Models;
using MPAi.Cores;
using MPAi.Cores.Scoreboard;
using MPAi.Forms.MSGBox;
using System.Data.Entity;
using MPAi.Forms.Config;

namespace MPAi.NewForms
{

    public partial class SpeechRecognitionTest : Form, MainFormInterface
    {
        // Strings kept in fields to make text easier to change.
        private string optionsLess = "Less...";
        private string optionsMore = "More...";
        private string playText = "Play";
        private string stopText = "Stop";
        private string recordText = "Record";

        private string dataLinkErrorText = "Database linking error!";
        private string formatErrorText = "A problem was encountered during recording {0}";
        private string couldntDeleteRecordingText = "Could not delete recording";
        private string noCurrentFileText = "No current file";
        private string recordingNotSelectedText = "Please select a recording.";
        private string warningText = "Warning";
        private string noAudioDeviceText = "No audio device plugged in.";

        private string outputFileName;
        private string outputFolder;
        private string tempFilename;
        private string tempFolder;

        // Assign these using user settings, or main menu, depending on implementation.
        Speaker spk = null;
        Category cty = null;

        private IWaveIn waveIn;
        private WaveOutEvent waveOut; 
        private WaveFileWriter writer;
        private WaveFileReader reader;

        private HTKEngine RecEngine = new HTKEngine();
        private MPAiSpeakScoreBoardSession session;
        private NAudioPlayer audioPlayer = new NAudioPlayer();

        private int bottomHeight;

        private bool appClosing = true;

        public NAudioPlayer AudioPlayer
        {
            get { return audioPlayer; }
        }

        /// <summary>
        /// Default constructor. Sets up combo boxes, and creates required directories.
        /// </summary>
        public SpeechRecognitionTest()
        {
            InitializeComponent();
            LoadWasapiDevices();
            CreateDirectory();
            DataBinding();
            populateWordComboBox();
            bottomHeight = SpeechRecognitionTestPanel.Height - SpeechRecognitionTestPanel.SplitterDistance;
            toggleOptions();    // For development, the bottom panel is visible, but the user won't need the bottom panel most of the time.
            toggleListButtons(RecordingListBox.SelectedItems.Count > 0);
            session = UserManagement.CurrentUser.SpeakScoreboard.NewScoreBoardSession();
        }

        /// <summary>
        /// Gets the words from the database.
        /// </summary>
        private void populateWordComboBox()
        {
            try
            {
                // Create new database context.
                using (MPAiModel DBModel = new MPAiModel())
                {
                    DBModel.Database.Initialize(false); // Added for safety; if the database has not been initialised, initialise it.

                    MPAiUser current = UserManagement.CurrentUser;

                    List<Word> view = DBModel.Word.Where(x => (
                       x.Category.Name.Equals("Word")
                       && x.Recordings.Any(y =>y.Speaker.SpeakerId == current.Speaker.SpeakerId) 
                       )).ToList();

                    view.Sort(new VowelComparer());
                    WordComboBox.DataSource = new BindingSource() { DataSource = view };
                    WordComboBox.DisplayMember = "Name";
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        /// <summary>
        /// If the recordings folder doesn't already exist, creates it.
        /// Creates a temporary directory,to be used for recording purposes. 
        /// </summary>
        public void CreateDirectory()
        {
            outputFolder = DirectoryManagement.RecordingFolder;
            tempFolder = AppDataPath.Temp;
            Directory.CreateDirectory(outputFolder);
        }

        /// <summary>
        /// Gets all the audio input devices attached to the system, converts them to a list, and populates the audio device combo box.
        /// </summary>
        public void LoadWasapiDevices()
        {
            var deviceEnum = new MMDeviceEnumerator();
            var devices = deviceEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active).ToList();

            AudioInputDeviceComboBox.DataSource = devices.Count == 0 ? null : devices;
            AudioInputDeviceComboBox.DisplayMember = "FriendlyName";
        }

        /// <summary>
        /// Clears the list box that holds all the recordings, and repopulates it with all valid recordings in the recordings directory.
        /// Used for initialisation and to refresh values.
        /// </summary>
        public void DataBinding()
        {
            RecordingListBox.Items.Clear();
            DirectoryInfo info = new DirectoryInfo(DirectoryManagement.RecordingFolder);
            RecordingListBox.Items.AddRange(info.GetFiles().Where(x => x.Extension != ".mfc" && x.Name.EndsWith(".wav")).Select(x => x.Name).ToArray());
            toggleListButtons(RecordingListBox.Items.Count > 0);
        }

        /// <summary>
        /// Event to handle audio buffering and updating of the progress bar.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            if (InvokeRequired) // If it is necessary to invoke this method on a separate thread
            {
                BeginInvoke(new EventHandler<WaveInEventArgs>(OnDataAvailable), sender, e); // Send this event to the relevant thread.
            }
            else
            {
                if (recordButton.Text.Equals(recordText))
                {
                    return;
                }
                writer.Write(e.Buffer, 0, e.BytesRecorded); // Record audio into a buffer
                int secondsRecorded = (int)(writer.Length / writer.WaveFormat.AverageBytesPerSecond);
                recordingProgressBar.Value = secondsRecorded * 10;  // Increase the progress bar
                if (secondsRecorded >= 10)
                {
                    StopRecording(); // If we have recorded more than 10s of audio then stop recording
                }    
            }
        }

        /// <summary>
        /// Tidies up the stream after a wave file has been played or recorded.
        /// </summary>
        /// <param name="s">The stream to dispose of.</param>
        private void FinalizeWaveFile(Stream s)
        {
            if (s != null)
            {
                s.Dispose();
                s = null;
            }
        }

        /// <summary>
        /// Handles the state of the buttons based on whether or not the user is recording.
        /// </summary>
        /// <param name="isRecording"></param>
        private void SetControlStates(bool isRecording)
        {
            recordButton.Text = isRecording ? stopText : recordText;
            playButton.Enabled = !isRecording;
            analyzeButton.Enabled = !isRecording;
            recordingProgressBar.Visible = isRecording;
            recordingProgressBarLabel.Visible = !isRecording;
            SpeechRecognitionTestPanel.Panel2.Enabled = !isRecording;
        }

        /// <summary>
        /// If a file is being recorded, stop recording and tidy up the stream.
        /// </summary>
        private void StopRecording()
        {
            recordButton.Text = recordText;
            waveIn.DataAvailable -= OnDataAvailable;
            if (waveIn != null)
            {
                waveIn.StopRecording();
            }
            FinalizeWaveFile(writer);
        }

        /// <summary>
        /// If a file is being played, stop playback and tidy up the stream.
        /// </summary>
        private void StopPlay()
        {
            AudioPlayer.Stop();
            FinalizeWaveFile(reader);
        }

        /// <summary>
        /// Converts the temporary file created by recording into the format used by the recording files.
        /// </summary>
        private void Resample()
        {
            try
            {
                using (var reader = new WaveFileReader(Path.Combine(tempFolder, tempFilename))) // Read audio out of a temporary file in the temporary folder.
                {
                    var outFormat = new WaveFormat(16000, reader.WaveFormat.Channels);      // Define the output format of the audio
                    // Create the sampler that interprets the audio file into the format use the resampler to create the .wav file in the recordings directory.
                    using (var resampler = new MediaFoundationResampler(reader, outFormat))
                    {
                        WaveFileWriter.CreateWaveFile(Path.Combine(outputFolder, outputFileName), resampler);
                    }
                }
                File.Delete(Path.Combine(tempFolder, tempFilename));    // Delete the temporary file.
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        /// <summary>
        /// Functionality to tidy up when recording has stopped.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            if (InvokeRequired) // If it is necessary to invoke this on a different thread
            {
                BeginInvoke(new EventHandler<StoppedEventArgs>(OnRecordingStopped), sender, e); // Send this event to the relevant thread
            }
            else
            {
                Resample();
                if (e.Exception != null)
                {
                    MessageBox.Show(String.Format(formatErrorText, e.Exception.Message));
                }
                SetControlStates(false);    // Toggle the record and stop buttons
                recordingProgressBarLabel.Text = outputFileName;
                int newItemIndex = RecordingListBox.Items.Add(outputFileName);    // Add the new audio file to the list box
                RecordingListBox.SelectedIndex = newItemIndex;    // And select it
            }
        }

        /// <summary>
        /// Functionality for the "More" and "Less" buttons.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void optionsButton_Click(object sender, EventArgs e)
        {
            toggleOptions();
        }

        /// <summary>
        /// Shows/hides the options panel, changes button text, and resizes the form as appropriate.
        /// </summary>
        private void toggleOptions()
        {
            if (SpeechRecognitionTestPanel.Panel2Collapsed)
            {
                Height += bottomHeight;
                MinimumSize = new Size(MinimumSize.Width, 600);
                optionsButton.Text = optionsLess;
            }
            else
            {
                MinimumSize = new Size(MinimumSize.Width, 300);
                bottomHeight = SpeechRecognitionTestPanel.Height - SpeechRecognitionTestPanel.SplitterDistance;
                Height -= bottomHeight;
                optionsButton.Text = optionsMore;
            }
            SpeechRecognitionTestPanel.Panel2Collapsed = !SpeechRecognitionTestPanel.Panel2Collapsed;
        }

        /// <summary>
        /// Functionality for the refresh devices button.
        /// Reloads any attached devices into the combo box, and refreshes it's value.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void AudioInputDeviceButton_Click(object sender, EventArgs e)
        {
            LoadWasapiDevices();
            DataBinding();
        }

        /// <summary>
        /// Functionality for the delete button.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteFile();
        }

        /// <summary>
        /// Deletes the file selected in the list box from the user's computer.
        /// </summary>
        void DeleteFile()
        {
            if (RecordingListBox.SelectedItem != null)
            {
                try
                {
                    StopRecording();
                    StopPlay();
                    File.Delete(Path.Combine(outputFolder, (string)RecordingListBox.SelectedItem));
                    if (recordingProgressBarLabel.Text.Equals((string)RecordingListBox.SelectedItem))
                    {
                        recordingProgressBarLabel.Text = noCurrentFileText;
                    }
                    RecordingListBox.Items.Remove(RecordingListBox.SelectedItem);
                    if (RecordingListBox.Items.Count > 0)
                    {
                        RecordingListBox.SelectedIndex = RecordingListBox.Items.Count - 1;
                    }                   
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp);
                    MessageBox.Show(couldntDeleteRecordingText);
                }
            }
            else
            {
                MessageBox.Show(recordingNotSelectedText);
            }
            // If no items remain, disable buttons relating to them.
            if (RecordingListBox.Items.Count < 1)
            {
                toggleListButtons(false);
            }
        }

        /// <summary>
        /// Functionality for the Analyse button.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void analyzeButton_Click(object sender, EventArgs e)
        {
            analyse();
        }

        /// <summary>
        /// Passes the selected item to the speech recognition software.
        /// </summary>
        void analyse()
        {
            try
            {
                if (!recordingProgressBarLabel.Text.Equals(noCurrentFileText))
                {
                    string target = ((WordComboBox.SelectedItem as Word) == null) ? string.Empty : (WordComboBox.SelectedItem as Word).Name;
                    Dictionary<string, string> result = RecEngine.Recognize(Path.Combine(outputFolder, recordingProgressBarLabel.Text)).ToDictionary(x => x.Key, x => x.Value);
                    //result.Add("Recording File Name", "hoihoi");
                    if (result.Count > 0)
                    {
                        MPAiSpeakScoreBoardItem item = new MPAiSpeakScoreBoardItem(target, result.First().Value, PronuciationAdvisor.Advise(result.First().Key, target, result.First().Value));
                        session.Content.Add(item);

                        AnalysisScreen analysisScreen = new AnalysisScreen(item.Similarity, item.Analysis);
                        analysisScreen.ShowDialog(this);
                    }
                }
            }
            catch (Exception exp)
            {
#if DEBUG
                MessageBox.Show(exp.Message, warningText, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
#endif
            }
        }

        /// <summary>
        /// Functionality for the Show Report button.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void ScoreReportButton_Click(object sender, EventArgs e)
        {
            generateReport();
        }

        /// <summary>
        /// Uses the Report Launcher to create the scoreboard, and launches it in a browser for the user.
        /// </summary>
        void generateReport()
        {
        ReportLauncher.GenerateMPAiSpeakScoreHTML(UserManagement.CurrentUser.SpeakScoreboard);
            if (File.Exists(ReportLauncher.MPAiSpeakScoreReportHTMLAddress))
            {
                ReportLauncher.ShowMPAiSpeakScoreReport();
            }
        }

        /// <summary>
        /// Functionality for play button. Plays the selected audio file.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void playButton_Click(object sender, EventArgs e)
        {
            if (playButton.Text.Equals(playText))
            {
                AudioPlayer.Play(Path.Combine(outputFolder, recordingProgressBarLabel.Text));               
                AudioPlayer.WaveOut.PlaybackStopped += playButton_Click;    // Subscribe to playback stopped.
                playButton.Text = stopText;
            }
            else    // It must equal "Stop" if not "Play"
            {
                AudioPlayer.WaveOut.PlaybackStopped -= playButton_Click;    // Unsubscribe from playback stopped.
                StopPlay();
                playButton.Text = playText;
            }
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void backButton_Click(object sender, EventArgs e)
        {
            new MPAiSpeakMainMenu().Show();
            closeThis();
        }

        /// <summary>
        /// Closes the form, but not the application.
        /// </summary>
        public void closeThis()
        {
            appClosing = false; // Tell the FormClosing event not to end the program.
            Close();
        }

        /// <summary>
        /// Updates the value in the analysis label.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void SelectButton_Click(object sender, EventArgs e)
        {
            recordingProgressBarLabel.Text = RecordingListBox.GetItemText(RecordingListBox.SelectedItem);
        }

        /// <summary>
        /// Disables or enables the buttons relating to the list of recordings.
        /// </summary>
        /// <param name="enable">Whether to enable (true) or disable (false) the buttons.</param>
        private void toggleListButtons(bool enable)
        {
            SelectButton.Enabled = enable;
            DeleteButton.Enabled = enable;
            RenameButton.Enabled = enable;
        }

        /// <summary>
        /// Disables or enables the buttons relating to the current recording.
        /// </summary>
        /// <param name="enable">Whether to enable (true) or disable (false) the buttons.</param>
        private void toggleRecordingButtons(bool enable)
        {
            playButton.Enabled = enable;
            analyzeButton.Enabled = enable;
        }

        /// <summary>
        /// Handles changing buttons based on the curent recording.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void recordingProgressBarLabel_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(recordingProgressBarLabel.Text))
            {
                recordingProgressBarLabel.Text = noCurrentFileText;
            }
            toggleRecordingButtons(!recordingProgressBarLabel.Text.Equals(noCurrentFileText));
        }

        /// <summary>
        /// Handles functionality of the record/stop button, calling appropriate methods and changing it's text.
        /// As there is no global isRecording field, and such a field would interfere with existing code, the button text is used as the recording status.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void recordButton_Click(object sender, EventArgs e)
        {
            if (recordButton.Text.Equals(recordText))
            {
                record();
            }
            else
            {
                StopRecording();
                StopPlay();
            }           
        }

        /// <summary>
        /// Sets up the audio device, and the file to record into, adds listeners to the events, starts recording, and toggles the buttons.
        /// </summary>
        private void record()
        {
            try
            {
                var device = (MMDevice)AudioInputDeviceComboBox.SelectedItem;
                if (!(device == null))
                {

                    recordButton.Text = stopText;
                    recordingProgressBar.Value = 0;

                    device.AudioEndpointVolume.Mute = false;
                    // Use wasapi by default
                    waveIn = new WasapiCapture(device);
                    waveIn.DataAvailable += OnDataAvailable;
                    waveIn.RecordingStopped += OnRecordingStopped;

                    tempFilename = String.Format("{0}-{1:yyy-MM-dd-HH-mm-ss}.wav", UserManagement.CurrentUser.getName(), DateTime.Now);
                    // Initially, outputname is the same as tempfilename
                    outputFileName = tempFilename;
                    writer = new WaveFileWriter(Path.Combine(tempFolder, tempFilename), waveIn.WaveFormat);
                    waveIn.StartRecording();
                    SetControlStates(true);
                }
                else
                {
                    recordButton.Text = recordText;
                    MessageBox.Show(noAudioDeviceText,
                    warningText, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exp)
            {
#if DEBUG
                MessageBox.Show(exp.Message, warningText, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
#endif
            }
        }

        /// <summary>
        /// Functionality for Add button.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            add();
            
        }

        /// <summary>
        /// Opens a file picker, then for each file picked by the user, prompts them to rename the file, and places it in the recording list.
        /// </summary>
        private void add()
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string f in openFileDialog.FileNames)
                    {
                        File.Copy(f, Path.Combine(tempFolder, "Rename_Backup"));    // Back up file
                        using (RenameFileDialog renameDialog = new RenameFileDialog(f))
                        {
                            if (renameDialog.ShowDialog() == DialogResult.OK)
                            {
                                // Rename file
                                File.Move(renameDialog.RenamedFile.FullName, Path.Combine(outputFolder, renameDialog.RenamedFile.Name)); // Move renamed file into recording directory
                                File.Move(Path.Combine(tempFolder, "Rename_Backup"), f); // Restore old file from backup.
                            }
                        }
                    }
                    DataBinding();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.StackTrace);

            }
            finally
            {
                File.Delete(Path.Combine(tempFolder, "Rename_Backup"));    // Delete temp file.
            }
        }

        /// <summary>
        /// Functionality for the Rename button.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void RenameButton_Click(object sender, EventArgs e)
        {
            rename();
        }

        /// <summary>
        /// Shows the Rename File Dialog box to allow the user to rename a file.
        /// </summary>
        private void rename()
        {
            using (RenameFileDialog renameDialog = new RenameFileDialog(Path.Combine(Properties.Settings.Default.RecordingFolder, RecordingListBox.GetItemText(RecordingListBox.SelectedItem))))
            {
                if (renameDialog.ShowDialog() == DialogResult.OK)
                {
                    if (RecordingListBox.GetItemText(RecordingListBox.SelectedItem).Equals(recordingProgressBarLabel.Text))
                    {
                        recordingProgressBarLabel.Text = renameDialog.RenamedFile.Name;
                    }
                    DataBinding();
                }
            }
        }

        /// <summary>
        /// Prevents two lists appearing onscreen at once by closing the main list when the suggestion list is visible.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void WordComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            WordComboBox.DroppedDown = false;
        }

        /// <summary>
        /// If no recording is selected, disable the buttons that depend on the selected recording.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void RecordingListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            toggleListButtons(RecordingListBox.SelectedItems.Count > 0);
        }

        /// <summary>
        /// Fires when the form closes. 
        /// If the user pressed the back button, the next form will be loaded. 
        /// If the user closed the form in some other way, the app will temrinate.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void SpeechRecognitionTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopPlay(); // The audio player runs threads in the background. To prevent them running after the form closes, call stop on close.

            if (appClosing)
            {
                UserManagement.WriteSettings();
                Properties.Settings.Default.Save();
                Application.Exit();
            }
        }
    }
}
