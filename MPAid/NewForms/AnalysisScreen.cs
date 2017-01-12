using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPAid.Cores;
using MPAid.Cores.Scoreboard;
using System.IO;
using System.Diagnostics;

namespace MPAid.NewForms
{
    public partial class AnalysisScreen : Form
    {

        AnalysisScreen(float pronunciationCorrectness, string description)
        {
            InitializeComponent();

            correctnessLabel.Text = string.Format(@"Pronunciation is {0:0.0%} Correct", pronunciationCorrectness);
            descriptionBox.Text = description;
        }

        private void scoreReportButton_Click(object sender, EventArgs e)
        {
            ReportLauncher.GenerateMPAiSpeakScoreHTML(UserManagement.CurrentUser.SpeakScoreboard);

            if (File.Exists(ReportLauncher.MPAiSpeakScoreReportHTMLAddress))
            {
                ReportLauncher.ShowMPAiSpeakScoreReport();
            }
            else
            {
                scoreReportButton.Enabled = false;
            }
        }

        private void learnButton_Click(object sender, EventArgs e)
        {
            //Open learn section once implemented
        }
    }
}