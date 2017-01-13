using MPAid.Cores;
using MPAid.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPAid.NewForms
{
    public partial class RecordingUploadScreen : Form
    {
        public RecordingUploadScreen()
        {
            InitializeComponent();

            using (MPAidModel DBModel = new MPAidModel())
            {
                DBModel.Database.Initialize(false); // Added for safety; if the database has not been initialised, initialise it.

                List<SingleFile> view = DBModel.SingleFile.ToList();    // Add all local database files to the list.

                onDBListBox.DataSource = view;
            }
            onDBListBox.DisplayMember = "Name";
        }

        private void selectFolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    DirectoryInfo selectedDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                    currentFolderTextBox.Text = selectedDirectory.FullName;
                    ListBox localListBox = mediaLocalListBox;
                    localListBox.DataSource = new BindingSource() { DataSource = selectedDirectory.GetFiles()};  // Replace the values in the list box with the new dictionary.
                    localListBox.DisplayMember = "Name";     // Display the names.
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
                using (MPAidModel DBModel = new MPAidModel())
                {
                    MessageBox.Show("All MPAi files must follow a particular naming convention.\n" +
                        "For the files that don't follow this convention, would you like MPAi to try to automatically rename them?\n" +
                        "If you would prefer to name them yourself, select no, and you will be prompted for each file.\n"+
                        "This may make a long time for large numbers of files.",
                        "Warning", MessageBoxButtons.YesNoCancel);
                    foreach (FileInfo item in mediaLocalListBox.SelectedItems)      // For each selected item...
                    {
                        string filename = item.FullName;

                        // Need to rename file.
                        // If the file follows convention, do nothing.
                        // If the user wanted to rename them themselves, take the same action as in SpeechRecognitionTest - automatically bring up rename.
                        // If not, use the current filename as the label and use current user's values to fill the fields.
                        // Also - make sure everything uses Speaker now - it's working.

                        NameParser parser = new NameParser();
                        parser.FullName = filename;          // Put the name into the parser
                        // Set the parser address to the audio or video folder as appropriate. 
                        if (parser.MediaFormat == "audio") parser.Address = Properties.Settings.Default.AudioFolder;
                        else if (parser.MediaFormat == "video") parser.Address = Properties.Settings.Default.VideoFolder;
                        // Get the file and add it to the database context.
                        DBModel.AddOrUpdateRecordingFile(parser.SingleFile);
                        // Copy the existing local file into the audio/video folder if it wasn't already there.
                        string existingFile = item.FullName;
                        string newFile = parser.Address + "\\" + item.Name;
                        if (!existingFile.Equals(newFile))
                        {
                            File.Copy(existingFile, newFile, true);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                MessageBox.Show("Fail to update!");
            }
        }
    }
}
