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

            this.openFileDialog.InitialDirectory = MainForm.self.configContent.AudioFolderAddr;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.onLocalListBox.DataSource = null;

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

                    this.onLocalListBox.DataSource = new BindingSource() { DataSource = dataSource };
                    this.onLocalListBox.DisplayMember = "Key";
                    this.onLocalListBox.ValueMember = "Value";
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
                var recordingFolder = MainForm.self.configContent.AudioFolderAddr;
                foreach (KeyValuePair<string, string> item in this.onLocalListBox.SelectedItems)
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
                    Copy copy = sf.Copy;
                    Recording rd = copy.Recording;
                    Speaker spk = rd.Speaker;
                    Word word = rd.Word;
                    Category cty = word.Category;
                    string existingFile = sf.Address + "\\" + sf.Name;
                    if (File.Exists(existingFile))
                    {
                        File.Delete(existingFile);
                    }
                    DBContext.SingleFile.Remove(sf);
                    DBContext.Copy.Remove(copy);

                    if(rd.GetType() == typeof(AudioRecording))
                    {
                        if ((rd as AudioRecording).Audio.Count == 0) DBContext.AudioRecording.Remove(rd as AudioRecording);
                    }
                    else if (rd.GetType() == typeof(VideoRecording))
                    {
                        if ((rd as VideoRecording).Video == null) DBContext.VideoRecording.Remove(rd as VideoRecording);
                    }
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
    }
}
