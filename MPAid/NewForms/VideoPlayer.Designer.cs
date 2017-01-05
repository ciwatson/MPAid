namespace MPAid.NewForms
{
    partial class VideoPlayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.VideoPlayerPanel = new System.Windows.Forms.SplitContainer();
            this.backButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.vowelComboBox = new System.Windows.Forms.ComboBox();
            this.divider4 = new System.Windows.Forms.Label();
            this.divider3 = new System.Windows.Forms.Label();
            this.divider2 = new System.Windows.Forms.Label();
            this.divider1 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.recordingProgressBarLabel = new System.Windows.Forms.Label();
            this.playNextRadioButtonNo = new System.Windows.Forms.RadioButton();
            this.soundListAddAllButton = new System.Windows.Forms.Button();
            this.playNextRadioButtonYes = new System.Windows.Forms.RadioButton();
            this.soundListRemoveButton = new System.Windows.Forms.Button();
            this.soundListAddButton = new System.Windows.Forms.Button();
            this.soundListAllListBox = new System.Windows.Forms.ListBox();
            this.soundListCurrentListBox = new System.Windows.Forms.ListBox();
            this.soundListAllLabel = new System.Windows.Forms.Label();
            this.soundListCurrentLabel = new System.Windows.Forms.Label();
            this.playNextLabel = new System.Windows.Forms.Label();
            this.addFromFileButton = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.AudioInputDeviceButton = new System.Windows.Forms.Button();
            this.AudioInputDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.AudioInputDeviceLabel = new System.Windows.Forms.Label();
            this.repeatSpinner = new System.Windows.Forms.DomainUpDown();
            this.repeatLabel = new System.Windows.Forms.Label();
            this.repeatTrackBar = new System.Windows.Forms.TrackBar();
            this.vlcPlayer1 = new MPAid.UserControls.VlcPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlayerPanel)).BeginInit();
            this.VideoPlayerPanel.Panel1.SuspendLayout();
            this.VideoPlayerPanel.Panel2.SuspendLayout();
            this.VideoPlayerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repeatTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // VideoPlayerPanel
            // 
            this.VideoPlayerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VideoPlayerPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.VideoPlayerPanel.Location = new System.Drawing.Point(0, 0);
            this.VideoPlayerPanel.Name = "VideoPlayerPanel";
            this.VideoPlayerPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // VideoPlayerPanel.Panel1
            // 
            this.VideoPlayerPanel.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.VideoPlayerPanel.Panel1.Controls.Add(this.backButton);
            this.VideoPlayerPanel.Panel1.Controls.Add(this.optionsButton);
            this.VideoPlayerPanel.Panel1.Controls.Add(this.vowelComboBox);
            this.VideoPlayerPanel.Panel1.Controls.Add(this.vlcPlayer1);
            // 
            // VideoPlayerPanel.Panel2
            // 
            this.VideoPlayerPanel.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.VideoPlayerPanel.Panel2.Controls.Add(this.divider4);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.divider3);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.divider2);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.divider1);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.addButton);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.recordingProgressBarLabel);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.playNextRadioButtonNo);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.soundListAddAllButton);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.playNextRadioButtonYes);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.soundListRemoveButton);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.soundListAddButton);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.soundListAllListBox);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.soundListCurrentListBox);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.soundListAllLabel);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.soundListCurrentLabel);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.playNextLabel);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.addFromFileButton);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.recordButton);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.AudioInputDeviceButton);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.AudioInputDeviceComboBox);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.AudioInputDeviceLabel);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.repeatSpinner);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.repeatLabel);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.repeatTrackBar);
            this.VideoPlayerPanel.Panel2MinSize = 250;
            this.VideoPlayerPanel.Size = new System.Drawing.Size(584, 562);
            this.VideoPlayerPanel.SplitterDistance = 303;
            this.VideoPlayerPanel.SplitterWidth = 1;
            this.VideoPlayerPanel.TabIndex = 0;
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.backButton.Location = new System.Drawing.Point(474, 268);
            this.backButton.Margin = new System.Windows.Forms.Padding(10);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(100, 25);
            this.backButton.TabIndex = 7;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optionsButton.Location = new System.Drawing.Point(370, 268);
            this.optionsButton.Margin = new System.Windows.Forms.Padding(10);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(100, 25);
            this.optionsButton.TabIndex = 6;
            this.optionsButton.Text = "Less...";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // vowelComboBox
            // 
            this.vowelComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vowelComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.vowelComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.vowelComboBox.FormattingEnabled = true;
            this.vowelComboBox.ItemHeight = 13;
            this.vowelComboBox.Location = new System.Drawing.Point(117, 12);
            this.vowelComboBox.Name = "vowelComboBox";
            this.vowelComboBox.Size = new System.Drawing.Size(353, 21);
            this.vowelComboBox.TabIndex = 1;
            this.vowelComboBox.SelectedIndexChanged += new System.EventHandler(this.vowelComboBox_SelectedIndexChanged);
            this.vowelComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VowelComboBox_KeyPress);
            this.vowelComboBox.Leave += new System.EventHandler(this.VowelComboBox_Leave);
            // 
            // divider4
            // 
            this.divider4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divider4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider4.Location = new System.Drawing.Point(1, 153);
            this.divider4.Name = "divider4";
            this.divider4.Size = new System.Drawing.Size(584, 2);
            this.divider4.TabIndex = 42;
            // 
            // divider3
            // 
            this.divider3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divider3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider3.Location = new System.Drawing.Point(1, 130);
            this.divider3.Name = "divider3";
            this.divider3.Size = new System.Drawing.Size(584, 2);
            this.divider3.TabIndex = 41;
            // 
            // divider2
            // 
            this.divider2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divider2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider2.Location = new System.Drawing.Point(1, 26);
            this.divider2.Name = "divider2";
            this.divider2.Size = new System.Drawing.Size(584, 2);
            this.divider2.TabIndex = 40;
            // 
            // divider1
            // 
            this.divider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divider1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider1.Location = new System.Drawing.Point(2, 63);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(584, 2);
            this.divider1.TabIndex = 39;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addButton.Location = new System.Drawing.Point(467, 73);
            this.addButton.Margin = new System.Windows.Forms.Padding(0);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 25);
            this.addButton.TabIndex = 38;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // recordingProgressBarLabel
            // 
            this.recordingProgressBarLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recordingProgressBarLabel.BackColor = System.Drawing.SystemColors.Control;
            this.recordingProgressBarLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.recordingProgressBarLabel.Location = new System.Drawing.Point(100, 74);
            this.recordingProgressBarLabel.Name = "recordingProgressBarLabel";
            this.recordingProgressBarLabel.Size = new System.Drawing.Size(361, 23);
            this.recordingProgressBarLabel.TabIndex = 37;
            this.recordingProgressBarLabel.Text = "No current file";
            this.recordingProgressBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playNextRadioButtonNo
            // 
            this.playNextRadioButtonNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.playNextRadioButtonNo.AutoSize = true;
            this.playNextRadioButtonNo.Location = new System.Drawing.Point(527, 133);
            this.playNextRadioButtonNo.Name = "playNextRadioButtonNo";
            this.playNextRadioButtonNo.Size = new System.Drawing.Size(39, 17);
            this.playNextRadioButtonNo.TabIndex = 1;
            this.playNextRadioButtonNo.TabStop = true;
            this.playNextRadioButtonNo.Text = "No";
            this.playNextRadioButtonNo.UseVisualStyleBackColor = true;
            // 
            // soundListAddAllButton
            // 
            this.soundListAddAllButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.soundListAddAllButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.soundListAddAllButton.Location = new System.Drawing.Point(261, 230);
            this.soundListAddAllButton.Margin = new System.Windows.Forms.Padding(10);
            this.soundListAddAllButton.Name = "soundListAddAllButton";
            this.soundListAddAllButton.Size = new System.Drawing.Size(91, 25);
            this.soundListAddAllButton.TabIndex = 21;
            this.soundListAddAllButton.Text = "Add All";
            this.soundListAddAllButton.UseVisualStyleBackColor = true;
            // 
            // playNextRadioButtonYes
            // 
            this.playNextRadioButtonYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.playNextRadioButtonYes.AutoSize = true;
            this.playNextRadioButtonYes.Location = new System.Drawing.Point(467, 133);
            this.playNextRadioButtonYes.Name = "playNextRadioButtonYes";
            this.playNextRadioButtonYes.Size = new System.Drawing.Size(43, 17);
            this.playNextRadioButtonYes.TabIndex = 0;
            this.playNextRadioButtonYes.TabStop = true;
            this.playNextRadioButtonYes.Text = "Yes";
            this.playNextRadioButtonYes.UseVisualStyleBackColor = true;
            // 
            // soundListRemoveButton
            // 
            this.soundListRemoveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.soundListRemoveButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.soundListRemoveButton.Location = new System.Drawing.Point(261, 202);
            this.soundListRemoveButton.Margin = new System.Windows.Forms.Padding(10);
            this.soundListRemoveButton.Name = "soundListRemoveButton";
            this.soundListRemoveButton.Size = new System.Drawing.Size(91, 25);
            this.soundListRemoveButton.TabIndex = 20;
            this.soundListRemoveButton.Text = "Remove Selected";
            this.soundListRemoveButton.UseVisualStyleBackColor = true;
            // 
            // soundListAddButton
            // 
            this.soundListAddButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.soundListAddButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.soundListAddButton.Location = new System.Drawing.Point(261, 173);
            this.soundListAddButton.Margin = new System.Windows.Forms.Padding(10);
            this.soundListAddButton.Name = "soundListAddButton";
            this.soundListAddButton.Size = new System.Drawing.Size(91, 25);
            this.soundListAddButton.TabIndex = 19;
            this.soundListAddButton.Text = "Add Selected";
            this.soundListAddButton.UseVisualStyleBackColor = true;
            // 
            // soundListAllListBox
            // 
            this.soundListAllListBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.soundListAllListBox.FormattingEnabled = true;
            this.soundListAllListBox.Location = new System.Drawing.Point(362, 173);
            this.soundListAllListBox.Name = "soundListAllListBox";
            this.soundListAllListBox.Size = new System.Drawing.Size(206, 82);
            this.soundListAllListBox.TabIndex = 18;
            // 
            // soundListCurrentListBox
            // 
            this.soundListCurrentListBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.soundListCurrentListBox.FormattingEnabled = true;
            this.soundListCurrentListBox.Location = new System.Drawing.Point(15, 173);
            this.soundListCurrentListBox.Name = "soundListCurrentListBox";
            this.soundListCurrentListBox.Size = new System.Drawing.Size(233, 82);
            this.soundListCurrentListBox.TabIndex = 17;
            // 
            // soundListAllLabel
            // 
            this.soundListAllLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.soundListAllLabel.AutoSize = true;
            this.soundListAllLabel.Location = new System.Drawing.Point(359, 157);
            this.soundListAllLabel.Name = "soundListAllLabel";
            this.soundListAllLabel.Size = new System.Drawing.Size(58, 13);
            this.soundListAllLabel.TabIndex = 16;
            this.soundListAllLabel.Text = "All sounds:";
            // 
            // soundListCurrentLabel
            // 
            this.soundListCurrentLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.soundListCurrentLabel.AutoSize = true;
            this.soundListCurrentLabel.Location = new System.Drawing.Point(15, 157);
            this.soundListCurrentLabel.Name = "soundListCurrentLabel";
            this.soundListCurrentLabel.Size = new System.Drawing.Size(99, 13);
            this.soundListCurrentLabel.TabIndex = 15;
            this.soundListCurrentLabel.Text = "Sounds to practice:";
            // 
            // playNextLabel
            // 
            this.playNextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.playNextLabel.AutoSize = true;
            this.playNextLabel.Location = new System.Drawing.Point(13, 135);
            this.playNextLabel.Name = "playNextLabel";
            this.playNextLabel.Size = new System.Drawing.Size(159, 13);
            this.playNextLabel.TabIndex = 13;
            this.playNextLabel.Text = "Play  next sound when finished?";
            // 
            // addFromFileButton
            // 
            this.addFromFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addFromFileButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addFromFileButton.Location = new System.Drawing.Point(467, 100);
            this.addFromFileButton.Margin = new System.Windows.Forms.Padding(0);
            this.addFromFileButton.Name = "addFromFileButton";
            this.addFromFileButton.Size = new System.Drawing.Size(100, 25);
            this.addFromFileButton.TabIndex = 12;
            this.addFromFileButton.Text = "Select from file";
            this.addFromFileButton.UseVisualStyleBackColor = true;
            // 
            // recordButton
            // 
            this.recordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.recordButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.recordButton.Location = new System.Drawing.Point(361, 100);
            this.recordButton.Margin = new System.Windows.Forms.Padding(0);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(100, 25);
            this.recordButton.TabIndex = 11;
            this.recordButton.Text = "Record";
            this.recordButton.UseVisualStyleBackColor = true;
            // 
            // AudioInputDeviceButton
            // 
            this.AudioInputDeviceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioInputDeviceButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AudioInputDeviceButton.Location = new System.Drawing.Point(301, 100);
            this.AudioInputDeviceButton.Margin = new System.Windows.Forms.Padding(10);
            this.AudioInputDeviceButton.Name = "AudioInputDeviceButton";
            this.AudioInputDeviceButton.Size = new System.Drawing.Size(50, 25);
            this.AudioInputDeviceButton.TabIndex = 10;
            this.AudioInputDeviceButton.Text = "Refresh";
            this.AudioInputDeviceButton.UseVisualStyleBackColor = true;
            // 
            // AudioInputDeviceComboBox
            // 
            this.AudioInputDeviceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioInputDeviceComboBox.FormattingEnabled = true;
            this.AudioInputDeviceComboBox.Location = new System.Drawing.Point(15, 100);
            this.AudioInputDeviceComboBox.Name = "AudioInputDeviceComboBox";
            this.AudioInputDeviceComboBox.Size = new System.Drawing.Size(282, 21);
            this.AudioInputDeviceComboBox.TabIndex = 9;
            // 
            // AudioInputDeviceLabel
            // 
            this.AudioInputDeviceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AudioInputDeviceLabel.AutoSize = true;
            this.AudioInputDeviceLabel.Location = new System.Drawing.Point(13, 79);
            this.AudioInputDeviceLabel.Name = "AudioInputDeviceLabel";
            this.AudioInputDeviceLabel.Size = new System.Drawing.Size(81, 13);
            this.AudioInputDeviceLabel.TabIndex = 8;
            this.AudioInputDeviceLabel.Text = "Add your voice:";
            // 
            // repeatSpinner
            // 
            this.repeatSpinner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.repeatSpinner.Location = new System.Drawing.Point(479, 38);
            this.repeatSpinner.Name = "repeatSpinner";
            this.repeatSpinner.Size = new System.Drawing.Size(87, 20);
            this.repeatSpinner.TabIndex = 2;
            this.repeatSpinner.Text = "domainUpDown1";
            // 
            // repeatLabel
            // 
            this.repeatLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.repeatLabel.AutoSize = true;
            this.repeatLabel.Location = new System.Drawing.Point(13, 40);
            this.repeatLabel.Name = "repeatLabel";
            this.repeatLabel.Size = new System.Drawing.Size(42, 13);
            this.repeatLabel.TabIndex = 1;
            this.repeatLabel.Text = "Repeat";
            // 
            // repeatTrackBar
            // 
            this.repeatTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.repeatTrackBar.Location = new System.Drawing.Point(62, 31);
            this.repeatTrackBar.Name = "repeatTrackBar";
            this.repeatTrackBar.Size = new System.Drawing.Size(399, 45);
            this.repeatTrackBar.TabIndex = 0;
            // 
            // vlcPlayer1
            // 
            this.vlcPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vlcPlayer1.CurrentRecordingIndex = 0;
            this.vlcPlayer1.Location = new System.Drawing.Point(0, 39);
            this.vlcPlayer1.Name = "vlcPlayer1";
            this.vlcPlayer1.Size = new System.Drawing.Size(585, 229);
            this.vlcPlayer1.TabIndex = 8;
            this.vlcPlayer1.WordsList = null;
            // 
            // VideoPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.VideoPlayerPanel);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "VideoPlayer";
            this.Text = "MPAi Sound";
            this.VideoPlayerPanel.Panel1.ResumeLayout(false);
            this.VideoPlayerPanel.Panel2.ResumeLayout(false);
            this.VideoPlayerPanel.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlayerPanel)).EndInit();
            this.VideoPlayerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repeatTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer VideoPlayerPanel;
        private System.Windows.Forms.ComboBox vowelComboBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.DomainUpDown repeatSpinner;
        private System.Windows.Forms.Label repeatLabel;
        private System.Windows.Forms.TrackBar repeatTrackBar;
        private System.Windows.Forms.Button AudioInputDeviceButton;
        private System.Windows.Forms.ComboBox AudioInputDeviceComboBox;
        private System.Windows.Forms.Label AudioInputDeviceLabel;
        private System.Windows.Forms.Button soundListAddAllButton;
        private System.Windows.Forms.Button soundListRemoveButton;
        private System.Windows.Forms.Button soundListAddButton;
        private System.Windows.Forms.ListBox soundListAllListBox;
        private System.Windows.Forms.ListBox soundListCurrentListBox;
        private System.Windows.Forms.Label soundListAllLabel;
        private System.Windows.Forms.Label soundListCurrentLabel;
        private System.Windows.Forms.RadioButton playNextRadioButtonNo;
        private System.Windows.Forms.RadioButton playNextRadioButtonYes;
        private System.Windows.Forms.Label playNextLabel;
        private System.Windows.Forms.Button addFromFileButton;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label recordingProgressBarLabel;
        private System.Windows.Forms.Label divider1;
        private System.Windows.Forms.Label divider4;
        private System.Windows.Forms.Label divider3;
        private System.Windows.Forms.Label divider2;
        private UserControls.VlcPlayer vlcPlayer1;
    }
}