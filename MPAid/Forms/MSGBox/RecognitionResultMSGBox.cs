using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPAid.Cores;
using MPAid.Models;

namespace MPAid.Forms.MSGBox
{
    partial class RecognitionResultMSGBox : Form
    {
        public ScoreBoardItem scoreBoardItem = new ScoreBoardItem();
        private PronouciationAdvisor advisor = new PronouciationAdvisor();
        public RecognitionResultMSGBox()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(string recording, string target, string recognized)
        {
            this.Text = recording;
            recognitionResultLabel.Text = recognized;
            elseTextBox.Text = target;

            ElseTextBox_Leave(this, EventArgs.Empty);
            return ShowDialog();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            scoreBoardItem.RecognisedText = recognitionResultLabel.Text;
            scoreBoardItem.ExpectingText = string.IsNullOrEmpty(elseTextBox.Text) ? recognitionResultLabel.Text : elseTextBox.Text;
            scoreBoardItem.Analysis = descriptionTextBox.Text;
        }
        private void ElseTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                descriptionTextBox.Text = advisor.Advise(this.Text, elseTextBox.Text, recognitionResultLabel.Text);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
