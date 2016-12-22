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
    public partial class MPAiSoundLearnVideoPlayer : Form
    {
        private Boolean expanded = true;

        public MPAiSoundLearnVideoPlayer()
        {
            InitializeComponent();
        }

        private void repeatTrackBar_ValueChanged(object sender, EventArgs e)
        {
            timesRepeatBox.Text = repeatTrackBar.Value + "";
        }

        private void moreLessButton_Click(object sender, EventArgs e)
        {
            if(expanded)
            {
                moreLessButton.Text = "More...";
                expanded = false;
                learnVideoPlayerPanel.Panel2Collapsed = true;
            } else {
                moreLessButton.Text = "Less...";
                expanded = true;
                learnVideoPlayerPanel.Panel2Collapsed = false;
            }
        }
    }
}
