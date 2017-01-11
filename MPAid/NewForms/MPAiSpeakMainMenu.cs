﻿using MPAid.Cores;
using MPAid.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPAid.NewForms
{
    public partial class MPAiSpeakMainMenu : Form
    {
        private bool appClosing = true;

        public MPAiSpeakMainMenu()
        {
            InitializeComponent();

            // Disable score report button if the report has not been created before.
            reportButton.Enabled = (File.Exists(ReportLauncher.MPAiSpeakScoreReportHTMLAddress) && File.Exists(ReportLauncher.ScoreboardReportCSSAddress));

            string name = UserManagement.getCurrentUser().getName();
            if (name == null)
            {
                greetingLabel.Text = "Kia Ora, User!";
            }
            else
            {
                greetingLabel.Text = "Kia Ora, " + name + "!";
            }
        }

        /// <summary>
        /// Launches the score report in the user's default browser.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void reportButton_Click(object sender, EventArgs e)
        {
            IoController.ShowInBrowser(ReportLauncher.MPAiSpeakScoreReportHTMLAddress);
        }

        /// <summary>
        /// Shows the learning aid for MPAi Speak - the Audio Player.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void learnButton_Click(object sender, EventArgs e)
        {
            new AudioPlayer().Show();
            closeThis();
        }

        /// <summary>
        /// Shows the testing aid for MPAi Speak - the Speech Recognition Test.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void testButton_Click(object sender, EventArgs e)
        {
            new SpeechRecognitionTest().Show();
            closeThis();
        }

        /// <summary>
        /// Closes the form, but not the application.
        /// </summary>
        protected void closeThis()
        {
            appClosing = false; // Tell the FormClosing event not to end the program.
            Close();
        }

        /// <summary>
        /// Fires when the form closes. 
        /// If the user pressed the back button, the next form will be loaded. 
        /// If the user closed the form in some other way, the app will temrinate.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void MPAiSpeakMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (appClosing)
            {
                UserManagement.WriteSettings();
                Properties.Settings.Default.Save();
                Application.Exit();
            }
        }
    }
}
