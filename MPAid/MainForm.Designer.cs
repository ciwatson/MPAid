namespace MPAid
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.headerBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioYoungFemale = new System.Windows.Forms.RadioButton();
            this.radioYoungMale = new System.Windows.Forms.RadioButton();
            this.radioFemale = new System.Windows.Forms.RadioButton();
            this.radioOldMale = new System.Windows.Forms.RadioButton();
            this.myTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.VowelList = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.WordList = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.speedController = new System.Windows.Forms.TrackBar();
            this.AudioDelay = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.NumPlayback = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBoxREC = new System.Windows.Forms.ListBox();
            this.buttonRecord = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonLoadFromFile = new System.Windows.Forms.Button();
            this.buttonShowReport = new System.Windows.Forms.Button();
            this.labelCorrectness = new System.Windows.Forms.Label();
            this.buttonShowDir = new System.Windows.Forms.Button();
            this.wordSelectedLabel = new System.Windows.Forms.Label();
            this.buttonAnalyze = new System.Windows.Forms.Button();
            this.buttonStopRecording = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.NAudioTimer = new System.Windows.Forms.Timer(this.components);
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hMMsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openHMMsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tdButtonFormantPlot = new MPAid.TDButton();
            this.ButtonStop = new MPAid.TDButton();
            this.ButtonPlay = new MPAid.TDButton();
            ((System.ComponentModel.ISupportInitialize)(this.headerBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.myTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedController)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPlayback)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerBox
            // 
            this.headerBox.BackgroundImage = global::MPAid.Properties.Resources.header;
            this.headerBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.headerBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerBox.Location = new System.Drawing.Point(0, 32);
            this.headerBox.Name = "headerBox";
            this.headerBox.Size = new System.Drawing.Size(834, 81);
            this.headerBox.TabIndex = 0;
            this.headerBox.TabStop = false;
            this.headerBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.headerBox_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioYoungFemale);
            this.groupBox1.Controls.Add(this.radioYoungMale);
            this.groupBox1.Controls.Add(this.radioFemale);
            this.groupBox1.Controls.Add(this.radioOldMale);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 135);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source";
            // 
            // radioYoungFemale
            // 
            this.radioYoungFemale.AutoSize = true;
            this.radioYoungFemale.Location = new System.Drawing.Point(27, 95);
            this.radioYoungFemale.Name = "radioYoungFemale";
            this.radioYoungFemale.Size = new System.Drawing.Size(105, 19);
            this.radioYoungFemale.TabIndex = 5;
            this.radioYoungFemale.Text = "Young Female";
            this.radioYoungFemale.UseVisualStyleBackColor = true;
            // 
            // radioYoungMale
            // 
            this.radioYoungMale.AutoSize = true;
            this.radioYoungMale.Location = new System.Drawing.Point(27, 70);
            this.radioYoungMale.Name = "radioYoungMale";
            this.radioYoungMale.Size = new System.Drawing.Size(91, 19);
            this.radioYoungMale.TabIndex = 4;
            this.radioYoungMale.Text = "Young Male";
            this.radioYoungMale.UseVisualStyleBackColor = true;
            // 
            // radioFemale
            // 
            this.radioFemale.AutoSize = true;
            this.radioFemale.Location = new System.Drawing.Point(27, 45);
            this.radioFemale.Name = "radioFemale";
            this.radioFemale.Size = new System.Drawing.Size(106, 19);
            this.radioFemale.TabIndex = 3;
            this.radioFemale.Text = "Senior Female";
            this.radioFemale.UseVisualStyleBackColor = true;
            // 
            // radioOldMale
            // 
            this.radioOldMale.AutoSize = true;
            this.radioOldMale.Checked = true;
            this.radioOldMale.Location = new System.Drawing.Point(27, 20);
            this.radioOldMale.Name = "radioOldMale";
            this.radioOldMale.Size = new System.Drawing.Size(92, 19);
            this.radioOldMale.TabIndex = 3;
            this.radioOldMale.TabStop = true;
            this.radioOldMale.Text = "Senior Male";
            this.radioOldMale.UseVisualStyleBackColor = true;
            // 
            // myTabControl
            // 
            this.myTabControl.Controls.Add(this.tabPage1);
            this.myTabControl.Controls.Add(this.tabPage2);
            this.myTabControl.Location = new System.Drawing.Point(12, 147);
            this.myTabControl.Name = "myTabControl";
            this.myTabControl.SelectedIndex = 0;
            this.myTabControl.Size = new System.Drawing.Size(160, 222);
            this.myTabControl.TabIndex = 3;
            this.myTabControl.SelectedIndexChanged += new System.EventHandler(this.myTabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.VowelList);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(152, 194);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vowels";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // VowelList
            // 
            this.VowelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VowelList.FormattingEnabled = true;
            this.VowelList.ItemHeight = 15;
            this.VowelList.Location = new System.Drawing.Point(3, 3);
            this.VowelList.Name = "VowelList";
            this.VowelList.Size = new System.Drawing.Size(146, 188);
            this.VowelList.TabIndex = 4;
            this.VowelList.SelectedIndexChanged += new System.EventHandler(this.VowelList_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.WordList);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(152, 194);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Words";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // WordList
            // 
            this.WordList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WordList.FormattingEnabled = true;
            this.WordList.ItemHeight = 15;
            this.WordList.Location = new System.Drawing.Point(3, 3);
            this.WordList.Name = "WordList";
            this.WordList.Size = new System.Drawing.Size(146, 190);
            this.WordList.TabIndex = 5;
            this.WordList.SelectedIndexChanged += new System.EventHandler(this.WordList_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.ButtonStop);
            this.groupBox2.Controls.Add(this.ButtonPlay);
            this.groupBox2.Controls.Add(this.AudioDelay);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.previewBox);
            this.groupBox2.Controls.Add(this.NumPlayback);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(178, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 363);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Audio && Animation";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.speedController);
            this.panel2.Location = new System.Drawing.Point(6, 286);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 71);
            this.panel2.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 45);
            this.label3.TabIndex = 9;
            this.label3.Text = "Animation speed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Fast";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Slow";
            // 
            // speedController
            // 
            this.speedController.Location = new System.Drawing.Point(129, 3);
            this.speedController.Maximum = 20;
            this.speedController.Minimum = 1;
            this.speedController.Name = "speedController";
            this.speedController.Size = new System.Drawing.Size(168, 45);
            this.speedController.TabIndex = 8;
            this.speedController.Value = 5;
            this.speedController.Scroll += new System.EventHandler(this.speedController_Scroll);
            // 
            // AudioDelay
            // 
            this.AudioDelay.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.AudioDelay.Location = new System.Drawing.Point(165, 20);
            this.AudioDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.AudioDelay.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.AudioDelay.Name = "AudioDelay";
            this.AudioDelay.Size = new System.Drawing.Size(100, 21);
            this.AudioDelay.TabIndex = 5;
            this.AudioDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AudioDelay.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.AudioDelay.ValueChanged += new System.EventHandler(this.AudioDelay_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Audio interval (ms)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // previewBox
            // 
            this.previewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.previewBox.InitialImage = global::MPAid.Properties.Resources.PictureNotFound;
            this.previewBox.Location = new System.Drawing.Point(6, 105);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(300, 175);
            this.previewBox.TabIndex = 3;
            this.previewBox.TabStop = false;
            // 
            // NumPlayback
            // 
            this.NumPlayback.Location = new System.Drawing.Point(165, 47);
            this.NumPlayback.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumPlayback.Name = "NumPlayback";
            this.NumPlayback.Size = new System.Drawing.Size(100, 21);
            this.NumPlayback.TabIndex = 1;
            this.NumPlayback.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumPlayback.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "# of playback";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxREC);
            this.groupBox3.Controls.Add(this.buttonRecord);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.buttonLoadFromFile);
            this.groupBox3.Controls.Add(this.buttonShowReport);
            this.groupBox3.Controls.Add(this.labelCorrectness);
            this.groupBox3.Controls.Add(this.buttonShowDir);
            this.groupBox3.Controls.Add(this.wordSelectedLabel);
            this.groupBox3.Controls.Add(this.buttonAnalyze);
            this.groupBox3.Controls.Add(this.buttonStopRecording);
            this.groupBox3.Location = new System.Drawing.Point(496, 92);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(326, 277);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pronunciation Aid (Beta)";
            // 
            // listBoxREC
            // 
            this.listBoxREC.FormattingEnabled = true;
            this.listBoxREC.HorizontalScrollbar = true;
            this.listBoxREC.ItemHeight = 15;
            this.listBoxREC.Location = new System.Drawing.Point(6, 79);
            this.listBoxREC.Name = "listBoxREC";
            this.listBoxREC.Size = new System.Drawing.Size(183, 124);
            this.listBoxREC.TabIndex = 13;
            // 
            // buttonRecord
            // 
            this.buttonRecord.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonRecord.Location = new System.Drawing.Point(195, 55);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(125, 25);
            this.buttonRecord.TabIndex = 4;
            this.buttonRecord.Text = "&Record";
            this.buttonRecord.UseVisualStyleBackColor = true;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 21);
            this.label6.TabIndex = 12;
            this.label6.Text = "Recognized: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonLoadFromFile
            // 
            this.buttonLoadFromFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLoadFromFile.Location = new System.Drawing.Point(195, 148);
            this.buttonLoadFromFile.Name = "buttonLoadFromFile";
            this.buttonLoadFromFile.Size = new System.Drawing.Size(125, 25);
            this.buttonLoadFromFile.TabIndex = 10;
            this.buttonLoadFromFile.Text = "From file";
            this.buttonLoadFromFile.UseVisualStyleBackColor = true;
            this.buttonLoadFromFile.Click += new System.EventHandler(this.buttonLoadFromFile_Click);
            // 
            // buttonShowReport
            // 
            this.buttonShowReport.Enabled = false;
            this.buttonShowReport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonShowReport.Location = new System.Drawing.Point(6, 245);
            this.buttonShowReport.Name = "buttonShowReport";
            this.buttonShowReport.Size = new System.Drawing.Size(314, 25);
            this.buttonShowReport.TabIndex = 9;
            this.buttonShowReport.Text = "Show score report";
            this.buttonShowReport.UseVisualStyleBackColor = true;
            this.buttonShowReport.Click += new System.EventHandler(this.buttonShowReport_Click);
            // 
            // labelCorrectness
            // 
            this.labelCorrectness.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCorrectness.ForeColor = System.Drawing.Color.Green;
            this.labelCorrectness.Location = new System.Drawing.Point(6, 207);
            this.labelCorrectness.Name = "labelCorrectness";
            this.labelCorrectness.Size = new System.Drawing.Size(314, 35);
            this.labelCorrectness.TabIndex = 8;
            this.labelCorrectness.Text = "Correctness";
            this.labelCorrectness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonShowDir
            // 
            this.buttonShowDir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonShowDir.Location = new System.Drawing.Point(195, 117);
            this.buttonShowDir.Name = "buttonShowDir";
            this.buttonShowDir.Size = new System.Drawing.Size(125, 25);
            this.buttonShowDir.TabIndex = 7;
            this.buttonShowDir.Text = "Play this";
            this.buttonShowDir.UseVisualStyleBackColor = true;
            this.buttonShowDir.Click += new System.EventHandler(this.buttonPlayUserRecording_Click);
            // 
            // wordSelectedLabel
            // 
            this.wordSelectedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordSelectedLabel.Location = new System.Drawing.Point(6, 17);
            this.wordSelectedLabel.Name = "wordSelectedLabel";
            this.wordSelectedLabel.Size = new System.Drawing.Size(314, 35);
            this.wordSelectedLabel.TabIndex = 6;
            this.wordSelectedLabel.Text = "No word has been selected";
            this.wordSelectedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.wordSelectedLabel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.wordSelectedLabel_MouseDoubleClick);
            // 
            // buttonAnalyze
            // 
            this.buttonAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonAnalyze.Location = new System.Drawing.Point(195, 179);
            this.buttonAnalyze.Name = "buttonAnalyze";
            this.buttonAnalyze.Size = new System.Drawing.Size(125, 25);
            this.buttonAnalyze.TabIndex = 5;
            this.buttonAnalyze.Text = "&Analyze";
            this.buttonAnalyze.UseVisualStyleBackColor = true;
            this.buttonAnalyze.Click += new System.EventHandler(this.buttonAnalyze_Click);
            // 
            // buttonStopRecording
            // 
            this.buttonStopRecording.Enabled = false;
            this.buttonStopRecording.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonStopRecording.Location = new System.Drawing.Point(195, 86);
            this.buttonStopRecording.Name = "buttonStopRecording";
            this.buttonStopRecording.Size = new System.Drawing.Size(125, 25);
            this.buttonStopRecording.TabIndex = 3;
            this.buttonStopRecording.Text = "&Stop";
            this.buttonStopRecording.UseVisualStyleBackColor = true;
            this.buttonStopRecording.Click += new System.EventHandler(this.buttonStopRecording_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tdButtonFormantPlot);
            this.groupBox4.Location = new System.Drawing.Point(496, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(326, 80);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Formant Plot";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.myTabControl);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 383);
            this.panel1.TabIndex = 7;
            // 
            // animationTimer
            // 
            this.animationTimer.Interval = 200;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // NAudioTimer
            // 
            this.NAudioTimer.Interval = 10;
            this.NAudioTimer.Tick += new System.EventHandler(this.NAudioTimer_Tick);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.hMMsToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(834, 32);
            this.mainMenuStrip.TabIndex = 8;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.logToolStripMenuItem});
            this.usersToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("usersToolStripMenuItem.Image")));
            this.usersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(71, 28);
            this.usersToolStripMenuItem.Text = "Users";
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("logToolStripMenuItem.Image")));
            this.logToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(173, 28);
            this.logToolStripMenuItem.Text = "Sign out";
            this.logToolStripMenuItem.Click += new System.EventHandler(this.logToolStripMenuItem_Click);
            // 
            // hMMsToolStripMenuItem
            // 
            this.hMMsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openHMMsFolderToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.hMMsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hMMsToolStripMenuItem.Image")));
            this.hMMsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.hMMsToolStripMenuItem.Name = "hMMsToolStripMenuItem";
            this.hMMsToolStripMenuItem.Size = new System.Drawing.Size(79, 28);
            this.hMMsToolStripMenuItem.Text = "HMMs";
            // 
            // openHMMsFolderToolStripMenuItem
            // 
            this.openHMMsFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openHMMsFolderToolStripMenuItem.Image")));
            this.openHMMsFolderToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openHMMsFolderToolStripMenuItem.Name = "openHMMsFolderToolStripMenuItem";
            this.openHMMsFolderToolStripMenuItem.Size = new System.Drawing.Size(184, 30);
            this.openHMMsFolderToolStripMenuItem.Text = "Open HMMs folder";
            this.openHMMsFolderToolStripMenuItem.Click += new System.EventHandler(this.openHMMsFolderToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("settingsToolStripMenuItem.Image")));
            this.settingsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(184, 30);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changePasswordToolStripMenuItem.Image")));
            this.changePasswordToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(173, 28);
            this.changePasswordToolStripMenuItem.Text = "Change password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // tdButtonFormantPlot
            // 
            this.tdButtonFormantPlot.BackgroundImage = global::MPAid.Properties.Resources.ButtonYellow_0;
            this.tdButtonFormantPlot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tdButtonFormantPlot.FlatAppearance.BorderSize = 0;
            this.tdButtonFormantPlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tdButtonFormantPlot.Location = new System.Drawing.Point(87, 24);
            this.tdButtonFormantPlot.Name = "tdButtonFormantPlot";
            this.tdButtonFormantPlot.Size = new System.Drawing.Size(150, 32);
            this.tdButtonFormantPlot.TabIndex = 0;
            this.tdButtonFormantPlot.Text = "Open Formant Plot";
            this.tdButtonFormantPlot.UseVisualStyleBackColor = true;
            this.tdButtonFormantPlot.Click += new System.EventHandler(this.tdButtonFormantPlot_Click);
            // 
            // ButtonStop
            // 
            this.ButtonStop.BackgroundImage = global::MPAid.Properties.Resources.ButtonRed_0;
            this.ButtonStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonStop.FlatAppearance.BorderSize = 0;
            this.ButtonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStop.Location = new System.Drawing.Point(159, 74);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(120, 25);
            this.ButtonStop.TabIndex = 7;
            this.ButtonStop.Text = "Stop Audio";
            this.ButtonStop.UseVisualStyleBackColor = true;
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // ButtonPlay
            // 
            this.ButtonPlay.BackgroundImage = global::MPAid.Properties.Resources.ButtonGreen_0;
            this.ButtonPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonPlay.FlatAppearance.BorderSize = 0;
            this.ButtonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonPlay.Location = new System.Drawing.Point(33, 74);
            this.ButtonPlay.Name = "ButtonPlay";
            this.ButtonPlay.Size = new System.Drawing.Size(120, 25);
            this.ButtonPlay.TabIndex = 6;
            this.ButtonPlay.Text = "Play Audio";
            this.ButtonPlay.UseVisualStyleBackColor = true;
            this.ButtonPlay.Click += new System.EventHandler(this.ButtonPlay_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(834, 496);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.headerBox);
            this.Controls.Add(this.mainMenuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(875, 535);
            this.MinimumSize = new System.Drawing.Size(850, 535);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Māori Pronunciation Aid";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            
            ((System.ComponentModel.ISupportInitialize)(this.headerBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.myTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedController)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPlayback)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox headerBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioFemale;
        private System.Windows.Forms.RadioButton radioOldMale;
        private System.Windows.Forms.TabControl myTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox VowelList;
        private System.Windows.Forms.ListBox WordList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown NumPlayback;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioYoungMale;
        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.NumericUpDown AudioDelay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.Button buttonShowDir;
        private System.Windows.Forms.Label wordSelectedLabel;
        private System.Windows.Forms.Button buttonAnalyze;
        private System.Windows.Forms.Button buttonRecord;
        private System.Windows.Forms.Button buttonStopRecording;
        private System.Windows.Forms.Label labelCorrectness;
        private TDButton tdButtonFormantPlot;
        private TDButton ButtonStop;
        private TDButton ButtonPlay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar speedController;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioYoungFemale;
        private System.Windows.Forms.Button buttonShowReport;
        private System.Windows.Forms.Button buttonLoadFromFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxREC;
        private System.Windows.Forms.Timer NAudioTimer;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hMMsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openHMMsFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
    }
}

