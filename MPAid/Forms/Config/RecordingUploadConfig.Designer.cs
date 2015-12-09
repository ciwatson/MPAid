using MPAid.Models;

namespace MPAid.Forms.Config
{
    partial class RecordingUploadConfig
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
            this.onLocalListBox = new System.Windows.Forms.ListBox();
            this.onDBListBox = new System.Windows.Forms.ListBox();
            this.toDBButton = new System.Windows.Forms.Button();
            this.toLocalButton = new System.Windows.Forms.Button();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // onLocalListBox
            // 
            this.onLocalListBox.FormattingEnabled = true;
            this.onLocalListBox.HorizontalScrollbar = true;
            this.onLocalListBox.ItemHeight = 12;
            this.onLocalListBox.Location = new System.Drawing.Point(317, 19);
            this.onLocalListBox.Name = "onLocalListBox";
            this.onLocalListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.onLocalListBox.Size = new System.Drawing.Size(188, 244);
            this.onLocalListBox.TabIndex = 0;
            // 
            // onDBListBox
            // 
            this.onDBListBox.FormattingEnabled = true;
            this.onDBListBox.HorizontalScrollbar = true;
            this.onDBListBox.ItemHeight = 12;
            this.onDBListBox.Location = new System.Drawing.Point(37, 19);
            this.onDBListBox.Name = "onDBListBox";
            this.onDBListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.onDBListBox.Size = new System.Drawing.Size(189, 244);
            this.onDBListBox.TabIndex = 1;
            // 
            // toDBButton
            // 
            this.toDBButton.Location = new System.Drawing.Point(247, 19);
            this.toDBButton.Name = "toDBButton";
            this.toDBButton.Size = new System.Drawing.Size(50, 23);
            this.toDBButton.TabIndex = 2;
            this.toDBButton.Text = "<<";
            this.toDBButton.UseVisualStyleBackColor = true;
            this.toDBButton.Click += new System.EventHandler(this.toDBButton_Click);
            // 
            // toLocalButton
            // 
            this.toLocalButton.Location = new System.Drawing.Point(247, 126);
            this.toLocalButton.Name = "toLocalButton";
            this.toLocalButton.Size = new System.Drawing.Size(50, 23);
            this.toLocalButton.TabIndex = 3;
            this.toLocalButton.Text = ">>";
            this.toLocalButton.UseVisualStyleBackColor = true;
            this.toLocalButton.Click += new System.EventHandler(this.toLocalButton_Click);
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(247, 240);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(50, 23);
            this.selectFileButton.TabIndex = 4;
            this.selectFileButton.Text = "Select";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Speaker-Category-Word.Ext";
            this.openFileDialog.Multiselect = true;
            // 
            // RecordingConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 288);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.toLocalButton);
            this.Controls.Add(this.toDBButton);
            this.Controls.Add(this.onDBListBox);
            this.Controls.Add(this.onLocalListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecordingConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox onLocalListBox;
        private System.Windows.Forms.ListBox onDBListBox;
        private System.Windows.Forms.Button toDBButton;
        private System.Windows.Forms.Button toLocalButton;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
