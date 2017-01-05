﻿using MPAid.Cores;
using MPAid.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPAid.NewForms
{
    public partial class VideoPlayer : Form
    {
        // Strings kept in fields to make text easier to change.
        private string vowelNotFoundText = "That sound is not valid. Try another, or select from the list.";
        private string optionsLess = "Less...";
        private string optionsMore = "More...";

        /// <summary>
        /// Holds the height of the bottom panel between clicks of the options button.
        /// </summary>
        private int bottomHeight;

        public ComboBox VowelComboBox {
            get { return vowelComboBox; }
        }

        public VideoPlayer()
        {
            InitializeComponent();

            populateVowelComboBox();
            repeatSpinner.SelectedIndex = repeatSpinner.Items.Count - 1;    // No way to set this in form properties

            vlcPlayer1.RepeatChanged += new PropertyChangedEventHandler(updateRepeatControls);  // Subscribe to the "RepeatChanged" event in the VLC player.

            bottomHeight = VideoPlayerPanel.Height - VideoPlayerPanel.SplitterDistance;
            toggleOptions();    // For development, the bottom panel is visible, but the user won't need the bottom panel most of the time.
        }

        /// <summary>
        /// Gets the words from the database.
        /// </summary>
        private void populateVowelComboBox()
        {
            try
            {
                // Create new database context.
                using (MPAidModel DBModel = new MPAidModel())
                {
                    DBModel.Database.Initialize(false); // Added for safety; if the database has not been initialised, initialise it.

                    MPAiUser current = UserManagement.getCurrentUser();

                    List<Word> view = DBModel.Word.Where(x => (
                       x.Category.Name.Equals("Vowel")
                       //&& x.Recordings.Any(y => y.Speaker.SpeakerId == current.Speaker.SpeakerId)  // Until the Menubar is finished, this won't work. Comment this line out to test.
                       )).ToList();

                    view.Sort(new VowelComparer());
                    vowelComboBox.DataSource = new BindingSource() { DataSource = view };
                    vowelComboBox.DisplayMember = "Name";

                    // Update the VLC player's list of words to the ones in the combo box.
                    vlcPlayer1.WordsList = view;

                    // Add listener to the VLC Player's index, so the combo box updates too.
                    vlcPlayer1.IndexChanged += new PropertyChangedEventHandler(updateComboBoxIndex);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        /// <summary>
        /// Prevents two lists appearing onscreen at once by closing the main list when the suggestion list is visible.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void VowelComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            vowelComboBox.DroppedDown = false;
        }

        /// <summary>
        /// Ensures only valid words are entered, by comparing the text to the names of all words when focus is lost.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VowelComboBox_Leave(object sender, EventArgs e)
        {
            //Prevents the user getting stuck when there are no words.
            if (vowelComboBox.Items.Count < 1)
            {
                return;
            }
            foreach (Word w in vowelComboBox.Items)
            {
                if (w.Name.Equals(vowelComboBox.Text))
                {
                    return;
                }
            }
            MessageBox.Show(vowelNotFoundText);
            vowelComboBox.Focus();
        }

        /// <summary>
        /// Changing the index of the combo box will cause a different word to be played by the audio player.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void vowelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            vlcPlayer1.CurrentRecordingIndex = vowelComboBox.SelectedIndex;
        }

        /// <summary>
        /// When the audio player changes the word it is playing, the combobox is updated to reflect this.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void updateComboBoxIndex(object sender, EventArgs e)
        {
            vowelComboBox.SelectedIndex = vlcPlayer1.CurrentRecordingIndex;
        }

        /// <summary>
        /// Handles the functionality for the options button.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void optionsButton_Click(object sender, EventArgs e)
        {
            toggleOptions();
        }

        /// <summary>
        /// Shows/hides the options panel, changes button text, and resizes the form as appropriate.
        /// </summary>
        private void toggleOptions()
        {
            // Prevent relative resizing issues by storing the current height of the top panel.
            int panel1Size = VideoPlayerPanel.SplitterDistance;
            if (VideoPlayerPanel.Panel2Collapsed)
            {
                Height += bottomHeight;
                MinimumSize = new Size(MinimumSize.Width, 600);
                optionsButton.Text = optionsLess;
            }
            else
            {
                MinimumSize = new Size(MinimumSize.Width, 300);
                bottomHeight = VideoPlayerPanel.Height - VideoPlayerPanel.SplitterDistance;
                Height -= bottomHeight;
                optionsButton.Text = optionsMore;
            }
            VideoPlayerPanel.Panel2Collapsed = !VideoPlayerPanel.Panel2Collapsed;
        }

        /// <summary>
        /// Handles the functionality for the back button.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void backButton_Click(object sender, EventArgs e)
        {
            // Show other form on this line.
            Close();
        }

        /// <summary>
        /// When the track bar's value changes, also change the spinner to match.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void repeatTrackBar_ValueChanged(object sender, EventArgs e)
        {
            vlcPlayer1.RepeatTimes = repeatTrackBar.Value;
        }

        /// <summary>
        /// When the spinner changes, also change the track bar to match.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void repeatSpinner_SelectedItemChanged(object sender, EventArgs e)
        {
            vlcPlayer1.RepeatTimes = (repeatSpinner.Items.Count - 1) - repeatSpinner.SelectedIndex;
        }

        /// <summary>
        /// When the VLC player changes it's repeat value, update both repeat controls: the trackbar and the spinner.
        /// </summary>
        /// <param name="sender">Automatically generated by Visual Studio.</param>
        /// <param name="e">Automatically generated by Visual Studio.</param>
        private void updateRepeatControls(object sender, EventArgs e)
        {
            repeatSpinner.SelectedIndex = (repeatSpinner.Items.Count - 1) - vlcPlayer1.RepeatTimes;
            repeatTrackBar.Value = vlcPlayer1.RepeatTimes;
        }
    }
}
