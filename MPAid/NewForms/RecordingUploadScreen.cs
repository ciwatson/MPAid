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
    }
}
