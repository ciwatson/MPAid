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
            this.recordingFolderTextBox.Text = MainForm.self.configContent.AudioFolderAddr;
            this.recordingFolderTextBox.TextChanged += RecordingFolderTextBox_TextChanged;
        }

        private void RecordingFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            MainForm.self.configContent.AudioFolderAddr = this.recordingFolderTextBox.Text;
        }

        private void folderSelectButton_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {           
                this.recordingFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Serializer<SysCfg>.Save<BinaryFormatter>(SysCfg.path, MainForm.self.configContent);
            this.Close();
        }       
    }
}
