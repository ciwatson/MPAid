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

        public NAudioRecorder NAudioRecorder
        {
            get { return naudioRecorder; }
        }
        public OperationPanel()
        {
            InitializeComponent();

            tdButtonFormantPlot.ImageNormal = Properties.Resources.ButtonYellow_0;
            tdButtonFormantPlot.ImageHighlight = Properties.Resources.ButtonYellow_1;
            tdButtonFormantPlot.ImagePressed = Properties.Resources.ButtonYellow_2;
        }
        private void operationTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            naudioRecorder.CreateDirectory();
            naudioRecorder.DataBinding();
            VlcPlayer.VlcControl.Stop();
        }
        private void tdButtonFormantPlot_Click(object sender, EventArgs e)
        {
            tdButtonFormantPlot.Enabled = false;

            // Start formant plot
            FormantPlotController.RunFormantPlot();

            tdButtonFormantPlot.Enabled = true;
        }
    }
}
