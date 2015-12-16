using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Core;

namespace MPAid.UserControls
{
    public partial class OperationPanel : UserControl
    {
        public VlcPlayer VlcPlayer
        {
            get { return vlcPlayer; }
        }
        public OperationPanel()
        {
            InitializeComponent();
        }

        private void tabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            vlcPlayer.VlcControl.Stop();
        }

        private void tdButtonFormantPlot_Click(object sender, EventArgs e)
        {
            tdButtonFormantPlot.Enabled = false;

            // Start formant plot
            FormantPlotController.RunFormantPlot();

            tdButtonFormantPlot.Enabled = true;
        }

        private void buttonRecord_Click(object sender, EventArgs e)
        {
        }

        private void buttonStopRecording_Click(object sender, EventArgs e)
        {

        }

        private void buttonShowDir_Click(object sender, EventArgs e)
        {

        }

        private void buttonLoadFromFile_Click(object sender, EventArgs e)
        {

        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {

        }

        private void buttonShowReport_Click(object sender, EventArgs e)
        {

        }
    }
}
