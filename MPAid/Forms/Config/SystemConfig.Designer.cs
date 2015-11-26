namespace MPAid.Forms.Config
{
    partial class SystemConfig
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
            this.recordingFolderTextBox = new System.Windows.Forms.TextBox();
            this.recordingFolderLabel = new System.Windows.Forms.Label();
            this.folderSelectButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // recordingFolderTextBox
            // 
            this.recordingFolderTextBox.Location = new System.Drawing.Point(127, 34);
            this.recordingFolderTextBox.Name = "recordingFolderTextBox";
            this.recordingFolderTextBox.Size = new System.Drawing.Size(220, 21);
            this.recordingFolderTextBox.TabIndex = 0;
            // 
            // recordingFolderLabel
            // 
            this.recordingFolderLabel.AutoSize = true;
            this.recordingFolderLabel.Location = new System.Drawing.Point(20, 37);
            this.recordingFolderLabel.Name = "recordingFolderLabel";
            this.recordingFolderLabel.Size = new System.Drawing.Size(101, 12);
            this.recordingFolderLabel.TabIndex = 1;
            this.recordingFolderLabel.Text = "Recording Folder";
            // 
            // folderSelectButton
            // 
            this.folderSelectButton.Location = new System.Drawing.Point(353, 34);
            this.folderSelectButton.Name = "folderSelectButton";
            this.folderSelectButton.Size = new System.Drawing.Size(33, 23);
            this.folderSelectButton.TabIndex = 2;
            this.folderSelectButton.Text = "...";
            this.folderSelectButton.UseVisualStyleBackColor = true;
            this.folderSelectButton.Click += new System.EventHandler(this.folderSelectButton_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.SelectedPath = "./Recording";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(254, 173);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(51, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(311, 173);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(53, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SystemConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 226);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.folderSelectButton);
            this.Controls.Add(this.recordingFolderLabel);
            this.Controls.Add(this.recordingFolderTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox recordingFolderTextBox;
        private System.Windows.Forms.Label recordingFolderLabel;
        private System.Windows.Forms.Button folderSelectButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
    }
}
