using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPAid.UserControllers
{
    public partial class RecordingConfig : UserControl
    {
        public RecordingConfig()
        {
            InitializeComponent();
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            this.openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            this.onLocalListBox.Items.Clear();
            this.onLocalListBox.Items.AddRange(this.openFileDialog.FileNames);
        }

        private void updateDBButton_Click(object sender, EventArgs e)
        {

        }

        private void toDBButton_Click(object sender, EventArgs e)
        {

        }

        private void toLocalButton_Click(object sender, EventArgs e)
        {

        }
    }
}
