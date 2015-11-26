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

namespace MPAid.Forms.Config
{
    public partial class RecordingConfig : Form
    {
        public RecordingConfig()
        {
            InitializeComponent();
            this.onDBListBox.DataSource = MainForm.self.DBModel.Recording.Local.ToList();
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
                    String filename = item.ToString();
                    NamePaser paser = new NamePaser();
                    paser.FileName = filename;
                    Speaker spk = new Speaker() { Name = paser.Speaker };
                    Category cty = new Category() { Name = paser.Category };
                    Word wd = new Word() { Name = paser.Word, Category = cty };
                    Recording rd = new Recording { Address = MainForm.self.configContent.recordingFolderAddr, Name = paser.FileName, Speaker = spk, Word = wd };

                    MainForm.self.DBModel.Recording.Add(rd);
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
