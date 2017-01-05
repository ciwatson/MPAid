namespace MPAid.NewForms
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
            this.VowelComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.optionsButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.audioProgressBar = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.playImageList = new System.Windows.Forms.ImageList(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.vlcAudioPlayer = new Vlc.DotNet.Forms.VlcControl();
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
            this.stopImageList = new System.Windows.Forms.ImageList(this.components);
            this.backImageList = new System.Windows.Forms.ImageList(this.components);
            this.forwardImageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlayerPanel)).BeginInit();
            this.VideoPlayerPanel.Panel1.SuspendLayout();
            this.VideoPlayerPanel.Panel2.SuspendLayout();
            this.VideoPlayerPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlcAudioPlayer)).BeginInit();
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
            this.VideoPlayerPanel.Panel1.Controls.Add(this.VowelComboBox);
            this.VideoPlayerPanel.Panel1.Controls.Add(this.tableLayoutPanel1);
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
            this.VideoPlayerPanel.Size = new System.Drawing.Size(584, 562);
            this.VideoPlayerPanel.SplitterDistance = 340;
            this.VideoPlayerPanel.SplitterWidth = 1;
            this.VideoPlayerPanel.TabIndex = 1;
            // 
            // VowelComboBox
            // 
            this.VowelComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VowelComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.VowelComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.VowelComboBox.FormattingEnabled = true;
            this.VowelComboBox.ItemHeight = 13;
            this.VowelComboBox.Location = new System.Drawing.Point(117, 12);
            this.VowelComboBox.Name = "VowelComboBox";
            this.VowelComboBox.Size = new System.Drawing.Size(353, 21);
            this.VowelComboBox.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.76923F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.23077F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 340);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.optionsButton);
            this.panel1.Controls.Add(this.backButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 272);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 65);
            this.panel1.TabIndex = 8;
            // 
            // optionsButton
            // 
            this.optionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optionsButton.Location = new System.Drawing.Point(356, 20);
            this.optionsButton.Margin = new System.Windows.Forms.Padding(10);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(100, 25);
            this.optionsButton.TabIndex = 6;
            this.optionsButton.Text = "Less...";
            this.optionsButton.UseVisualStyleBackColor = true;
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.backButton.Location = new System.Drawing.Point(471, 20);
            this.backButton.Margin = new System.Windows.Forms.Padding(10);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(100, 25);
            this.backButton.TabIndex = 7;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Controls.Add(this.vlcAudioPlayer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(578, 207);
            this.panel2.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 9;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.audioProgressBar, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.stopButton, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.button4, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.button3, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.forwardButton, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.button2, 5, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(578, 207);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // audioProgressBar
            // 
            this.audioProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.audioProgressBar, 7);
            this.audioProgressBar.Location = new System.Drawing.Point(67, 59);
            this.audioProgressBar.Name = "audioProgressBar";
            this.audioProgressBar.Size = new System.Drawing.Size(442, 23);
            this.audioProgressBar.TabIndex = 10;
            this.audioProgressBar.Click += new System.EventHandler(this.progressBar2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ImageIndex = 1;
            this.button1.Location = new System.Drawing.Point(3, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 59);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // stopButton
            // 
            this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stopButton.BackColor = System.Drawing.SystemColors.Control;
            this.stopButton.FlatAppearance.BorderSize = 0;
            this.stopButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.stopButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.ImageIndex = 1;
            this.stopButton.Location = new System.Drawing.Point(67, 145);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(58, 59);
            this.stopButton.TabIndex = 7;
            this.stopButton.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ImageIndex = 1;
            this.button4.ImageList = this.playImageList;
            this.button4.Location = new System.Drawing.Point(259, 145);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(58, 59);
            this.button4.TabIndex = 12;
            this.button4.UseVisualStyleBackColor = false;
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
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ImageIndex = 1;
            this.button3.ImageList = this.backImageList;
            this.button3.Location = new System.Drawing.Point(195, 145);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 59);
            this.button3.TabIndex = 11;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // forwardButton
            // 
            this.forwardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.forwardButton.BackColor = System.Drawing.SystemColors.Control;
            this.forwardButton.FlatAppearance.BorderSize = 0;
            this.forwardButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.forwardButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.forwardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forwardButton.ImageIndex = 1;
            this.forwardButton.Location = new System.Drawing.Point(387, 145);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(58, 59);
            this.forwardButton.TabIndex = 8;
            this.forwardButton.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ImageIndex = 1;
            this.button2.ImageList = this.forwardImageList;
            this.button2.Location = new System.Drawing.Point(323, 145);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 59);
            this.button2.TabIndex = 14;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // vlcAudioPlayer
            // 
            this.vlcAudioPlayer.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.vlcAudioPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcAudioPlayer.Location = new System.Drawing.Point(0, 0);
            this.vlcAudioPlayer.Name = "vlcAudioPlayer";
            this.vlcAudioPlayer.Size = new System.Drawing.Size(578, 207);
            this.vlcAudioPlayer.Spu = -1;
            this.vlcAudioPlayer.TabIndex = 9;
            this.vlcAudioPlayer.Text = "vlcControl1";
            this.vlcAudioPlayer.Visible = false;
            this.vlcAudioPlayer.VlcLibDirectory = null;
            this.vlcAudioPlayer.VlcMediaplayerOptions = null;
            // 
            // divider4
            // 
            this.divider4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divider4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider4.Location = new System.Drawing.Point(0, 137);
            this.divider4.Name = "divider4";
            this.divider4.Size = new System.Drawing.Size(584, 2);
            this.divider4.TabIndex = 42;
            // 
            // divider3
            // 
            this.divider3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divider3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider3.Location = new System.Drawing.Point(0, 114);
            this.divider3.Name = "divider3";
            this.divider3.Size = new System.Drawing.Size(584, 2);
            this.divider3.TabIndex = 41;
            // 
            // divider2
            // 
            this.divider2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divider2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider2.Location = new System.Drawing.Point(0, 10);
            this.divider2.Name = "divider2";
            this.divider2.Size = new System.Drawing.Size(584, 2);
            this.divider2.TabIndex = 40;
            // 
            // divider1
            // 
            this.divider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divider1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider1.Location = new System.Drawing.Point(1, 47);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(584, 2);
            this.divider1.TabIndex = 39;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addButton.Location = new System.Drawing.Point(466, 57);
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
            this.recordingProgressBarLabel.Location = new System.Drawing.Point(99, 58);
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
            this.playNextRadioButtonNo.Location = new System.Drawing.Point(526, 117);
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
            this.soundListAddAllButton.Location = new System.Drawing.Point(258, 214);
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
            this.playNextRadioButtonYes.Location = new System.Drawing.Point(466, 117);
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
            this.soundListRemoveButton.Location = new System.Drawing.Point(258, 186);
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
            this.soundListAddButton.Location = new System.Drawing.Point(258, 157);
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
            this.soundListAllListBox.Location = new System.Drawing.Point(359, 157);
            this.soundListAllListBox.Name = "soundListAllListBox";
            this.soundListAllListBox.Size = new System.Drawing.Size(206, 82);
            this.soundListAllListBox.TabIndex = 18;
            // 
            // soundListCurrentListBox
            // 
            this.soundListCurrentListBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.soundListCurrentListBox.FormattingEnabled = true;
            this.soundListCurrentListBox.Location = new System.Drawing.Point(12, 157);
            this.soundListCurrentListBox.Name = "soundListCurrentListBox";
            this.soundListCurrentListBox.Size = new System.Drawing.Size(233, 82);
            this.soundListCurrentListBox.TabIndex = 17;
            // 
            // soundListAllLabel
            // 
            this.soundListAllLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.soundListAllLabel.AutoSize = true;
            this.soundListAllLabel.Location = new System.Drawing.Point(356, 141);
            this.soundListAllLabel.Name = "soundListAllLabel";
            this.soundListAllLabel.Size = new System.Drawing.Size(58, 13);
            this.soundListAllLabel.TabIndex = 16;
            this.soundListAllLabel.Text = "All sounds:";
            // 
            // soundListCurrentLabel
            // 
            this.soundListCurrentLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.soundListCurrentLabel.AutoSize = true;
            this.soundListCurrentLabel.Location = new System.Drawing.Point(12, 141);
            this.soundListCurrentLabel.Name = "soundListCurrentLabel";
            this.soundListCurrentLabel.Size = new System.Drawing.Size(99, 13);
            this.soundListCurrentLabel.TabIndex = 15;
            this.soundListCurrentLabel.Text = "Sounds to practice:";
            // 
            // playNextLabel
            // 
            this.playNextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.playNextLabel.AutoSize = true;
            this.playNextLabel.Location = new System.Drawing.Point(12, 119);
            this.playNextLabel.Name = "playNextLabel";
            this.playNextLabel.Size = new System.Drawing.Size(159, 13);
            this.playNextLabel.TabIndex = 13;
            this.playNextLabel.Text = "Play  next sound when finished?";
            // 
            // addFromFileButton
            // 
            this.addFromFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addFromFileButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addFromFileButton.Location = new System.Drawing.Point(466, 84);
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
            this.recordButton.Location = new System.Drawing.Point(360, 84);
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
            this.AudioInputDeviceButton.Location = new System.Drawing.Point(300, 84);
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
            this.AudioInputDeviceComboBox.Location = new System.Drawing.Point(14, 84);
            this.AudioInputDeviceComboBox.Name = "AudioInputDeviceComboBox";
            this.AudioInputDeviceComboBox.Size = new System.Drawing.Size(300, 21);
            this.AudioInputDeviceComboBox.TabIndex = 9;
            // 
            // AudioInputDeviceLabel
            // 
            this.AudioInputDeviceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AudioInputDeviceLabel.AutoSize = true;
            this.AudioInputDeviceLabel.Location = new System.Drawing.Point(12, 63);
            this.AudioInputDeviceLabel.Name = "AudioInputDeviceLabel";
            this.AudioInputDeviceLabel.Size = new System.Drawing.Size(81, 13);
            this.AudioInputDeviceLabel.TabIndex = 8;
            this.AudioInputDeviceLabel.Text = "Add your voice:";
            // 
            // repeatSpinner
            // 
            this.repeatSpinner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.repeatSpinner.Location = new System.Drawing.Point(478, 22);
            this.repeatSpinner.Name = "repeatSpinner";
            this.repeatSpinner.Size = new System.Drawing.Size(87, 20);
            this.repeatSpinner.TabIndex = 2;
            this.repeatSpinner.Text = "domainUpDown1";
            // 
            // repeatLabel
            // 
            this.repeatLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.repeatLabel.AutoSize = true;
            this.repeatLabel.Location = new System.Drawing.Point(12, 24);
            this.repeatLabel.Name = "repeatLabel";
            this.repeatLabel.Size = new System.Drawing.Size(42, 13);
            this.repeatLabel.TabIndex = 1;
            this.repeatLabel.Text = "Repeat";
            // 
            // repeatTrackBar
            // 
            this.repeatTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.repeatTrackBar.Location = new System.Drawing.Point(61, 15);
            this.repeatTrackBar.Name = "repeatTrackBar";
            this.repeatTrackBar.Size = new System.Drawing.Size(399, 45);
            this.repeatTrackBar.TabIndex = 0;
            // 
            // stopImageList
            // 
            this.stopImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("stopImageList.ImageStream")));
            this.stopImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.stopImageList.Images.SetKeyName(0, "Light Stop.png");
            this.stopImageList.Images.SetKeyName(1, "Stop.png");
            // 
            // backImageList
            // 
            this.backImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("backImageList.ImageStream")));
            this.backImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.backImageList.Images.SetKeyName(0, "Light Backward.png");
            this.backImageList.Images.SetKeyName(1, "Backward.png");
            // 
            // forwardImageList
            // 
            this.forwardImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("forwardImageList.ImageStream")));
            this.forwardImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.forwardImageList.Images.SetKeyName(0, "Light Forward.png");
            this.forwardImageList.Images.SetKeyName(1, "Forward.png");
            // 
            // AudioPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.VideoPlayerPanel);
            this.Name = "AudioPlayer";
            this.Text = "MPai Sound";
            this.VideoPlayerPanel.Panel1.ResumeLayout(false);
            this.VideoPlayerPanel.Panel2.ResumeLayout(false);
            this.VideoPlayerPanel.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlayerPanel)).EndInit();
            this.VideoPlayerPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vlcAudioPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer VideoPlayerPanel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.ComboBox VowelComboBox;
        private System.Windows.Forms.Label divider4;
        private System.Windows.Forms.Label divider3;
        private System.Windows.Forms.Label divider2;
        private System.Windows.Forms.Label divider1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label recordingProgressBarLabel;
        private System.Windows.Forms.RadioButton playNextRadioButtonNo;
        private System.Windows.Forms.Button soundListAddAllButton;
        private System.Windows.Forms.RadioButton playNextRadioButtonYes;
        private System.Windows.Forms.Button soundListRemoveButton;
        private System.Windows.Forms.Button soundListAddButton;
        private System.Windows.Forms.ListBox soundListAllListBox;
        private System.Windows.Forms.ListBox soundListCurrentListBox;
        private System.Windows.Forms.Label soundListAllLabel;
        private System.Windows.Forms.Label soundListCurrentLabel;
        private System.Windows.Forms.Label playNextLabel;
        private System.Windows.Forms.Button addFromFileButton;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Button AudioInputDeviceButton;
        private System.Windows.Forms.ComboBox AudioInputDeviceComboBox;
        private System.Windows.Forms.Label AudioInputDeviceLabel;
        private System.Windows.Forms.DomainUpDown repeatSpinner;
        private System.Windows.Forms.Label repeatLabel;
        private System.Windows.Forms.TrackBar repeatTrackBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar audioProgressBar;
        private Vlc.DotNet.Forms.VlcControl vlcAudioPlayer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ImageList stopImageList;
        private System.Windows.Forms.ImageList playImageList;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ImageList backImageList;
        private System.Windows.Forms.ImageList forwardImageList;
    }
}