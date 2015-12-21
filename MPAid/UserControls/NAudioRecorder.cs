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

namespace MPAid.UserControls
{
    public partial class NAudioRecorder : UserControl
    {
        private IWaveIn waveIn;
        private WaveFileWriter writer;
        private string outputFilename;
        private readonly string outputFolder;
        private string tempFilename;
        private readonly string tempFolder;
        public NAudioRecorder()
        {
            InitializeComponent();

            LoadWasapiDevices();

            outputFolder = Path.Combine(System.Windows.Forms.Application.StartupPath, "Recordings");
            Directory.CreateDirectory(outputFolder);

            tempFolder = Path.Combine(Path.GetTempPath(), "MPAidTemp");
            Directory.CreateDirectory(tempFolder);
        }

        private void LoadWasapiDevices()
        {
            var deviceEnum = new MMDeviceEnumerator();
            var devices = deviceEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active).ToList();

            audioDeviceComboBox.DataSource = devices;
            audioDeviceComboBox.DisplayMember = "FriendlyName";
        }

        private void FinalizeWaveFile()
        {
            if (writer != null)
            {
                writer.Dispose();
                writer = null;
            }
        }

        private void SetControlStates(bool isRecording)
        {
            recordButton.Enabled = !isRecording;
            fromFileButton.Enabled = !isRecording;
            stopButton.Enabled = isRecording;
        }

        private double CalculateScore()
        {
            MainForm mainForm = Parent.Parent.Parent.Parent.Parent.Parent as MainForm;
            String word = (mainForm.RecordingList.WordListBox.SelectedItem as Word).Name;
            int total = RECListBox.Items.Count;
            double score = -1;
            if (total > 0)
            {
                int i = 0;

                foreach (var item in RECListBox.Items)
                    if (new Examiner(item.ToString(), word).wordsMatch())
                        i += 1;
                score = i / total;
            }
            return score;
        }

        private void StopRecording()
        {
            if (waveIn != null) waveIn.StopRecording();
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
                if (secondsRecorded >= 30)
                {
                    StopRecording();
                }
                else
                {
                    recordingProgressBar.Value = secondsRecorded;
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
                        WaveFileWriter.CreateWaveFile(Path.Combine(outputFolder, outputFilename), resampler);
                    }
                }
                File.Delete(Path.Combine(tempFolder, tempFilename));
            }
            catch(Exception exp)
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
                FinalizeWaveFile();
                Resample();
                recordingProgressBar.Value = 0;
                if (e.Exception != null)
                {
                    MessageBox.Show(String.Format("A problem was encountered during recording {0}",
                                                  e.Exception.Message));
                }
                int newItemIndex = RECListBox.Items.Add(outputFilename);
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
                    File.Delete(Path.Combine(outputFolder, (string)RECListBox.SelectedItem));
                    RECListBox.Items.Remove(RECListBox.SelectedItem);
                    if (RECListBox.Items.Count > 0)
                    {
                        RECListBox.SelectedIndex = 0;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Could not delete recording");
                }
            }
        }

        private void RECListBox_DoubleClick(object sender, EventArgs e)
        {
            if (RECListBox.SelectedItem != null)
            {
                Process.Start(Path.Combine(outputFolder, (string)RECListBox.SelectedItem));
            }
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            var device = (MMDevice)audioDeviceComboBox.SelectedItem;
            device.AudioEndpointVolume.Mute = false;
            //use wasapi by default
            waveIn = new WasapiCapture(device);
            waveIn.DataAvailable += OnDataAvailable;
            waveIn.RecordingStopped += OnRecordingStopped;

            tempFilename = String.Format("NAudioDemo {0:yyy-MM-dd HH-mm-ss}.wav", DateTime.Now);
            outputFilename = tempFilename;
            writer = new WaveFileWriter(Path.Combine(tempFolder, tempFilename), waveIn.WaveFormat);
            waveIn.StartRecording();
            SetControlStates(true);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            StopRecording();
        }

        private void fromFileButton_Click(object sender, EventArgs e)
        {
            Process.Start(outputFolder);
        }

        private void analyzeButton_Click(object sender, EventArgs e)
        {
            correctnessLabel.Text = "Correctness = " + CalculateScore().ToString();
        }

        private void showReportButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = Parent.Parent.Parent.Parent.Parent.Parent as MainForm;

            String word = (mainForm.RecordingList.WordListBox.SelectedItem as Word).Name;
            HtmlConfig hConfig = new HtmlConfig(mainForm.configContent.ReportFolderAddr.FolderAddr)
            {
                myWord = word,
                correctnessValue = CalculateScore().ToString()
            };

            if ((RECListBox.Items != null) && (RECListBox.Items.Count > 0))
            {
                string[] wordArray = new string[RECListBox.Items.Count];
                RECListBox.Items.CopyTo(wordArray, 0);
                hConfig.listRecognized = wordArray.ToList();
            }


            HtmlGenerator htmlWriter = new HtmlGenerator(hConfig);
            htmlWriter.Run();

            // Show the HTML file in system browser
            String reportPath = hConfig.GetHtmlFullPath();
            if (File.Exists(reportPath))
            {
                Process browser = new Process();
                browser.StartInfo.FileName = reportPath;
                browser.Start();
            }
            else
                showReportButton.Enabled = false;
        }
    }
}
