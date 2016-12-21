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
            this.WordComboBox = new System.Windows.Forms.ComboBox();
            this.vlcPlayer = new MPAid.UserControls.VlcPlayer();
            this.backButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.repeatTrackBar = new System.Windows.Forms.TrackBar();
            this.repeatLabel = new System.Windows.Forms.Label();
            this.repeatSpinner = new System.Windows.Forms.DomainUpDown();
            this.AudioInputDeviceButton = new System.Windows.Forms.Button();
            this.AudioInputDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.AudioInputDeviceLabel = new System.Windows.Forms.Label();
            this.recordButton = new System.Windows.Forms.Button();
            this.addFromFileButton = new System.Windows.Forms.Button();
            this.playNextLabel = new System.Windows.Forms.Label();
            this.playNextRadioButtonYes = new System.Windows.Forms.RadioButton();
            this.playNextRadioButtonNo = new System.Windows.Forms.RadioButton();
            this.soundListCurrentLabel = new System.Windows.Forms.Label();
            this.soundListAllLabel = new System.Windows.Forms.Label();
            this.soundListCurrentListBox = new System.Windows.Forms.ListBox();
            this.soundListAllListBox = new System.Windows.Forms.ListBox();
            this.soundListAddButton = new System.Windows.Forms.Button();
            this.soundListRemoveButton = new System.Windows.Forms.Button();
            this.soundListAddAllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlayerPanel)).BeginInit();
            this.VideoPlayerPanel.Panel1.SuspendLayout();
            this.VideoPlayerPanel.Panel2.SuspendLayout();
            this.VideoPlayerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repeatTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // VideoPlayerPanel
            // 
            this.VideoPlayerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoPlayerPanel.Location = new System.Drawing.Point(0, 0);
            this.VideoPlayerPanel.Name = "VideoPlayerPanel";
            this.VideoPlayerPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // VideoPlayerPanel.Panel1
            // 
            this.VideoPlayerPanel.Panel1.Controls.Add(this.backButton);
            this.VideoPlayerPanel.Panel1.Controls.Add(this.optionsButton);
            this.VideoPlayerPanel.Panel1.Controls.Add(this.vlcPlayer);
            this.VideoPlayerPanel.Panel1.Controls.Add(this.WordComboBox);
            // 
            // VideoPlayerPanel.Panel2
            // 
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
            this.VideoPlayerPanel.Size = new System.Drawing.Size(584, 562);
            this.VideoPlayerPanel.SplitterDistance = 307;
            this.VideoPlayerPanel.TabIndex = 0;
            // 
            // WordComboBox
            // 
            this.WordComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WordComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.WordComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.WordComboBox.FormattingEnabled = true;
            this.WordComboBox.ItemHeight = 13;
            this.WordComboBox.Location = new System.Drawing.Point(117, 12);
            this.WordComboBox.Name = "WordComboBox";
            this.WordComboBox.Size = new System.Drawing.Size(353, 21);
            this.WordComboBox.TabIndex = 1;
            // 
            // vlcPlayer
            // 
            this.vlcPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vlcPlayer.Location = new System.Drawing.Point(12, 39);
            this.vlcPlayer.Name = "vlcPlayer";
            this.vlcPlayer.Size = new System.Drawing.Size(560, 216);
            this.vlcPlayer.TabIndex = 2;
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.backButton.Location = new System.Drawing.Point(465, 268);
            this.backButton.Margin = new System.Windows.Forms.Padding(10);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(100, 25);
            this.backButton.TabIndex = 7;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // optionsButton
            // 
            this.optionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optionsButton.Location = new System.Drawing.Point(359, 268);
            this.optionsButton.Margin = new System.Windows.Forms.Padding(10);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(100, 25);
            this.optionsButton.TabIndex = 6;
            this.optionsButton.Text = "Less...";
            this.optionsButton.UseVisualStyleBackColor = true;
            // 
            // repeatTrackBar
            // 
            this.repeatTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.repeatTrackBar.Location = new System.Drawing.Point(60, 15);
            this.repeatTrackBar.Name = "repeatTrackBar";
            this.repeatTrackBar.Size = new System.Drawing.Size(399, 45);
            this.repeatTrackBar.TabIndex = 0;
            // 
            // repeatLabel
            // 
            this.repeatLabel.AutoSize = true;
            this.repeatLabel.Location = new System.Drawing.Point(12, 24);
            this.repeatLabel.Name = "repeatLabel";
            this.repeatLabel.Size = new System.Drawing.Size(42, 13);
            this.repeatLabel.TabIndex = 1;
            this.repeatLabel.Text = "Repeat";
            // 
            // repeatSpinner
            // 
            this.repeatSpinner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.repeatSpinner.Location = new System.Drawing.Point(478, 22);
            this.repeatSpinner.Name = "repeatSpinner";
            this.repeatSpinner.Size = new System.Drawing.Size(87, 20);
            this.repeatSpinner.TabIndex = 2;
            this.repeatSpinner.Text = "domainUpDown1";
            // 
            // AudioInputDeviceButton
            // 
            this.AudioInputDeviceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioInputDeviceButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AudioInputDeviceButton.Location = new System.Drawing.Point(258, 65);
            this.AudioInputDeviceButton.Margin = new System.Windows.Forms.Padding(10);
            this.AudioInputDeviceButton.Name = "AudioInputDeviceButton";
            this.AudioInputDeviceButton.Size = new System.Drawing.Size(50, 25);
            this.AudioInputDeviceButton.TabIndex = 10;
            this.AudioInputDeviceButton.Text = "Refresh";
            this.AudioInputDeviceButton.UseVisualStyleBackColor = true;
            // 
            // AudioInputDeviceComboBox
            // 
            this.AudioInputDeviceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioInputDeviceComboBox.FormattingEnabled = true;
            this.AudioInputDeviceComboBox.Location = new System.Drawing.Point(99, 67);
            this.AudioInputDeviceComboBox.Name = "AudioInputDeviceComboBox";
            this.AudioInputDeviceComboBox.Size = new System.Drawing.Size(156, 21);
            this.AudioInputDeviceComboBox.TabIndex = 9;
            // 
            // AudioInputDeviceLabel
            // 
            this.AudioInputDeviceLabel.AutoSize = true;
            this.AudioInputDeviceLabel.Location = new System.Drawing.Point(12, 71);
            this.AudioInputDeviceLabel.Name = "AudioInputDeviceLabel";
            this.AudioInputDeviceLabel.Size = new System.Drawing.Size(81, 13);
            this.AudioInputDeviceLabel.TabIndex = 8;
            this.AudioInputDeviceLabel.Text = "Add your voice:";
            // 
            // recordButton
            // 
            this.recordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.recordButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.recordButton.Location = new System.Drawing.Point(344, 65);
            this.recordButton.Margin = new System.Windows.Forms.Padding(0);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(100, 25);
            this.recordButton.TabIndex = 11;
            this.recordButton.Text = "Record";
            this.recordButton.UseVisualStyleBackColor = true;
            // 
            // addFromFileButton
            // 
            this.addFromFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addFromFileButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addFromFileButton.Location = new System.Drawing.Point(465, 65);
            this.addFromFileButton.Margin = new System.Windows.Forms.Padding(0);
            this.addFromFileButton.Name = "addFromFileButton";
            this.addFromFileButton.Size = new System.Drawing.Size(100, 25);
            this.addFromFileButton.TabIndex = 12;
            this.addFromFileButton.Text = "Record";
            this.addFromFileButton.UseVisualStyleBackColor = true;
            // 
            // playNextLabel
            // 
            this.playNextLabel.AutoSize = true;
            this.playNextLabel.Location = new System.Drawing.Point(12, 105);
            this.playNextLabel.Name = "playNextLabel";
            this.playNextLabel.Size = new System.Drawing.Size(159, 13);
            this.playNextLabel.TabIndex = 13;
            this.playNextLabel.Text = "Play  next sound when finished?";
            // 
            // playNextRadioButtonYes
            // 
            this.playNextRadioButtonYes.AutoSize = true;
            this.playNextRadioButtonYes.Location = new System.Drawing.Point(466, 103);
            this.playNextRadioButtonYes.Name = "playNextRadioButtonYes";
            this.playNextRadioButtonYes.Size = new System.Drawing.Size(43, 17);
            this.playNextRadioButtonYes.TabIndex = 0;
            this.playNextRadioButtonYes.TabStop = true;
            this.playNextRadioButtonYes.Text = "Yes";
            this.playNextRadioButtonYes.UseVisualStyleBackColor = true;
            // 
            // playNextRadioButtonNo
            // 
            this.playNextRadioButtonNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.playNextRadioButtonNo.AutoSize = true;
            this.playNextRadioButtonNo.Location = new System.Drawing.Point(526, 103);
            this.playNextRadioButtonNo.Name = "playNextRadioButtonNo";
            this.playNextRadioButtonNo.Size = new System.Drawing.Size(39, 17);
            this.playNextRadioButtonNo.TabIndex = 1;
            this.playNextRadioButtonNo.TabStop = true;
            this.playNextRadioButtonNo.Text = "No";
            this.playNextRadioButtonNo.UseVisualStyleBackColor = true;
            // 
            // soundListCurrentLabel
            // 
            this.soundListCurrentLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.soundListCurrentLabel.AutoSize = true;
            this.soundListCurrentLabel.Location = new System.Drawing.Point(12, 127);
            this.soundListCurrentLabel.Name = "soundListCurrentLabel";
            this.soundListCurrentLabel.Size = new System.Drawing.Size(99, 13);
            this.soundListCurrentLabel.TabIndex = 15;
            this.soundListCurrentLabel.Text = "Sounds to practice:";
            // 
            // soundListAllLabel
            // 
            this.soundListAllLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.soundListAllLabel.AutoSize = true;
            this.soundListAllLabel.Location = new System.Drawing.Point(356, 127);
            this.soundListAllLabel.Name = "soundListAllLabel";
            this.soundListAllLabel.Size = new System.Drawing.Size(58, 13);
            this.soundListAllLabel.TabIndex = 16;
            this.soundListAllLabel.Text = "All sounds:";
            // 
            // soundListCurrentListBox
            // 
            this.soundListCurrentListBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.soundListCurrentListBox.FormattingEnabled = true;
            this.soundListCurrentListBox.Location = new System.Drawing.Point(12, 144);
            this.soundListCurrentListBox.Name = "soundListCurrentListBox";
            this.soundListCurrentListBox.Size = new System.Drawing.Size(233, 95);
            this.soundListCurrentListBox.TabIndex = 17;
            // 
            // soundListAllListBox
            // 
            this.soundListAllListBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.soundListAllListBox.FormattingEnabled = true;
            this.soundListAllListBox.Location = new System.Drawing.Point(359, 144);
            this.soundListAllListBox.Name = "soundListAllListBox";
            this.soundListAllListBox.Size = new System.Drawing.Size(206, 95);
            this.soundListAllListBox.TabIndex = 18;
            // 
            // soundListAddButton
            // 
            this.soundListAddButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.soundListAddButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.soundListAddButton.Location = new System.Drawing.Point(258, 144);
            this.soundListAddButton.Margin = new System.Windows.Forms.Padding(10);
            this.soundListAddButton.Name = "soundListAddButton";
            this.soundListAddButton.Size = new System.Drawing.Size(91, 25);
            this.soundListAddButton.TabIndex = 19;
            this.soundListAddButton.Text = "Add Selected";
            this.soundListAddButton.UseVisualStyleBackColor = true;
            // 
            // soundListRemoveButton
            // 
            this.soundListRemoveButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.soundListRemoveButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.soundListRemoveButton.Location = new System.Drawing.Point(258, 179);
            this.soundListRemoveButton.Margin = new System.Windows.Forms.Padding(10);
            this.soundListRemoveButton.Name = "soundListRemoveButton";
            this.soundListRemoveButton.Size = new System.Drawing.Size(91, 25);
            this.soundListRemoveButton.TabIndex = 20;
            this.soundListRemoveButton.Text = "Remove Selected";
            this.soundListRemoveButton.UseVisualStyleBackColor = true;
            // 
            // soundListAddAllButton
            // 
            this.soundListAddAllButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.soundListAddAllButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.soundListAddAllButton.Location = new System.Drawing.Point(258, 214);
            this.soundListAddAllButton.Margin = new System.Windows.Forms.Padding(10);
            this.soundListAddAllButton.Name = "soundListAddAllButton";
            this.soundListAddAllButton.Size = new System.Drawing.Size(91, 25);
            this.soundListAddAllButton.TabIndex = 21;
            this.soundListAddAllButton.Text = "Add All";
            this.soundListAddAllButton.UseVisualStyleBackColor = true;
            // 
            // VideoPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.VideoPlayerPanel);
            this.MinimumSize = new System.Drawing.Size(375, 600);
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
        private System.Windows.Forms.ComboBox WordComboBox;
        private UserControls.VlcPlayer vlcPlayer;
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
    }
}