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
using System.IO;
using System.Diagnostics;

namespace MPAid.NewForms
{
    public partial class AnalysisScreen : Form
    {
        private MPAiSpeakScoreBoard scoreBoard;

        AnalysisScreen(float pronunciationCorrectness, string description)
        {
            InitializeComponent();

            correctnessLabel.Text = string.Format(@"Pronunciation is {0:0.0%} Correct", pronunciationCorrectness);
            descriptionBox.Text = description;
        }

        private void scoreReportButton_Click(object sender, EventArgs e)
        {
            ReportLauncher rl = new ReportLauncher();
            rl.GenerateHTML(scoreBoard);

            if (File.Exists(rl.MPAiSpeakScoreReportHTMLAddress))
            {
                Process browser = new Process();
                browser.StartInfo.FileName = rl.MPAiSpeakScoreReportHTMLAddress;
                browser.Start();
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