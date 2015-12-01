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
using MPAid.Modules;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.IO;

namespace MPAid.Forms.Config
{
    public partial class RecordingConfig : Form
    {
        public RecordingConfig()
        {
            InitializeComponent();

            this.onDBListBox.DataSource = MainForm.self.DBModel.Recording.Local.ToBindingList();
            this.onDBListBox.DisplayMember = "Name";

            this.openFileDialog.InitialDirectory = MainForm.self.configContent.recordingFolderAddr;
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

                    this.onLocalListBox.DataSource = new BindingSource() { DataSource = dataSource } ;
                    this.onLocalListBox.DisplayMember = "Key";
                    this.onLocalListBox.ValueMember = "Value";
                }
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp);
            }
        }


        private void toDBButton_Click(object sender, EventArgs e)
        {
            try
            {
                var DBContext = MainForm.self.DBModel;
                var recordingFolder = MainForm.self.configContent.recordingFolderAddr;
                foreach (KeyValuePair<string, string> item in this.onLocalListBox.SelectedItems)
                {
                    String filename = item.Key.ToString();
                    NamePaser paser = new NamePaser();
                    paser.FileName = filename;

                    Speaker spk = new Speaker() { Name = paser.Speaker };
                    DBContext.Speaker.AddOrUpdate(x => x.Name, spk);
                    MainForm.self.DBModel.SaveChanges();

                    Category cty = new Category() { Name = paser.Category };
                    DBContext.Category.AddOrUpdate(x => x.Name, cty);
                    MainForm.self.DBModel.SaveChanges();

                    Word wd = new Word() { Name = paser.Word,
                        CategoryId = DBContext.Category.Single(x =>x.Name == paser.Category).CategoryId};
                    DBContext.Word.AddOrUpdate(x => x.Name, wd);
                    MainForm.self.DBModel.SaveChanges();

                    Recording rd = new Recording { Address = recordingFolder,
                        Name = paser.FileName,
                        SpeakerId = DBContext.Speaker.Single(x => x.Name == paser.Speaker).SpeakerId,
                        WordId = DBContext.Word.Single(x => x.Name == paser.Word).WordId
                    };
                    DBContext.Recording.AddOrUpdate(x => x.Name, rd);
                    MainForm.self.DBModel.SaveChanges();

                    string existingFile = item.Value + "\\" + item.Key;
                    string newFile = recordingFolder + "\\" + rd.Name;
                    //avoid writing itslef
                    if(!existingFile.Equals(newFile))
                    {
                        File.Copy(existingFile, newFile, true);
                    }
                }
            }
            catch(Exception exp)
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
                //Dont use foreach since the index will change when item is deleted
                for(int i = onDBListBox.SelectedItems.Count - 1; i >= 0; i--)
                {
                    Recording item = onDBListBox.Items[i] as MPAid.Models.Recording;
                    string existingFile = item.Address + "\\" + item.Name;
                    if (File.Exists(existingFile))
                    {
                        File.Delete(existingFile);
                    }
                    DBContext.Recording.Remove(item);            
                }
                MainForm.self.DBModel.SaveChanges();
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp);
                MessageBox.Show("Fail to delete!");
            }
        }
    }
}
