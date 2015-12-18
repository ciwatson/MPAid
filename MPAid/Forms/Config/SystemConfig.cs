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

namespace MPAid.Forms.Config
{
    public partial class SystemConfig : Form
    {
        public SystemConfig()
        {
            InitializeComponent();

            InitializeContent();
        }

        private void InitializeContent()
        {
            this.audioFolderTextBox.Text = MainForm.self.configContent.AudioFolderAddr;
            this.audioFolderTextBox.TextChanged += AudioFolderTextBox_TextChanged;

            this.videoFolderTextBox.Text = MainForm.self.configContent.VideoFolderAddr;
            this.videoFolderTextBox.TextChanged += VideoFolderTextBox_TextChanged;
        }

        private void AudioFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            MainForm.self.configContent.AudioFolderAddr = this.audioFolderTextBox.Text;
        }

        private void VideoFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            MainForm.self.configContent.VideoFolderAddr = this.videoFolderTextBox.Text;
        }

        private void folderSelectButton_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {           
                this.audioFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Serializer<SysCfg>.Save<BinaryFormatter>(SysCfg.path, MainForm.self.configContent);
            this.Close();
        }

        private void videoFolderSelectButton_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.videoFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
