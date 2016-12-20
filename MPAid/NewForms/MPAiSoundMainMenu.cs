using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPAid.NewForms
{
    public partial class MPAiSoundMainMenu : Form
    {
        public MPAiSoundMainMenu()
        {
            InitializeComponent();

            MPAiUser currentUser = UserManagement.getCurrentUser();
            greetingLabel.Text = "Kia Ora " + currentUser.getName() + "!";

            switch (currentUser.Voice)
            {
                case Models.VoiceType.FEMININE_HERITAGE:
                    heritageMāoriToolStripMenuItem.CheckState = CheckState.Checked;
                    feminineToolStripMenuItem.CheckState = CheckState.Checked;
                    break;
                case Models.VoiceType.FEMININE_MODERN:
                    modernMāoriToolStripMenuItem.CheckState = CheckState.Checked;
                    feminineToolStripMenuItem.CheckState = CheckState.Checked;
                    break;
                case Models.VoiceType.MASCULINE_HERITAGE:
                    heritageMāoriToolStripMenuItem.CheckState = CheckState.Checked;
                    masculineToolStripMenuItem.CheckState = CheckState.Checked;
                    break;
                case Models.VoiceType.MASCULINE_MODERN:
                    modernMāoriToolStripMenuItem.CheckState = CheckState.Checked;
                    masculineToolStripMenuItem.CheckState = CheckState.Checked;
                    break;
            }
        }

        private void heritageMāoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            heritageMāoriToolStripMenuItem.Checked = true;
            modernMāoriToolStripMenuItem.Checked = false;
        }

        private void modernMāoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            heritageMāoriToolStripMenuItem.Checked = false;
            modernMāoriToolStripMenuItem.Checked = true;
        }

        private void feminineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            feminineToolStripMenuItem.Checked = true;
            masculineToolStripMenuItem.Checked = false;
        }

        private void masculineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            feminineToolStripMenuItem.Checked = false;
            masculineToolStripMenuItem.Checked = true;
        }
    }
}
