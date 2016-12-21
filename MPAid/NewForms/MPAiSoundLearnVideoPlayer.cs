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
        public MPAiSoundLearnVideoPlayer()
        {
            InitializeComponent();
        }

        private void repeatTrackBar_ValueChanged(object sender, EventArgs e)
        {
            timesRepeatBox.Text = repeatTrackBar.Value + "";
        }
    }
}
