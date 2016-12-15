namespace MPAid.NewForms
{
    partial class SpeechRecognitionTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpeechRecognitionTest));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.optionsButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.analyzeButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.WordComboBox = new System.Windows.Forms.ComboBox();
            this.recordingProgressBarPanel = new System.Windows.Forms.Panel();
            this.recordingProgressBarLabel = new System.Windows.Forms.Label();
            this.recordingProgressBar = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.recordingProgressBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.optionsButton, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.backButton, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.analyzeButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.playButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.recordButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.WordComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.recordingProgressBarPanel, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 186);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // optionsButton
            // 
            this.optionsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optionsButton.Location = new System.Drawing.Point(358, 148);
            this.optionsButton.Margin = new System.Windows.Forms.Padding(10);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(96, 28);
            this.optionsButton.TabIndex = 32;
            this.optionsButton.Text = "More...";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // backButton
            // 
            this.backButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.backButton.Location = new System.Drawing.Point(474, 148);
            this.backButton.Margin = new System.Windows.Forms.Padding(10);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(100, 28);
            this.backButton.TabIndex = 31;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // analyzeButton
            // 
            this.analyzeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.analyzeButton, 3);
            this.analyzeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.analyzeButton.Location = new System.Drawing.Point(136, 102);
            this.analyzeButton.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(308, 26);
            this.analyzeButton.TabIndex = 30;
            this.analyzeButton.Text = "&Analyze";
            this.analyzeButton.UseVisualStyleBackColor = true;
            // 
            // playButton
            // 
            this.playButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.playButton.Location = new System.Drawing.Point(474, 56);
            this.playButton.Margin = new System.Windows.Forms.Padding(10);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(100, 26);
            this.playButton.TabIndex = 29;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            // 
            // recordButton
            // 
            this.recordButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.recordButton.Location = new System.Drawing.Point(10, 56);
            this.recordButton.Margin = new System.Windows.Forms.Padding(10);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(96, 26);
            this.recordButton.TabIndex = 28;
            this.recordButton.Text = "&Record";
            this.recordButton.UseVisualStyleBackColor = true;
            // 
            // WordComboBox
            // 
            this.WordComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.WordComboBox, 3);
            this.WordComboBox.FormattingEnabled = true;
            this.WordComboBox.ItemHeight = 13;
            this.WordComboBox.Location = new System.Drawing.Point(126, 12);
            this.WordComboBox.Name = "WordComboBox";
            this.WordComboBox.Size = new System.Drawing.Size(328, 21);
            this.WordComboBox.TabIndex = 2;
            this.WordComboBox.Text = "Start typing your word here...";
            // 
            // recordingProgressBarPanel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.recordingProgressBarPanel, 3);
            this.recordingProgressBarPanel.Controls.Add(this.recordingProgressBarLabel);
            this.recordingProgressBarPanel.Controls.Add(this.recordingProgressBar);
            this.recordingProgressBarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordingProgressBarPanel.Location = new System.Drawing.Point(119, 49);
            this.recordingProgressBarPanel.Name = "recordingProgressBarPanel";
            this.recordingProgressBarPanel.Size = new System.Drawing.Size(342, 40);
            this.recordingProgressBarPanel.TabIndex = 33;
            // 
            // recordingProgressBarLabel
            // 
            this.recordingProgressBarLabel.BackColor = System.Drawing.SystemColors.Control;
            this.recordingProgressBarLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.recordingProgressBarLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordingProgressBarLabel.Location = new System.Drawing.Point(0, 0);
            this.recordingProgressBarLabel.Name = "recordingProgressBarLabel";
            this.recordingProgressBarLabel.Size = new System.Drawing.Size(342, 40);
            this.recordingProgressBarLabel.TabIndex = 29;
            this.recordingProgressBarLabel.Text = "FILE_NAME";
            this.recordingProgressBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // recordingProgressBar
            // 
            this.recordingProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.recordingProgressBar.Location = new System.Drawing.Point(7, 7);
            this.recordingProgressBar.Margin = new System.Windows.Forms.Padding(10);
            this.recordingProgressBar.Name = "recordingProgressBar";
            this.recordingProgressBar.Size = new System.Drawing.Size(328, 26);
            this.recordingProgressBar.TabIndex = 28;
            // 
            // SpeechRecognitionTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 186);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SpeechRecognitionTest";
            this.Text = "MPAi - Version 4.0";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.recordingProgressBarPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox WordComboBox;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Button analyzeButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Panel recordingProgressBarPanel;
        private System.Windows.Forms.ProgressBar recordingProgressBar;
        private System.Windows.Forms.Label recordingProgressBarLabel;
    }
}