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

namespace MPAid.Forms.Config
{
    public partial class RecordingConfig : Form
    {
        public RecordingConfig()
        {
            InitializeComponent();
            MainForm.self.DBModel.Recording.Load();
            this.onDBListBox.DataSource = MainForm.self.DBModel.Recording.Local.ToBindingList();
            this.onDBListBox.DisplayMember = "Name";
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    String[] filenames = openFileDialog.FileNames.Select(x => x = x.Substring(x.LastIndexOf('\\') + 1)).ToArray();
                    this.onLocalListBox.Items.Clear();
                    this.onLocalListBox.Items.AddRange(filenames);
                }
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        private void updateDBButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MainForm.self.DBModel.SaveChanges() > 0)
                {
                    MessageBox.Show("Successfully updated!");
                }
                else
                {
                    MessageBox.Show("Fail to update.");
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
                foreach (var item in this.onLocalListBox.Items)
                {
                    var DBContext = MainForm.self.DBModel;
                    String filename = item.ToString();
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

                    Recording rd = new Recording { Address = MainForm.self.configContent.recordingFolderAddr,
                        Name = paser.FileName,
                        SpeakerId = DBContext.Speaker.Single(x => x.Name == paser.Speaker).SpeakerId,
                        WordId = DBContext.Word.Single(x => x.Name == paser.Word).WordId
                    };
                    DBContext.Recording.AddOrUpdate(x => x.Name, rd);
                    MainForm.self.DBModel.SaveChanges();
                }
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        private void toLocalButton_Click(object sender, EventArgs e)
        {

        }
    }
}
