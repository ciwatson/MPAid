using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MPAid.Forms.Config
{
    public partial class RecordingRenameConfig : Form
    {
        public RecordingRenameConfig()
        {
            InitializeComponent();
        }

        private void filePickerButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.filenameTextBox.Text = openFileDialog.SafeFileName;
                }
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            try
            {
                Modules.NamePaser paser = new Modules.NamePaser();
                paser.Address = Path.GetDirectoryName(openFileDialog.FileName);
                paser.Ext = Path.GetExtension(openFileDialog.FileName);
                paser.Speaker = this.speakerTextBox.Text;
                paser.Category = this.categoryTextBox.Text;
                paser.Word = this.wordTextBox.Text;
                paser.Label = this.labelTextBox.Text;

                File.Move(openFileDialog.FileName, paser.SingleFile);

                if(File.Exists(paser.SingleFile))
                {
                    this.filenameTextBox.Text = paser.FullName;
                    this.openFileDialog.FileName = paser.SingleFile;
                }
            }
            catch(Exception exp)
            {
                if(exp.GetType() == typeof(FileNotFoundException))
                {
                    MessageBox.Show(exp.ToString());
                }
                Console.WriteLine(exp);
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.self.PlayVowelSoundAsync(this.openFileDialog.FileName, 1);
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp);
            }
        }
    }
}
