namespace MPAid.UserControls
{
    partial class NAudioRecorder
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
            this.RECListBox = new System.Windows.Forms.ListBox();
            this.recordButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.fromFileButton = new System.Windows.Forms.Button();
            this.showReportButton = new System.Windows.Forms.Button();
            this.correctnessLabel = new System.Windows.Forms.Label();
            this.analyzeButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.audioDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.recordingProgressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RECListBox
            // 
            this.RECListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RECListBox.FormattingEnabled = true;
            this.RECListBox.HorizontalScrollbar = true;
            this.RECListBox.Location = new System.Drawing.Point(6, 56);
            this.RECListBox.Name = "RECListBox";
            this.RECListBox.Size = new System.Drawing.Size(404, 147);
            this.RECListBox.TabIndex = 23;
            this.RECListBox.DoubleClick += new System.EventHandler(this.RECListBox_DoubleClick);
            // 
            // recordButton
            // 
            this.recordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.recordButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.recordButton.Location = new System.Drawing.Point(416, 56);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(58, 25);
            this.recordButton.TabIndex = 15;
            this.recordButton.Text = "&Record";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 21);
            this.label6.TabIndex = 22;
            this.label6.Text = "Recognized: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fromFileButton
            // 
            this.fromFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fromFileButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.fromFileButton.Location = new System.Drawing.Point(416, 152);
            this.fromFileButton.Name = "fromFileButton";
            this.fromFileButton.Size = new System.Drawing.Size(58, 25);
            this.fromFileButton.TabIndex = 21;
            this.fromFileButton.Text = "From file";
            this.fromFileButton.UseVisualStyleBackColor = true;
            this.fromFileButton.Click += new System.EventHandler(this.fromFileButton_Click);
            // 
            // showReportButton
            // 
            this.showReportButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.showReportButton.Enabled = false;
            this.showReportButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.showReportButton.Location = new System.Drawing.Point(140, 235);
            this.showReportButton.Name = "showReportButton";
            this.showReportButton.Size = new System.Drawing.Size(177, 25);
            this.showReportButton.TabIndex = 20;
            this.showReportButton.Text = "Show score report";
            this.showReportButton.UseVisualStyleBackColor = true;
            this.showReportButton.Click += new System.EventHandler(this.showReportButton_Click);
            // 
            // correctnessLabel
            // 
            this.correctnessLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.correctnessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.correctnessLabel.ForeColor = System.Drawing.Color.Green;
            this.correctnessLabel.Location = new System.Drawing.Point(163, 212);
            this.correctnessLabel.Name = "correctnessLabel";
            this.correctnessLabel.Size = new System.Drawing.Size(139, 20);
            this.correctnessLabel.TabIndex = 19;
            this.correctnessLabel.Text = "Correctness";
            this.correctnessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // analyzeButton
            // 
            this.analyzeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.analyzeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.analyzeButton.Location = new System.Drawing.Point(416, 183);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(58, 25);
            this.analyzeButton.TabIndex = 16;
            this.analyzeButton.Text = "&Analyze";
            this.analyzeButton.UseVisualStyleBackColor = true;
            this.analyzeButton.Click += new System.EventHandler(this.analyzeButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stopButton.Enabled = false;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.stopButton.Location = new System.Drawing.Point(416, 90);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(58, 25);
            this.stopButton.TabIndex = 14;
            this.stopButton.Text = "&Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // audioDeviceComboBox
            // 
            this.audioDeviceComboBox.FormattingEnabled = true;
            this.audioDeviceComboBox.Location = new System.Drawing.Point(80, 3);
            this.audioDeviceComboBox.Name = "audioDeviceComboBox";
            this.audioDeviceComboBox.Size = new System.Drawing.Size(116, 21);
            this.audioDeviceComboBox.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Audio Device";
            // 
            // recordingProgressBar
            // 
            this.recordingProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.recordingProgressBar.Location = new System.Drawing.Point(328, 0);
            this.recordingProgressBar.Name = "recordingProgressBar";
            this.recordingProgressBar.Size = new System.Drawing.Size(146, 23);
            this.recordingProgressBar.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Recording Progress";
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(417, 123);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(57, 23);
            this.deleteButton.TabIndex = 28;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // NAudioRecorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.recordingProgressBar);
            this.Controls.Add(this.audioDeviceComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RECListBox);
            this.Controls.Add(this.recordButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.fromFileButton);
            this.Controls.Add(this.showReportButton);
            this.Controls.Add(this.correctnessLabel);
            this.Controls.Add(this.analyzeButton);
            this.Controls.Add(this.stopButton);
            this.Name = "NAudioRecorder";
            this.Size = new System.Drawing.Size(477, 273);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button analyzeButton;
        private System.Windows.Forms.Label correctnessLabel;
        private System.Windows.Forms.Button showReportButton;
        private System.Windows.Forms.Button fromFileButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.ListBox RECListBox;
        private System.Windows.Forms.ComboBox audioDeviceComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar recordingProgressBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button deleteButton;
    }
}
