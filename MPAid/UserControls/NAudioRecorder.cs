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
        public NAudioRecorder()
        {
            InitializeComponent();

            LoadWasapiDevices();

            outputFolder = Path.Combine(Path.GetTempPath(), "NAudioDemo");
            Directory.CreateDirectory(outputFolder);
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

        void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<StoppedEventArgs>(OnRecordingStopped), sender, e);
            }
            else
            {
                FinalizeWaveFile();
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

            outputFilename = String.Format("NAudioDemo {0:yyy-MM-dd HH-mm-ss}.wav", DateTime.Now);
            writer = new WaveFileWriter(Path.Combine(outputFolder, outputFilename), waveIn.WaveFormat);
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
            MainForm mainForm = Parent.Parent.Parent.Parent.Parent.Parent as MainForm;
            int total = RECListBox.Items.Count;
            String word = (mainForm.RecordingList.WordListBox.SelectedItem as Word).Name;
            string score = null;
            if (total > 0)
            {
                int i = 0;
    
                foreach (var item in RECListBox.Items)
                    if (new Examiner(item.ToString(), word).wordsMatch())
                        i += 1;
                score = (100 * i / total).ToString();
                score += "%";
            }
            else
            {
                score = "Unavailable";
            }
            correctnessLabel.Text = "Correctness = " + score;
        }

        private void showReportButton_Click(object sender, EventArgs e)
        {

        }
    }
}
