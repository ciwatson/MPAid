using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPAid.Models;
using MPAid.Cores;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.IO;

namespace MPAid.Forms.Config
{
    public partial class RecordingUploadConfig : Form
    {
        public RecordingUploadConfig()
        {
            InitializeComponent();

            this.onDBListBox.DataSource = MainForm.self.DBModel.SingleFile.Local.ToBindingList();
            this.onDBListBox.DisplayMember = "Name";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.audioLocalListBox.DataSource = null;

            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    String[] fileNames = openFileDialog.FileNames.Select(x => x = x.Substring(x.LastIndexOf('\\') + 1)).ToArray();
                    String[] fileAddresses = openFileDialog.FileNames.Select(x => x = x.Substring(0, x.LastIndexOf('\\'))).ToArray();

                    Dictionary<string, string> dataSource = fileNames.Zip(fileAddresses, (lText, lValue) => new { lText, lValue }).ToDictionary(x => x.lText, x => x.lValue);

                    ListBox localListBox = this.mediaLocalTabControl.SelectedIndex == 0 ? this.audioLocalListBox : this.videoLocalListBox;
                    localListBox.DataSource = new BindingSource() { DataSource = dataSource };
                    localListBox.DisplayMember = "Key";
                    localListBox.ValueMember = "Value";
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }


        private void toDBButton_Click(object sender, EventArgs e)
        {
            try
            {
                var DBContext = MainForm.self.DBModel;
                ListBox.SelectedObjectCollection selectedCollection = null;
                if (mediaLocalTabControl.SelectedIndex == 0) selectedCollection = audioLocalListBox.SelectedItems;
                else if (mediaLocalTabControl.SelectedIndex == 1) selectedCollection = videoLocalListBox.SelectedItems;

                foreach (KeyValuePair<string, string> item in selectedCollection)
                {
                    String filename = item.Key.ToString();
                    NamePaser paser = new NamePaser();
                    paser.FullName = filename;
                    paser.Address = recordingFolder;

                    DBContext.AddOrUpdateRecordingFile(paser.SingleFile);

                    string existingFile = item.Value + "\\" + item.Key;
                    string newFile = recordingFolder + "\\" + item.Key;
                    //avoid writing itslef
                    if (!existingFile.Equals(newFile))
                    {
                        File.Copy(existingFile, newFile, true);
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                MessageBox.Show("Fail to update!");
            }
        }

        private void toLocalButton_Click(object sender, EventArgs e)
        {
            try
            {
                var DBContext = MainForm.self.DBModel;
                for (int i = onDBListBox.SelectedItems.Count - 1; i >= 0; i--)
                {
                    SingleFile sf = onDBListBox.SelectedItems[i] as MPAid.Models.SingleFile;
                    Recording rd = sf.Audio;
                    Speaker spk = rd.Speaker;
                    Word word = rd.Word;
                    Category cty = word.Category;
                    string existingFile = sf.Address + "\\" + sf.Name;
                    if (File.Exists(existingFile))
                    {
                        File.Delete(existingFile);
                    }
                    DBContext.SingleFile.Remove(sf);

                    if(rd.Audios.Count == 0 && rd.Video == null) DBContext.Recording.Remove(rd);
                    if (spk.Recordings.Count == 0) DBContext.Speaker.Remove(spk);
                    if (word.Recordings.Count == 0) DBContext.Word.Remove(word);
                    if (cty.Words.Count == 0) DBContext.Category.Remove(cty);
                }
                MainForm.self.DBModel.SaveChanges();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                MessageBox.Show("Fail to delete!");
            }
        }

        private void mediaLocalTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.mediaLocalTabControl.SelectedIndex == 0)
            {
                recordingFolder = MainForm.self.configContent.AudioFolderAddr;
            }
            else if(this.mediaLocalTabControl.SelectedIndex == 1)
            {
                recordingFolder = MainForm.self.configContent.VideoFolderAddr;
            }
            this.openFileDialog.InitialDirectory = recordingFolder;
        }

        private String recordingFolder;
    }
}
