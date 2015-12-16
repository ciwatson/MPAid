namespace MPAid.UserControls
{
    partial class OperationTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vlcPlayer = new MPAid.UserControls.VlcPlayer();
            this.tdButtonFormantPlot = new MPAid.TDButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 18);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(529, 151);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.vlcPlayer);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(521, 125);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Video Player";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(521, 137);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pronouciation Aid";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.tdButtonFormantPlot);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(512, 51);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Formant Plot";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBox3.Location = new System.Drawing.Point(3, 59);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(512, 74);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pronunciation Aid (Beta)";
            // 
            // listBoxREC
            // 
            this.listBoxREC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxREC.FormattingEnabled = true;
            this.listBoxREC.HorizontalScrollbar = true;
            this.listBoxREC.ItemHeight = 12;
            this.listBoxREC.Location = new System.Drawing.Point(9, 59);
            this.listBoxREC.Name = "listBoxREC";
            this.listBoxREC.Size = new System.Drawing.Size(433, 4);
            this.listBoxREC.TabIndex = 13;
            // 
            // buttonRecord
            // 
            this.buttonRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRecord.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonRecord.Location = new System.Drawing.Point(448, 14);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(58, 23);
            this.buttonRecord.TabIndex = 4;
            this.buttonRecord.Text = "&Record";
            this.buttonRecord.UseVisualStyleBackColor = true;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Recognized: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonLoadFromFile
            // 
            this.buttonLoadFromFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadFromFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLoadFromFile.Location = new System.Drawing.Point(448, 100);
            this.buttonLoadFromFile.Name = "buttonLoadFromFile";
            this.buttonLoadFromFile.Size = new System.Drawing.Size(58, 23);
            this.buttonLoadFromFile.TabIndex = 10;
            this.buttonLoadFromFile.Text = "From file";
            this.buttonLoadFromFile.UseVisualStyleBackColor = true;
            // 
            // buttonShowReport
            // 
            this.buttonShowReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowReport.Enabled = false;
            this.buttonShowReport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonShowReport.Location = new System.Drawing.Point(98, 45);
            this.buttonShowReport.Name = "buttonShowReport";
            this.buttonShowReport.Size = new System.Drawing.Size(309, 23);
            this.buttonShowReport.TabIndex = 9;
            this.buttonShowReport.Text = "Show score report";
            this.buttonShowReport.UseVisualStyleBackColor = true;
            // 
            // labelCorrectness
            // 
            this.labelCorrectness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCorrectness.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCorrectness.ForeColor = System.Drawing.Color.Green;
            this.labelCorrectness.Location = new System.Drawing.Point(174, 24);
            this.labelCorrectness.Name = "labelCorrectness";
            this.labelCorrectness.Size = new System.Drawing.Size(165, 18);
            this.labelCorrectness.TabIndex = 8;
            this.labelCorrectness.Text = "Correctness";
            this.labelCorrectness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonShowDir
            // 
            this.buttonShowDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowDir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonShowDir.Location = new System.Drawing.Point(448, 71);
            this.buttonShowDir.Name = "buttonShowDir";
            this.buttonShowDir.Size = new System.Drawing.Size(58, 23);
            this.buttonShowDir.TabIndex = 7;
            this.buttonShowDir.Text = "Play this";
            this.buttonShowDir.UseVisualStyleBackColor = true;
            // 
            // wordSelectedLabel
            // 
            this.wordSelectedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wordSelectedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordSelectedLabel.Location = new System.Drawing.Point(6, 16);
            this.wordSelectedLabel.Name = "wordSelectedLabel";
            this.wordSelectedLabel.Size = new System.Drawing.Size(436, 21);
            this.wordSelectedLabel.TabIndex = 6;
            this.wordSelectedLabel.Text = "No word has been selected";
            this.wordSelectedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAnalyze
            // 
            this.buttonAnalyze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonAnalyze.Location = new System.Drawing.Point(448, 128);
            this.buttonAnalyze.Name = "buttonAnalyze";
            this.buttonAnalyze.Size = new System.Drawing.Size(58, 23);
            this.buttonAnalyze.TabIndex = 5;
            this.buttonAnalyze.Text = "&Analyze";
            this.buttonAnalyze.UseVisualStyleBackColor = true;
            // 
            // buttonStopRecording
            // 
            this.buttonStopRecording.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStopRecording.Enabled = false;
            this.buttonStopRecording.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonStopRecording.Location = new System.Drawing.Point(448, 42);
            this.buttonStopRecording.Name = "buttonStopRecording";
            this.buttonStopRecording.Size = new System.Drawing.Size(58, 23);
            this.buttonStopRecording.TabIndex = 3;
            this.buttonStopRecording.Text = "&Stop";
            this.buttonStopRecording.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 174);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation Panel";
            // 
            // vlcPlayer
            // 
            this.vlcPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vlcPlayer.Location = new System.Drawing.Point(0, 0);
            this.vlcPlayer.Name = "vlcPlayer";
            this.vlcPlayer.Size = new System.Drawing.Size(521, 119);
            this.vlcPlayer.TabIndex = 0;
            // 
            // tdButtonFormantPlot
            // 
            this.tdButtonFormantPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tdButtonFormantPlot.BackgroundImage = global::MPAid.Properties.Resources.ButtonYellow_0;
            this.tdButtonFormantPlot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tdButtonFormantPlot.FlatAppearance.BorderSize = 0;
            this.tdButtonFormantPlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tdButtonFormantPlot.Location = new System.Drawing.Point(166, 18);
            this.tdButtonFormantPlot.Name = "tdButtonFormantPlot";
            this.tdButtonFormantPlot.Size = new System.Drawing.Size(145, 25);
            this.tdButtonFormantPlot.TabIndex = 0;
            this.tdButtonFormantPlot.Text = "Open Formant Plot";
            this.tdButtonFormantPlot.UseVisualStyleBackColor = true;
            this.tdButtonFormantPlot.Click += new System.EventHandler(this.tdButtonFormantPlot_Click);
            // 
            // OperationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "OperationPanel";
            this.Size = new System.Drawing.Size(649, 252);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private VlcPlayer vlcPlayer;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox4;
        private TDButton tdButtonFormantPlot;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listBoxREC;
        private System.Windows.Forms.Button buttonRecord;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonLoadFromFile;
        private System.Windows.Forms.Button buttonShowReport;
        private System.Windows.Forms.Label labelCorrectness;
        private System.Windows.Forms.Button buttonShowDir;
        private System.Windows.Forms.Label wordSelectedLabel;
        private System.Windows.Forms.Button buttonAnalyze;
        private System.Windows.Forms.Button buttonStopRecording;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
