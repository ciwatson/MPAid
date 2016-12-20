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
using MPAid.Cores;

namespace MPAid.NewForms
{
    public partial class RenameFileDialog : Form
    {
        private FileInfo file;
        public FileInfo RenamedFile { get; set; }

        /// <summary>
        /// Default constructor. Where possible, fills the user's details into the text boxes.
        /// </summary>
        public RenameFileDialog()
        {
            InitializeComponent();
            // Use user settings or menu data to automatically fill the fields.
            // Speaker = user's screen name
            // Category will always be word
            // Word will need a drop-down list
            // Label should start with focus and be up to them.
        }

        /// <summary>
        /// Constructor overload allowing a file to be passed in from elsewhere to be renamed.
        /// </summary>
        /// <param name="filename">The file to rename.</param>
        public RenameFileDialog(String filename): this()
        {
            file = new FileInfo(filename);
            filenameTextBox.Text = file.Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filePickerButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filenameTextBox.Text = openFileDialog.SafeFileName;
                    file = new FileInfo(openFileDialog.FileName);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            try
            {
                NameParser parser = new NameParser();
                parser.Address = Path.GetDirectoryName(file.FullName);
                parser.Ext = Path.GetExtension(file.FullName);
                parser.Speaker = speakerTextBox.Text;
                parser.Category = CategoryComboBox.Text;
                parser.Word = WordComboBox.Text;
                parser.Label = labelTextBox.Text;

                File.Move(file.FullName, parser.SingleFile);

                RenamedFile = new FileInfo(parser.SingleFile);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exp)
            {
                if (exp.GetType() == typeof(FileNotFoundException))
                {
                    MessageBox.Show(exp.Message, "No such file!");
                }
                else if (exp.GetType() == typeof(IOException))
                {
                    MessageBox.Show(exp.Message, "Destination file already exists!");
                }
            }
        }
    }
}
