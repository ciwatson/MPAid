using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.IO;
using System.Diagnostics;
using MPAid.Models;
using MPAid.Cores;
using MPAid.Forms.MSGBox;

namespace MPAid.UserControls
{
    public partial class NAudioRecorder : UserControl
    {
        private IWaveIn waveIn;
        private WaveOutEvent waveOut = new WaveOutEvent();
        private WaveFileWriter writer;
        private WaveFileReader reader;
        private string outputFileName;
        private string outputFolder;
        private string tempFilename;
        private string tempFolder;
        private HTKEngine RecEngine = new HTKEngine();
        private ScoreBoard scoreBoard = new ScoreBoard();
        private NAudioPlayer audioPlayer = new NAudioPlayer();
        public NAudioPlayer AudioPlayer
        {
            get { return audioPlayer; }
        }

        public NAudioRecorder()
        {
            InitializeComponent();

            LoadWasapiDevices();
        }

        public void LoadWasapiDevices()
        {
            var deviceEnum = new MMDeviceEnumerator();
            var devices = deviceEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active).ToList();

            audioDeviceComboBox.DataSource = devices.Count == 0 ? null : devices;
            audioDeviceComboBox.DisplayMember = "FriendlyName";
        }

        public void CreateDirectory()
        {
            outputFolder = Properties.Settings.Default.RecordingFolder;
            tempFolder = Path.Combine(Path.GetTempPath(), "MPAidTemp");
            Directory.CreateDirectory(outputFolder);
            Directory.CreateDirectory(tempFolder);
        }

        public void DataBinding()
        {
            RECListBox.Items.Clear();
            DirectoryInfo info = new DirectoryInfo(Properties.Settings.Default.RecordingFolder);
            RECListBox.Items.AddRange(info.GetFiles().Where(x => x.Extension != ".mfc").Select(x => x.Name).ToArray());
        }
        private void FinalizeWaveFile(Stream s)
        {
            if (s != null)
            {
                s.Dispose();
                s = null;
            }
        }

        private void SetControlStates(bool isRecording)
        {
            recordButton.Enabled = !isRecording;
            fromFileButton.Enabled = !isRecording;
            stopButton.Enabled = isRecording;
        }

        private void StopRecording()
        {
            if (waveIn != null) waveIn.StopRecording();
            FinalizeWaveFile(writer);
        }

        private void StopPlay()
        {
            if (waveOut != null) waveOut.Stop();
            FinalizeWaveFile(reader);
        }

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            if (InvokeRequired)
            {
                //Debug.WriteLine("Data Available");
                BeginInvoke(new EventHandler<WaveInEventArgs>(OnDataAvailable), sender, e);
            }
            else
            {
                //Debug.WriteLine("Flushing Data Available");
                writer.Write(e.Buffer, 0, e.BytesRecorded);
                int secondsRecorded = (int)(writer.Length / writer.WaveFormat.AverageBytesPerSecond);
                if (secondsRecorded >= 10)
                {
                    StopRecording();
                }
                else
                {
                    recordingProgressBar.Value = secondsRecorded * 10;
                }
            }
        }

        private void Resample()
        {
            try
            {
                using (var reader = new WaveFileReader(Path.Combine(tempFolder, tempFilename)))
                {
                    var outFormat = new WaveFormat(16000, reader.WaveFormat.Channels);
                    using (var resampler = new MediaFoundationResampler(reader, outFormat))
                    {
                        // resampler.ResamplerQuality = 60;
                        WaveFileWriter.CreateWaveFile(Path.Combine(outputFolder, outputFileName), resampler);
                    }
                }
                File.Delete(Path.Combine(tempFolder, tempFilename));
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<StoppedEventArgs>(OnRecordingStopped), sender, e);
            }
            else
            {
                Resample();
                recordingProgressBar.Value = 0;
                if (e.Exception != null)
                {
                    MessageBox.Show(String.Format("A problem was encountered during recording {0}",
                                                  e.Exception.Message));
                }

                int newItemIndex = RECListBox.Items.Add(outputFileName);
                RECListBox.SelectedIndex = newItemIndex;
                SetControlStates(false);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (RECListBox.SelectedItem != null)
            {
                try
                {
                    stopButton_Click(sender, e);
                    File.Delete(Path.Combine(outputFolder, (string)RECListBox.SelectedItem));
                    RECListBox.Items.Remove(RECListBox.SelectedItem);
                    if (RECListBox.Items.Count > 0)
                    {
                        RECListBox.SelectedIndex = 0;
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp);
                    MessageBox.Show("Could not delete recording");
                }
            }
        }

        private void RECListBox_DoubleClick(object sender, EventArgs e)
        {
            if (RECListBox.SelectedItem != null)
            {
                string filePath = Path.Combine(outputFolder, (string)RECListBox.SelectedItem);
                audioPlayer.Play(filePath);
            }
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            try
            {
                var device = (MMDevice)audioDeviceComboBox.SelectedItem;
                if (!device.Equals(null))
                {
                    device.AudioEndpointVolume.Mute = false;
                    //use wasapi by default
                    waveIn = new WasapiCapture(device);
                    waveIn.DataAvailable += OnDataAvailable;
                    waveIn.RecordingStopped += OnRecordingStopped;

                    tempFilename = String.Format("{0}-{1:yyy-MM-dd-HH-mm-ss}.wav", MainForm.self.AllUsers.getCurrentUser().getName(), DateTime.Now);
                    //initially, outputname is the same as tempfilename
                    outputFileName = tempFilename;
                    writer = new WaveFileWriter(Path.Combine(tempFolder, tempFilename), waveIn.WaveFormat);
                    waveIn.StartRecording();
                    SetControlStates(true);
                }
            }
            catch(Exception exp)
            {
#if DEBUG
                MessageBox.Show(exp.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
#endif
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            StopRecording();
            StopPlay();
        }

        private void fromFileButton_Click(object sender, EventArgs e)
        {
            Process.Start(outputFolder);
        }

        private void analyzeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (RECListBox.SelectedItem != null)
                {
                    string target;
                    try
                    {
                        target = (MainForm.self.RecordingList.WordListBox.SelectedItem as Word).Name;
                    }
                    catch
                    {
                        target = string.Empty;
                    }
                    Dictionary<string, string> result = RecEngine.Recognize(Path.Combine(outputFolder, (string)RECListBox.SelectedItem)).ToDictionary(x => x.Key, x => x.Value);
                    if(result.Count > 0)
                    {
                        RecognitionResultMSGBox recMSGBox = new RecognitionResultMSGBox();
                        if (recMSGBox.ShowDialog(result.First().Key, target, result.First().Value) == DialogResult.OK)
                        {
                            scoreBoard.Content.Add(recMSGBox.scoreBoardItem);
                            correctnessLabel.Text = string.Format(@"Correctness: {0:0.0%}", scoreBoard.CalculateCorrectness); 
                        }
                        showReportButton.Enabled = true;
                    }         
                }
                
            }
            catch (Exception exp)
            {
#if DEBUG
                MessageBox.Show(exp.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
#endif
            }
        }

        private void showReportButton_Click(object sender, EventArgs e)
        {
            ReportLaucher rl = new ReportLaucher();
            rl.GenerateHTML(scoreBoard);

            // Show the HTML file in system browser
            //String reportPath = hConfig.GetHtmlFullPath();
            if (File.Exists(rl.ReportAddr))
            {
                Process browser = new Process();
                browser.StartInfo.FileName = rl.ReportAddr;
                browser.Start();
            }
            else
                showReportButton.Enabled = false;
        }

        private void RECListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            analyzeButton.Enabled = (sender as ListBox).SelectedItem != null;
            deleteButton.Enabled = (sender as ListBox).SelectedItem != null;
        }

        private void deviceRefreshButton_Click(object sender, EventArgs e)
        {
            LoadWasapiDevices();
        }
    }
}
