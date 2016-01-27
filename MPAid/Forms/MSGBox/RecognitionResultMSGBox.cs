using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPAid.Cores;

namespace MPAid.Forms.MSGBox
{
    partial class RecognitionResultMSGBox : Form
    {
        public ScoreBoardItem scoreBoardItem = new ScoreBoardItem();
        public RecognitionResultMSGBox()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(string recognition, string description)
        {
            recognitionResultLabel.Text = recognition;
            descriptionTextBox.Text = description;
            return ShowDialog();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            scoreBoardItem.RecognisedText = recognitionResultLabel.Text;
            scoreBoardItem.ExpectingText = string.IsNullOrEmpty(elseTextBox.Text) ? recognitionResultLabel.Text : elseTextBox.Text;
        }
    }
}
