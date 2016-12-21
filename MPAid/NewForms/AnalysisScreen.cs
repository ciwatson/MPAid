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
        private ScoreBoard scoreBoard;

        AnalysisScreen(string recordingFileName, string targetWord, string recognisedWord, ScoreBoard scoreBoard)
        {
            InitializeComponent();

            this.scoreBoard = scoreBoard;

            descriptionBox.Text = PronuciationAdvisor.Advise(recordingFileName, targetWord, recognisedWord);
            correctnessLabel.Text = string.Format(@"Pronunciation is {0:0.0%} Correct", scoreBoard.CalculateCorrectness);
        }

        private void scoreReportButton_Click(object sender, EventArgs e)
        {
            ReportLaucher rl = new ReportLaucher();
            rl.GenerateHTML(scoreBoard);

            if (File.Exists(rl.ReportAddr))
            {
                Process browser = new Process();
                browser.StartInfo.FileName = rl.ReportAddr;
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