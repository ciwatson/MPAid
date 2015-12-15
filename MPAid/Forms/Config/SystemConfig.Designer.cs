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
            this.audioFolderTextBox = new System.Windows.Forms.TextBox();
            this.audioFolderLabel = new System.Windows.Forms.Label();
            this.audioFolderSelectButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.videoFolderSelectButton = new System.Windows.Forms.Button();
            this.videoFolderlabel = new System.Windows.Forms.Label();
            this.videoFolderTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // audioFolderTextBox
            // 
            this.audioFolderTextBox.Location = new System.Drawing.Point(127, 37);
            this.audioFolderTextBox.Name = "audioFolderTextBox";
            this.audioFolderTextBox.Size = new System.Drawing.Size(332, 20);
            this.audioFolderTextBox.TabIndex = 0;
            // 
            // audioFolderLabel
            // 
            this.audioFolderLabel.AutoSize = true;
            this.audioFolderLabel.Location = new System.Drawing.Point(20, 40);
            this.audioFolderLabel.Name = "audioFolderLabel";
            this.audioFolderLabel.Size = new System.Drawing.Size(66, 13);
            this.audioFolderLabel.TabIndex = 1;
            this.audioFolderLabel.Text = "Audio Folder";
            // 
            // audioFolderSelectButton
            // 
            this.audioFolderSelectButton.Location = new System.Drawing.Point(465, 37);
            this.audioFolderSelectButton.Name = "audioFolderSelectButton";
            this.audioFolderSelectButton.Size = new System.Drawing.Size(33, 25);
            this.audioFolderSelectButton.TabIndex = 2;
            this.audioFolderSelectButton.Text = "...";
            this.audioFolderSelectButton.UseVisualStyleBackColor = true;
            this.audioFolderSelectButton.Click += new System.EventHandler(this.folderSelectButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(388, 273);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(51, 25);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(445, 273);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(53, 25);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // videoFolderSelectButton
            // 
            this.videoFolderSelectButton.Location = new System.Drawing.Point(465, 74);
            this.videoFolderSelectButton.Name = "videoFolderSelectButton";
            this.videoFolderSelectButton.Size = new System.Drawing.Size(33, 25);
            this.videoFolderSelectButton.TabIndex = 7;
            this.videoFolderSelectButton.Text = "...";
            this.videoFolderSelectButton.UseVisualStyleBackColor = true;
            this.videoFolderSelectButton.Click += new System.EventHandler(this.videoFolderSelectButton_Click);
            // 
            // videoFolderlabel
            // 
            this.videoFolderlabel.AutoSize = true;
            this.videoFolderlabel.Location = new System.Drawing.Point(20, 77);
            this.videoFolderlabel.Name = "videoFolderlabel";
            this.videoFolderlabel.Size = new System.Drawing.Size(66, 13);
            this.videoFolderlabel.TabIndex = 6;
            this.videoFolderlabel.Text = "Video Folder";
            // 
            // videoFolderTextBox
            // 
            this.videoFolderTextBox.Location = new System.Drawing.Point(127, 74);
            this.videoFolderTextBox.Name = "videoFolderTextBox";
            this.videoFolderTextBox.Size = new System.Drawing.Size(332, 20);
            this.videoFolderTextBox.TabIndex = 5;
            // 
            // SystemConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 304);
            this.Controls.Add(this.videoFolderSelectButton);
            this.Controls.Add(this.videoFolderlabel);
            this.Controls.Add(this.videoFolderTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.audioFolderSelectButton);
            this.Controls.Add(this.audioFolderLabel);
            this.Controls.Add(this.audioFolderTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox audioFolderTextBox;
        private System.Windows.Forms.Label audioFolderLabel;
        private System.Windows.Forms.Button audioFolderSelectButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button videoFolderSelectButton;
        private System.Windows.Forms.Label videoFolderlabel;
        private System.Windows.Forms.TextBox videoFolderTextBox;
    }
}
