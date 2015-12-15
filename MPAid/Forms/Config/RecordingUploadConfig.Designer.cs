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
            this.audioLocalListBox = new System.Windows.Forms.ListBox();
            this.onDBListBox = new System.Windows.Forms.ListBox();
            this.toDBButton = new System.Windows.Forms.Button();
            this.toLocalButton = new System.Windows.Forms.Button();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mediaLocalTabControl = new System.Windows.Forms.TabControl();
            this.audioTabPage = new System.Windows.Forms.TabPage();
            this.videoTabPage = new System.Windows.Forms.TabPage();
            this.videoLocalListBox = new System.Windows.Forms.ListBox();
            this.mediaLocalTabControl.SuspendLayout();
            this.audioTabPage.SuspendLayout();
            this.videoTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // audioLocalListBox
            // 
            this.audioLocalListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.audioLocalListBox.FormattingEnabled = true;
            this.audioLocalListBox.HorizontalScrollbar = true;
            this.audioLocalListBox.Location = new System.Drawing.Point(0, 0);
            this.audioLocalListBox.Name = "audioLocalListBox";
            this.audioLocalListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.audioLocalListBox.Size = new System.Drawing.Size(184, 238);
            this.audioLocalListBox.TabIndex = 0;
            // 
            // onDBListBox
            // 
            this.onDBListBox.FormattingEnabled = true;
            this.onDBListBox.HorizontalScrollbar = true;
            this.onDBListBox.Location = new System.Drawing.Point(37, 21);
            this.onDBListBox.Name = "onDBListBox";
            this.onDBListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.onDBListBox.Size = new System.Drawing.Size(189, 264);
            this.onDBListBox.TabIndex = 1;
            // 
            // toDBButton
            // 
            this.toDBButton.Location = new System.Drawing.Point(247, 21);
            this.toDBButton.Name = "toDBButton";
            this.toDBButton.Size = new System.Drawing.Size(50, 25);
            this.toDBButton.TabIndex = 2;
            this.toDBButton.Text = "<<";
            this.toDBButton.UseVisualStyleBackColor = true;
            this.toDBButton.Click += new System.EventHandler(this.toDBButton_Click);
            // 
            // toLocalButton
            // 
            this.toLocalButton.Location = new System.Drawing.Point(247, 137);
            this.toLocalButton.Name = "toLocalButton";
            this.toLocalButton.Size = new System.Drawing.Size(50, 25);
            this.toLocalButton.TabIndex = 3;
            this.toLocalButton.Text = ">>";
            this.toLocalButton.UseVisualStyleBackColor = true;
            this.toLocalButton.Click += new System.EventHandler(this.toLocalButton_Click);
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(247, 260);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(50, 25);
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
            // mediaLocalTabControl
            // 
            this.mediaLocalTabControl.Controls.Add(this.audioTabPage);
            this.mediaLocalTabControl.Controls.Add(this.videoTabPage);
            this.mediaLocalTabControl.Location = new System.Drawing.Point(321, 21);
            this.mediaLocalTabControl.Name = "mediaLocalTabControl";
            this.mediaLocalTabControl.SelectedIndex = 0;
            this.mediaLocalTabControl.Size = new System.Drawing.Size(192, 264);
            this.mediaLocalTabControl.TabIndex = 5;
            this.mediaLocalTabControl.SelectedIndexChanged += new System.EventHandler(this.mediaLocalTabControl_SelectedIndexChanged);
            // 
            // audioTabPage
            // 
            this.audioTabPage.Controls.Add(this.audioLocalListBox);
            this.audioTabPage.Location = new System.Drawing.Point(4, 22);
            this.audioTabPage.Name = "audioTabPage";
            this.audioTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.audioTabPage.Size = new System.Drawing.Size(184, 238);
            this.audioTabPage.TabIndex = 0;
            this.audioTabPage.Text = "Audio";
            this.audioTabPage.UseVisualStyleBackColor = true;
            // 
            // videoTabPage
            // 
            this.videoTabPage.Controls.Add(this.videoLocalListBox);
            this.videoTabPage.Location = new System.Drawing.Point(4, 22);
            this.videoTabPage.Name = "videoTabPage";
            this.videoTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.videoTabPage.Size = new System.Drawing.Size(184, 238);
            this.videoTabPage.TabIndex = 1;
            this.videoTabPage.Text = "Video";
            this.videoTabPage.UseVisualStyleBackColor = true;
            // 
            // videoLocalListBox
            // 
            this.videoLocalListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoLocalListBox.FormattingEnabled = true;
            this.videoLocalListBox.HorizontalScrollbar = true;
            this.videoLocalListBox.Location = new System.Drawing.Point(0, 0);
            this.videoLocalListBox.Name = "videoLocalListBox";
            this.videoLocalListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.videoLocalListBox.Size = new System.Drawing.Size(184, 238);
            this.videoLocalListBox.TabIndex = 0;
            // 
            // RecordingUploadConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 312);
            this.Controls.Add(this.mediaLocalTabControl);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.toLocalButton);
            this.Controls.Add(this.toDBButton);
            this.Controls.Add(this.onDBListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecordingUploadConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.mediaLocalTabControl.ResumeLayout(false);
            this.audioTabPage.ResumeLayout(false);
            this.videoTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox audioLocalListBox;
        private System.Windows.Forms.ListBox onDBListBox;
        private System.Windows.Forms.Button toDBButton;
        private System.Windows.Forms.Button toLocalButton;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabControl mediaLocalTabControl;
        private System.Windows.Forms.TabPage audioTabPage;
        private System.Windows.Forms.TabPage videoTabPage;
        private System.Windows.Forms.ListBox videoLocalListBox;
    }
}
