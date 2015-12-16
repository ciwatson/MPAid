using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
