﻿namespace MPAi.NewForms
{
    partial class AudioPlayer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioPlayer));
            this.VideoPlayerPanel = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.vlcControl = new Vlc.DotNet.Forms.VlcControl();
            this.backwardButton = new System.Windows.Forms.Button();
            this.backImageList = new System.Windows.Forms.ImageList(this.components);
            this.playButton = new System.Windows.Forms.Button();
            this.playImageList = new System.Windows.Forms.ImageList(this.components);
            this.forwardButton = new System.Windows.Forms.Button();
            this.forwardImageList = new System.Windows.Forms.ImageList(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.VowelComboBox = new System.Windows.Forms.ComboBox();
            this.optionsButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.playNextCheckBox = new System.Windows.Forms.CheckBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.divider4 = new System.Windows.Forms.Label();
            this.divider3 = new System.Windows.Forms.Label();
            this.divider2 = new System.Windows.Forms.Label();
            this.divider1 = new System.Windows.Forms.Label();
            this.soundListAddAllButton = new System.Windows.Forms.Button();
            this.soundListRemoveButton = new System.Windows.Forms.Button();
            this.soundListAddButton = new System.Windows.Forms.Button();
            this.soundListAllListBox = new System.Windows.Forms.ListBox();
            this.soundListCurrentListBox = new System.Windows.Forms.ListBox();
            this.soundListAllLabel = new System.Windows.Forms.Label();
            this.soundListCurrentLabel = new System.Windows.Forms.Label();
            this.addFromFileButton = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.AudioInputDeviceButton = new System.Windows.Forms.Button();
            this.AudioInputDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.AudioInputDeviceLabel = new System.Windows.Forms.Label();
            this.repeatSpinner = new System.Windows.Forms.DomainUpDown();
            this.repeatLabel = new System.Windows.Forms.Label();
            this.recordingProgressBarLabel = new System.Windows.Forms.Label();
            this.repeatTrackBar = new System.Windows.Forms.TrackBar();
            this.recordingProgressBar = new System.Windows.Forms.ProgressBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new MPAi.NewForms.MenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlayerPanel)).BeginInit();
            this.VideoPlayerPanel.Panel1.SuspendLayout();
            this.VideoPlayerPanel.Panel2.SuspendLayout();
            this.VideoPlayerPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // VideoPlayerPanel
            // 
            this.VideoPlayerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoPlayerPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.VideoPlayerPanel.Location = new System.Drawing.Point(0, 0);
            this.VideoPlayerPanel.Name = "VideoPlayerPanel";
            this.VideoPlayerPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // VideoPlayerPanel.Panel1
            // 
            this.VideoPlayerPanel.Panel1.Controls.Add(this.panel1);
            // 
            // VideoPlayerPanel.Panel2
            // 
            this.VideoPlayerPanel.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.VideoPlayerPanel.Panel2.Controls.Add(this.resetButton);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.label1);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.playNextCheckBox);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.removeButton);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.divider4);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.divider3);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.divider2);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.divider1);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.soundListAddAllButton);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.soundListRemoveButton);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.soundListAddButton);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.soundListAllListBox);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.soundListCurrentListBox);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.soundListAllLabel);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.soundListCurrentLabel);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.addFromFileButton);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.recordButton);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.AudioInputDeviceButton);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.AudioInputDeviceComboBox);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.AudioInputDeviceLabel);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.repeatSpinner);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.repeatLabel);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.recordingProgressBarLabel);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.repeatTrackBar);
            this.VideoPlayerPanel.Panel2.Controls.Add(this.recordingProgressBar);
            this.VideoPlayerPanel.Size = new System.Drawing.Size(584, 522);
            this.VideoPlayerPanel.SplitterDistance = 250;
            this.VideoPlayerPanel.SplitterWidth = 1;
            this.VideoPlayerPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.VowelComboBox);
            this.panel1.Controls.Add(this.optionsButton);
            this.panel1.Controls.Add(this.backButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 250);
            this.panel1.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Controls.Add(this.vlcControl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.backwardButton, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.playButton, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.forwardButton, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 2, 0);
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 86);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(566, 126);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // vlcControl
            // 
            this.vlcControl.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.vlcControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcControl.Location = new System.Drawing.Point(3, 64);
            this.vlcControl.Name = "vlcControl";
            this.vlcControl.Size = new System.Drawing.Size(56, 59);
            this.vlcControl.Spu = -1;
            this.vlcControl.TabIndex = 3;
            this.vlcControl.Text = "vlcControl1";
            this.vlcControl.Visible = false;
            this.vlcControl.VlcLibDirectory = null;
            this.vlcControl.VlcMediaplayerOptions = null;
            this.vlcControl.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.OnVlcControlNeedLibDirectory);
            this.vlcControl.EndReached += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerEndReachedEventArgs>(this.vlcControl_EndReached);
            this.vlcControl.PositionChanged += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerPositionChangedEventArgs>(this.vlcControl_PositionChanged);
            this.vlcControl.Stopped += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs>(this.OnVlcControlStopped);
            // 
            // backwardButton
            // 
            this.backwardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backwardButton.BackColor = System.Drawing.Color.Transparent;
            this.backwardButton.FlatAppearance.BorderSize = 0;
            this.backwardButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.backwardButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.backwardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backwardButton.ImageIndex = 1;
            this.backwardButton.ImageList = this.backImageList;
            this.backwardButton.Location = new System.Drawing.Point(189, 64);
            this.backwardButton.Name = "backwardButton";
            this.backwardButton.Size = new System.Drawing.Size(56, 59);
            this.backwardButton.TabIndex = 5;
            this.backwardButton.UseVisualStyleBackColor = false;
            this.backwardButton.Click += new System.EventHandler(this.backwardButton_Click);
            this.backwardButton.MouseEnter += new System.EventHandler(this.backwardButton_MouseEnter);
            this.backwardButton.MouseLeave += new System.EventHandler(this.backwardButton_MouseLeave);
            // 
            // backImageList
            // 
            this.backImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("backImageList.ImageStream")));
            this.backImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.backImageList.Images.SetKeyName(0, "Light Backward.png");
            this.backImageList.Images.SetKeyName(1, "Backward.png");
            // 
            // playButton
            // 
            this.playButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playButton.BackColor = System.Drawing.Color.Transparent;
            this.playButton.FlatAppearance.BorderSize = 0;
            this.playButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.playButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.ImageIndex = 1;
            this.playButton.ImageList = this.playImageList;
            this.playButton.Location = new System.Drawing.Point(251, 64);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(56, 59);
            this.playButton.TabIndex = 6;
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            this.playButton.MouseEnter += new System.EventHandler(this.playButton_MouseEnter);
            this.playButton.MouseLeave += new System.EventHandler(this.playButton_MouseLeave);
            // 
            // playImageList
            // 
            this.playImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("playImageList.ImageStream")));
            this.playImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.playImageList.Images.SetKeyName(0, "Light Play.png");
            this.playImageList.Images.SetKeyName(1, "Play.png");
            this.playImageList.Images.SetKeyName(2, "Light Pause.png");
            this.playImageList.Images.SetKeyName(3, "Pause.png");
            // 
            // forwardButton
            // 
            this.forwardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.forwardButton.BackColor = System.Drawing.Color.Transparent;
            this.forwardButton.FlatAppearance.BorderSize = 0;
            this.forwardButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.forwardButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.forwardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forwardButton.ImageIndex = 1;
            this.forwardButton.ImageList = this.forwardImageList;
            this.forwardButton.Location = new System.Drawing.Point(313, 64);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(56, 59);
            this.forwardButton.TabIndex = 8;
            this.forwardButton.UseVisualStyleBackColor = false;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            this.forwardButton.MouseEnter += new System.EventHandler(this.forwardButton_MouseEnter);
            this.forwardButton.MouseLeave += new System.EventHandler(this.forwardButton_MouseLeave);
            // 
            // forwardImageList
            // 
            this.forwardImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("forwardImageList.ImageStream")));
            this.forwardImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.forwardImageList.Images.SetKeyName(0, "Light Forward.png");
            this.forwardImageList.Images.SetKeyName(1, "Forward.png");
            // 
            // progressBar1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.progressBar1, 5);
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(127, 35);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(304, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // VowelComboBox
            // 
            this.VowelComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VowelComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.VowelComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.VowelComboBox.FormattingEnabled = true;
            this.VowelComboBox.ItemHeight = 13;
            this.VowelComboBox.Location = new System.Drawing.Point(112, 43);
            this.VowelComboBox.Name = "VowelComboBox";
            this.VowelComboBox.Size = new System.Drawing.Size(353, 21);
            this.VowelComboBox.TabIndex = 1;
            this.VowelComboBox.SelectedIndexChanged += new System.EventHandler(this.VowelComboBox_SelectedIndexChanged);
            this.VowelComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VowelComboBox_KeyPress);
            this.VowelComboBox.Leave += new System.EventHandler(this.VowelComboBox_Leave);
            // 
            // optionsButton
            // 
            this.optionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optionsButton.Location = new System.Drawing.Point(365, 215);
            this.optionsButton.Margin = new System.Windows.Forms.Padding(10);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(100, 25);
            this.optionsButton.TabIndex = 6;
            this.optionsButton.Text = "Less...";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.backButton.Location = new System.Drawing.Point(471, 215);
            this.backButton.Margin = new System.Windows.Forms.Padding(10);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(100, 25);
            this.backButton.TabIndex = 7;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.resetButton.Location = new System.Drawing.Point(186, 244);
            this.resetButton.Margin = new System.Windows.Forms.Padding(10);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(250, 25);
            this.resetButton.TabIndex = 47;
            this.resetButton.Text = "Restore Defaults";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(3, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(584, 2);
            this.label1.TabIndex = 46;
            // 
            // playNextCheckBox
            // 
            this.playNextCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.playNextCheckBox.AutoSize = true;
            this.playNextCheckBox.Location = new System.Drawing.Point(18, 113);
            this.playNextCheckBox.Name = "playNextCheckBox";
            this.playNextCheckBox.Size = new System.Drawing.Size(243, 17);
            this.playNextCheckBox.TabIndex = 45;
            this.playNextCheckBox.Text = "Play next sound when the current one finishes";
            this.playNextCheckBox.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Enabled = false;
            this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.removeButton.Location = new System.Drawing.Point(470, 49);
            this.removeButton.Margin = new System.Windows.Forms.Padding(0);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(100, 25);
            this.removeButton.TabIndex = 43;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // divider4
            // 
            this.divider4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divider4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider4.Location = new System.Drawing.Point(-4, 131);
            this.divider4.Name = "divider4";
            this.divider4.Size = new System.Drawing.Size(584, 2);
            this.divider4.TabIndex = 42;
            // 
            // divider3
            // 
            this.divider3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divider3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider3.Location = new System.Drawing.Point(-2, 108);
            this.divider3.Name = "divider3";
            this.divider3.Size = new System.Drawing.Size(584, 2);
            this.divider3.TabIndex = 41;
            // 
            // divider2
            // 
            this.divider2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divider2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider2.Location = new System.Drawing.Point(-2, -7);
            this.divider2.Name = "divider2";
            this.divider2.Size = new System.Drawing.Size(584, 2);
            this.divider2.TabIndex = 40;
            // 
            // divider1
            // 
            this.divider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divider1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider1.Location = new System.Drawing.Point(-2, 42);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(584, 2);
            this.divider1.TabIndex = 39;
            // 
            // soundListAddAllButton
            // 
            this.soundListAddAllButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.soundListAddAllButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.soundListAddAllButton.Location = new System.Drawing.Point(264, 206);
            this.soundListAddAllButton.Margin = new System.Windows.Forms.Padding(10);
            this.soundListAddAllButton.Name = "soundListAddAllButton";
            this.soundListAddAllButton.Size = new System.Drawing.Size(91, 25);
            this.soundListAddAllButton.TabIndex = 21;
            this.soundListAddAllButton.Text = "Add All";
            this.soundListAddAllButton.UseVisualStyleBackColor = true;
            this.soundListAddAllButton.Click += new System.EventHandler(this.soundListAddAllButton_Click);
            // 
            // soundListRemoveButton
            // 
            this.soundListRemoveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.soundListRemoveButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.soundListRemoveButton.Location = new System.Drawing.Point(264, 178);
            this.soundListRemoveButton.Margin = new System.Windows.Forms.Padding(10);
            this.soundListRemoveButton.Name = "soundListRemoveButton";
            this.soundListRemoveButton.Size = new System.Drawing.Size(91, 25);
            this.soundListRemoveButton.TabIndex = 20;
            this.soundListRemoveButton.Text = "Remove Selected";
            this.soundListRemoveButton.UseVisualStyleBackColor = true;
            this.soundListRemoveButton.Click += new System.EventHandler(this.soundListRemoveButton_Click);
            // 
            // soundListAddButton
            // 
            this.soundListAddButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.soundListAddButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.soundListAddButton.Location = new System.Drawing.Point(264, 149);
            this.soundListAddButton.Margin = new System.Windows.Forms.Padding(10);
            this.soundListAddButton.Name = "soundListAddButton";
            this.soundListAddButton.Size = new System.Drawing.Size(91, 25);
            this.soundListAddButton.TabIndex = 19;
            this.soundListAddButton.Text = "Add Selected";
            this.soundListAddButton.UseVisualStyleBackColor = true;
            this.soundListAddButton.Click += new System.EventHandler(this.soundListAddButton_Click);
            // 
            // soundListAllListBox
            // 
            this.soundListAllListBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.soundListAllListBox.FormattingEnabled = true;
            this.soundListAllListBox.Location = new System.Drawing.Point(365, 149);
            this.soundListAllListBox.Name = "soundListAllListBox";
            this.soundListAllListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.soundListAllListBox.Size = new System.Drawing.Size(206, 82);
            this.soundListAllListBox.TabIndex = 18;
            // 
            // soundListCurrentListBox
            // 
            this.soundListCurrentListBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.soundListCurrentListBox.FormattingEnabled = true;
            this.soundListCurrentListBox.Location = new System.Drawing.Point(18, 149);
            this.soundListCurrentListBox.Name = "soundListCurrentListBox";
            this.soundListCurrentListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.soundListCurrentListBox.Size = new System.Drawing.Size(233, 82);
            this.soundListCurrentListBox.TabIndex = 17;
            // 
            // soundListAllLabel
            // 
            this.soundListAllLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.soundListAllLabel.AutoSize = true;
            this.soundListAllLabel.Location = new System.Drawing.Point(362, 133);
            this.soundListAllLabel.Name = "soundListAllLabel";
            this.soundListAllLabel.Size = new System.Drawing.Size(58, 13);
            this.soundListAllLabel.TabIndex = 16;
            this.soundListAllLabel.Text = "All sounds:";
            // 
            // soundListCurrentLabel
            // 
            this.soundListCurrentLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.soundListCurrentLabel.AutoSize = true;
            this.soundListCurrentLabel.Location = new System.Drawing.Point(18, 133);
            this.soundListCurrentLabel.Name = "soundListCurrentLabel";
            this.soundListCurrentLabel.Size = new System.Drawing.Size(99, 13);
            this.soundListCurrentLabel.TabIndex = 15;
            this.soundListCurrentLabel.Text = "Sounds to practice:";
            // 
            // addFromFileButton
            // 
            this.addFromFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addFromFileButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addFromFileButton.Location = new System.Drawing.Point(470, 79);
            this.addFromFileButton.Margin = new System.Windows.Forms.Padding(0);
            this.addFromFileButton.Name = "addFromFileButton";
            this.addFromFileButton.Size = new System.Drawing.Size(100, 25);
            this.addFromFileButton.TabIndex = 12;
            this.addFromFileButton.Text = "Select from file";
            this.addFromFileButton.UseVisualStyleBackColor = true;
            this.addFromFileButton.Click += new System.EventHandler(this.addFromFileButton_Click);
            // 
            // recordButton
            // 
            this.recordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.recordButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.recordButton.Location = new System.Drawing.Point(364, 79);
            this.recordButton.Margin = new System.Windows.Forms.Padding(0);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(100, 25);
            this.recordButton.TabIndex = 11;
            this.recordButton.Text = "Record";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // AudioInputDeviceButton
            // 
            this.AudioInputDeviceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioInputDeviceButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AudioInputDeviceButton.Location = new System.Drawing.Point(304, 79);
            this.AudioInputDeviceButton.Margin = new System.Windows.Forms.Padding(10);
            this.AudioInputDeviceButton.Name = "AudioInputDeviceButton";
            this.AudioInputDeviceButton.Size = new System.Drawing.Size(50, 25);
            this.AudioInputDeviceButton.TabIndex = 10;
            this.AudioInputDeviceButton.Text = "Refresh";
            this.AudioInputDeviceButton.UseVisualStyleBackColor = true;
            this.AudioInputDeviceButton.Click += new System.EventHandler(this.AudioInputDeviceButton_Click);
            // 
            // AudioInputDeviceComboBox
            // 
            this.AudioInputDeviceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioInputDeviceComboBox.FormattingEnabled = true;
            this.AudioInputDeviceComboBox.Location = new System.Drawing.Point(18, 79);
            this.AudioInputDeviceComboBox.Name = "AudioInputDeviceComboBox";
            this.AudioInputDeviceComboBox.Size = new System.Drawing.Size(282, 21);
            this.AudioInputDeviceComboBox.TabIndex = 9;
            // 
            // AudioInputDeviceLabel
            // 
            this.AudioInputDeviceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AudioInputDeviceLabel.AutoSize = true;
            this.AudioInputDeviceLabel.Location = new System.Drawing.Point(16, 58);
            this.AudioInputDeviceLabel.Name = "AudioInputDeviceLabel";
            this.AudioInputDeviceLabel.Size = new System.Drawing.Size(81, 13);
            this.AudioInputDeviceLabel.TabIndex = 8;
            this.AudioInputDeviceLabel.Text = "Add your voice:";
            // 
            // repeatSpinner
            // 
            this.repeatSpinner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.repeatSpinner.Location = new System.Drawing.Point(482, 17);
            this.repeatSpinner.Name = "repeatSpinner";
            this.repeatSpinner.Size = new System.Drawing.Size(87, 20);
            this.repeatSpinner.TabIndex = 2;
            this.repeatSpinner.Text = "domainUpDown1";
            // 
            // repeatLabel
            // 
            this.repeatLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.repeatLabel.AutoSize = true;
            this.repeatLabel.Location = new System.Drawing.Point(16, 19);
            this.repeatLabel.Name = "repeatLabel";
            this.repeatLabel.Size = new System.Drawing.Size(42, 13);
            this.repeatLabel.TabIndex = 1;
            this.repeatLabel.Text = "Repeat";
            // 
            // recordingProgressBarLabel
            // 
            this.recordingProgressBarLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recordingProgressBarLabel.BackColor = System.Drawing.SystemColors.Control;
            this.recordingProgressBarLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.recordingProgressBarLabel.Location = new System.Drawing.Point(103, 49);
            this.recordingProgressBarLabel.Name = "recordingProgressBarLabel";
            this.recordingProgressBarLabel.Size = new System.Drawing.Size(361, 23);
            this.recordingProgressBarLabel.TabIndex = 37;
            this.recordingProgressBarLabel.Text = "No current file";
            this.recordingProgressBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // repeatTrackBar
            // 
            this.repeatTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.repeatTrackBar.LargeChange = 1;
            this.repeatTrackBar.Location = new System.Drawing.Point(65, 10);
            this.repeatTrackBar.Maximum = 11;
            this.repeatTrackBar.Name = "repeatTrackBar";
            this.repeatTrackBar.Size = new System.Drawing.Size(399, 45);
            this.repeatTrackBar.TabIndex = 0;
            this.repeatTrackBar.ValueChanged += new System.EventHandler(this.repeatTrackBar_ValueChanged);
            // 
            // recordingProgressBar
            // 
            this.recordingProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recordingProgressBar.Location = new System.Drawing.Point(103, 47);
            this.recordingProgressBar.Name = "recordingProgressBar";
            this.recordingProgressBar.Size = new System.Drawing.Size(361, 25);
            this.recordingProgressBar.TabIndex = 44;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Wave files (*.wav)|*.wav|All Files(*.*)|*.*";
            this.openFileDialog.InitialDirectory = "Environment.GetFolderPath(Environment.SpecialFolder.MyMusic, Environment.SpecialF" +
    "olderOption.None)";
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.Title = "Select a Recording...";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AudioPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 522);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.VideoPlayerPanel);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(375, 560);
            this.Name = "AudioPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MPAi Sound";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AudioPlayer_FormClosing);
            this.VideoPlayerPanel.Panel1.ResumeLayout(false);
            this.VideoPlayerPanel.Panel2.ResumeLayout(false);
            this.VideoPlayerPanel.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlayerPanel)).EndInit();
            this.VideoPlayerPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer VideoPlayerPanel;
        private System.Windows.Forms.ComboBox VowelComboBox;
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
        private System.Windows.Forms.Button addFromFileButton;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Label recordingProgressBarLabel;
        private System.Windows.Forms.Label divider1;
        private System.Windows.Forms.Label divider4;
        private System.Windows.Forms.Label divider3;
        private System.Windows.Forms.Label divider2;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ProgressBar recordingProgressBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Vlc.DotNet.Forms.VlcControl vlcControl;
        private System.Windows.Forms.Button backwardButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.ImageList backImageList;
        private System.Windows.Forms.ImageList playImageList;
        private System.Windows.Forms.ImageList forwardImageList;
        private System.Windows.Forms.CheckBox playNextCheckBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private MenuStrip menuStrip1;
    }
}