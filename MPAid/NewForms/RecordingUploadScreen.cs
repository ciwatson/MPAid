using MPAid.Cores;
using MPAid.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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

            populateListBox();

        }

        /// <summary>
        /// Can't be called in a using block
        /// </summary>
        private void populateListBox()
        {
            using (MPAidModel DBModel = new MPAidModel())
            {

                List<SingleFile> view = DBModel.SingleFile.ToList();    // Add all local database files to the list.
                onDBListBox.DataSource = view;
                onDBListBox.DisplayMember = "Name";
            }
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
                    DialogResult renameAction = MessageBox.Show("All MPAi files must follow a particular naming convention.\n" +
                        "For the files that don't follow this convention, MPAi will bring up a window for you to enter thier details, and rename the automatically.\n" +
                        "This may make a long time for large numbers of files.",
                        "Warning", MessageBoxButtons.OKCancel);
                    // If the user selected cancel, don't take any action.
                    if (renameAction.Equals(DialogResult.Cancel))
                    {
                        return;
                    }
                    foreach (FileInfo item in mediaLocalListBox.SelectedItems)      // For each selected item...
                    {
                        FileInfo workingFile = item;

                        // Need to rename file.
                        // If the user wanted to rename them themselves, take the same action as in SpeechRecognitionTest - automatically bring up rename.
                        string[] parts = workingFile.Name.Split('-');
                        if (parts.Length != 4)
                        {
                            // Back up the file to a temporary folder.
                            string tempFolder = Path.Combine(Path.GetTempPath(), "MPAiTemp");
                            File.Copy(workingFile.FullName, Path.Combine(tempFolder, "Rename_Backup"));

                            //Open the rename dialog
                            RenameFileDialog renameDialog = new RenameFileDialog(workingFile.FullName, true);
                            if (renameDialog.ShowDialog(this).Equals(DialogResult.OK))
                            {
                                // The old file has been changed to this.
                                FileInfo renamedFile = renameDialog.RenamedFile;
                                // Restore the old file, with old name intact, from the backup.
                                File.Move(Path.Combine(tempFolder, "Rename_Backup"), workingFile.FullName);
                                // Continue the process with the new file name.
                                workingFile = renamedFile;
                            }
                            else
                            {
                                continue; 
                            }
                        }
                        // If the file follows convention (i.e. parts.length == 4), do nothing.

                        NameParser parser = new NameParser();
                        parser.FullName = workingFile.FullName;          // Put the name into the parser
                        // Set the parser address to the audio or video folder as appropriate. 
                        if (parser.MediaFormat == "audio") parser.Address = Properties.Settings.Default.AudioFolder;
                        else if (parser.MediaFormat == "video") parser.Address = Properties.Settings.Default.VideoFolder;
                        // Get the file and add it to the database context.
                        DBModel.AddOrUpdateRecordingFile(parser.SingleFile);
                        // Copy the existing local file into the audio/video folder if it wasn't already there.
                        string existingFile = workingFile.FullName;
                        string newFile = parser.Address + "\\" + workingFile.Name;
                        if (!existingFile.Equals(newFile))
                        {
                            File.Copy(existingFile, newFile, true);
                        }
                    }
                }
                populateListBox();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                MessageBox.Show("Failed to update!");
            }
        }

        private void toLocalButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (MPAidModel DBModel = new MPAidModel())
                {
                    // Creating a copy of the list box selected items to iterate through
                    List<SingleFile> selectedItemsCopy = new List<SingleFile>();
                    List<SingleFile> allItems = DBModel.SingleFile.ToList();  // Avoid n+1 selects problem in the next for loop.
                    foreach (SingleFile sf in onDBListBox.SelectedItems)
                    {
                        SingleFile toAdd = allItems.Find(x => x.SingleFileId == sf.SingleFileId);
                        selectedItemsCopy.Add(toAdd);
                    }

                    // For each item in the database list box...
                    foreach (SingleFile sf in selectedItemsCopy)
                    {
                        Recording rd = null;
                        NameParser paser = new NameParser();
                        paser.FullName = sf.Name;       // Add the file to the Parser
                                                        // Use the parser to create the model objects.
                        if (paser.MediaFormat == "audio")
                        {
                            rd = sf.Audio;
                        }
                        else if (paser.MediaFormat == "video")
                        {
                            rd = sf.Video;
                        }
                        Speaker spk = rd.Speaker;
                        Word word = rd.Word;
                        Category cty = word.Category;
                        string existingFile = sf.Address + "\\" + sf.Name;
                        File.Delete(existingFile);      // Delete it,
                        DBModel.SingleFile.Remove(sf);    // And remove it from the database.

                        // If the deleted file was: 
                        if (rd.Audios.Count == 0 && rd.Video == null)   // The last file attached to a recording, then delete the recording.
                        {
                            DBModel.Recording.Remove(rd);    
                        }
                        if (spk.Recordings.Count == 0)                  // The last recording attached to a speaker, then delete the speaker.
                        {
                            DBModel.Speaker.Remove(spk);
                        }
                        if (word.Recordings.Count == 0)                 // The last recording attached to a word, then delete the word.
                        {
                            DBModel.Word.Remove(word);
                        }                  
                        if (cty.Words.Count == 0)                       // The last word attached to a category, then delete the category.
                        {
                            DBModel.Category.Remove(cty);
                        }                    
                    }
                }
                populateListBox();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Failed to delete!");
            }
        }
    }
}
