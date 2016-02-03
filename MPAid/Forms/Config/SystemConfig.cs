using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using MPAid.Cores;
using NAudio.CoreAudioApi;
using System.IO;

namespace MPAid.Forms.Config
{
    public partial class SystemConfig : Form
    {
        public SystemConfig()
        {
            InitializeComponent();
        }

        public void InitializeContent()
        {
            try
            {
                Properties.Settings.Default.AudioFolder = Path.Combine(System.Windows.Forms.Application.StartupPath, @"Audio");
                InitializeTextBox(this.audioFolderTextBox, Properties.Settings.Default.AudioFolder);
                this.audioFolderTextBox.TextChanged += AudioFolderTextBox_TextChanged;

                Properties.Settings.Default.VideoFolder = Path.Combine(System.Windows.Forms.Application.StartupPath, @"Video");
                InitializeTextBox(this.videoFolderTextBox, Properties.Settings.Default.VideoFolder);
                this.videoFolderTextBox.TextChanged += VideoFolderTextBox_TextChanged;

                Properties.Settings.Default.RecordingFolder = Path.Combine(System.Windows.Forms.Application.StartupPath, @"Recording");
                InitializeTextBox(this.recordingFolderTextBox, Properties.Settings.Default.RecordingFolder);
                this.recordingFolderTextBox.TextChanged += RecordingFolderTextBox_TextChanged;

                Properties.Settings.Default.ReportFolder = Path.Combine(System.Windows.Forms.Application.StartupPath, @"Report");
                InitializeTextBox(this.reportFolderTextBox, Properties.Settings.Default.ReportFolder);
                this.reportFolderTextBox.TextChanged += ReportFolderTextBox_TextChanged;

                Properties.Settings.Default.HTKFolder = Path.Combine(System.Windows.Forms.Application.StartupPath, @"HTK");
                InitializeTextBox(this.HTKFolderTextBox, Properties.Settings.Default.HTKFolder);
                this.HTKFolderTextBox.TextChanged += HTKFolderTextBox_TextChanged;

                Properties.Settings.Default.FomantFolder = Path.Combine(System.Windows.Forms.Application.StartupPath, @"Fomant");
                InitializeTextBox(this.fomantFolderTextBox, Properties.Settings.Default.FomantFolder);
                this.fomantFolderTextBox.TextChanged += FomantFolderTextBox_TextChanged;

                Properties.Settings.Default.Save();
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void InitializeTextBox(TextBox tb, string dir)
        {
            try
            {
                Directory.CreateDirectory(dir);
                tb.Text = dir;
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void AudioFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AudioFolder = this.audioFolderTextBox.Text;
        }
        private void VideoFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.VideoFolder = this.videoFolderTextBox.Text;
        }
        private void RecordingFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RecordingFolder = this.recordingFolderTextBox.Text;
        }
        private void ReportFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ReportFolder = this.reportFolderTextBox.Text;
        }
        private void HTKFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.HTKFolder = this.HTKFolderTextBox.Text;
        }
        private void FomantFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.FomantFolder = this.fomantFolderTextBox.Text;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            this.Close();
        }
        private void audioFolderSelectButton_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.audioFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
        private void videoFolderSelectButton_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.videoFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
        private void recordingFolderSelectButton_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.recordingFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
        private void reportFolderSelectButton_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.reportFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
        private void HTKFolderSelectButton_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.HTKFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
        private void fomantFolderSelectButton_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.fomantFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
