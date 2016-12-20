namespace MPAid.NewForms
{
    partial class RenameFileDialog
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
            this.labelTextBox = new System.Windows.Forms.TextBox();
            this.labelLabel = new System.Windows.Forms.Label();
            this.wordLabel = new System.Windows.Forms.Label();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.speakerTextBox = new System.Windows.Forms.TextBox();
            this.speakerLabel = new System.Windows.Forms.Label();
            this.filenameTextBox = new System.Windows.Forms.TextBox();
            this.filenameLabel = new System.Windows.Forms.Label();
            this.filePickerButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.WordComboBox = new System.Windows.Forms.ComboBox();
            this.ExplanationLabel = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // labelTextBox
            // 
            this.labelTextBox.Location = new System.Drawing.Point(81, 150);
            this.labelTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.labelTextBox.Name = "labelTextBox";
            this.labelTextBox.Size = new System.Drawing.Size(322, 20);
            this.labelTextBox.TabIndex = 4;
            // 
            // labelLabel
            // 
            this.labelLabel.AutoSize = true;
            this.labelLabel.Location = new System.Drawing.Point(26, 153);
            this.labelLabel.Margin = new System.Windows.Forms.Padding(10);
            this.labelLabel.Name = "labelLabel";
            this.labelLabel.Size = new System.Drawing.Size(33, 13);
            this.labelLabel.TabIndex = 25;
            this.labelLabel.Text = "Label";
            // 
            // wordLabel
            // 
            this.wordLabel.AutoSize = true;
            this.wordLabel.Location = new System.Drawing.Point(26, 127);
            this.wordLabel.Margin = new System.Windows.Forms.Padding(10);
            this.wordLabel.Name = "wordLabel";
            this.wordLabel.Size = new System.Drawing.Size(33, 13);
            this.wordLabel.TabIndex = 23;
            this.wordLabel.Text = "Word";
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Location = new System.Drawing.Point(26, 101);
            this.CategoryLabel.Margin = new System.Windows.Forms.Padding(10);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(49, 13);
            this.CategoryLabel.TabIndex = 21;
            this.CategoryLabel.Text = "Category";
            // 
            // speakerTextBox
            // 
            this.speakerTextBox.Location = new System.Drawing.Point(81, 72);
            this.speakerTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.speakerTextBox.Name = "speakerTextBox";
            this.speakerTextBox.Size = new System.Drawing.Size(322, 20);
            this.speakerTextBox.TabIndex = 1;
            // 
            // speakerLabel
            // 
            this.speakerLabel.AutoSize = true;
            this.speakerLabel.Location = new System.Drawing.Point(26, 75);
            this.speakerLabel.Margin = new System.Windows.Forms.Padding(10);
            this.speakerLabel.Name = "speakerLabel";
            this.speakerLabel.Size = new System.Drawing.Size(47, 13);
            this.speakerLabel.TabIndex = 19;
            this.speakerLabel.Text = "Speaker";
            // 
            // filenameTextBox
            // 
            this.filenameTextBox.Location = new System.Drawing.Point(81, 45);
            this.filenameTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.filenameTextBox.Name = "filenameTextBox";
            this.filenameTextBox.ReadOnly = true;
            this.filenameTextBox.Size = new System.Drawing.Size(297, 20);
            this.filenameTextBox.TabIndex = 30;
            this.filenameTextBox.TabStop = false;
            // 
            // filenameLabel
            // 
            this.filenameLabel.AutoSize = true;
            this.filenameLabel.Location = new System.Drawing.Point(26, 49);
            this.filenameLabel.Margin = new System.Windows.Forms.Padding(10);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(49, 13);
            this.filenameLabel.TabIndex = 17;
            this.filenameLabel.Text = "Filename";
            // 
            // filePickerButton
            // 
            this.filePickerButton.Location = new System.Drawing.Point(377, 44);
            this.filePickerButton.Margin = new System.Windows.Forms.Padding(10);
            this.filePickerButton.Name = "filePickerButton";
            this.filePickerButton.Size = new System.Drawing.Size(26, 22);
            this.filePickerButton.TabIndex = 0;
            this.filePickerButton.Text = "...";
            this.filePickerButton.UseVisualStyleBackColor = true;
            this.filePickerButton.Click += new System.EventHandler(this.filePickerButton_Click);
            // 
            // renameButton
            // 
            this.renameButton.Location = new System.Drawing.Point(247, 181);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(75, 23);
            this.renameButton.TabIndex = 5;
            this.renameButton.Text = "Rename";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(328, 181);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Location = new System.Drawing.Point(81, 98);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(322, 21);
            this.CategoryComboBox.TabIndex = 2;
            // 
            // WordComboBox
            // 
            this.WordComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.WordComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.WordComboBox.FormattingEnabled = true;
            this.WordComboBox.Location = new System.Drawing.Point(81, 124);
            this.WordComboBox.Name = "WordComboBox";
            this.WordComboBox.Size = new System.Drawing.Size(322, 21);
            this.WordComboBox.TabIndex = 3;
            this.WordComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WordComboBox_KeyPress);
            // 
            // ExplanationLabel
            // 
            this.ExplanationLabel.AutoSize = true;
            this.ExplanationLabel.Location = new System.Drawing.Point(5, 9);
            this.ExplanationLabel.MaximumSize = new System.Drawing.Size(425, 0);
            this.ExplanationLabel.Name = "ExplanationLabel";
            this.ExplanationLabel.Size = new System.Drawing.Size(420, 26);
            this.ExplanationLabel.TabIndex = 29;
            this.ExplanationLabel.Text = "MPAi recordings must have particular names. Please enter your details below, and " +
    "MPAi will generate it automatically, and place it where it\'s meant to be.";
            this.ExplanationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "recording";
            this.openFileDialog.Filter = "Audio files (*.wav)|*.wav|All files (*.*)|*.*";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // RenameFileDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 211);
            this.Controls.Add(this.ExplanationLabel);
            this.Controls.Add(this.WordComboBox);
            this.Controls.Add(this.CategoryComboBox);
            this.Controls.Add(this.labelTextBox);
            this.Controls.Add(this.labelLabel);
            this.Controls.Add(this.wordLabel);
            this.Controls.Add(this.CategoryLabel);
            this.Controls.Add(this.speakerTextBox);
            this.Controls.Add(this.speakerLabel);
            this.Controls.Add(this.filenameTextBox);
            this.Controls.Add(this.filenameLabel);
            this.Controls.Add(this.filePickerButton);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "RenameFileDialog";
            this.Text = "RenameFileDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox labelTextBox;
        private System.Windows.Forms.Label labelLabel;
        private System.Windows.Forms.Label wordLabel;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.TextBox speakerTextBox;
        private System.Windows.Forms.Label speakerLabel;
        private System.Windows.Forms.TextBox filenameTextBox;
        private System.Windows.Forms.Label filenameLabel;
        private System.Windows.Forms.Button filePickerButton;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.ComboBox WordComboBox;
        private System.Windows.Forms.Label ExplanationLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}