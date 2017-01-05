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
    public partial class AudioPlayer : Form
    {
        public AudioPlayer()
        {
            InitializeComponent();
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void audioPlayer_PositionChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerPositionChangedEventArgs e)
        {
            SetProgress((int)(vlcAudioPlayer.Position * 100));
        }

        delegate void SetProgressCallback(int value);

        private void SetProgress(int value)
        {
            if (this.audioProgressBar.InvokeRequired)
            {
                SetProgressCallback d = new SetProgressCallback(SetProgress);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.audioProgressBar.Value = value;
            }
        }
    }
}
