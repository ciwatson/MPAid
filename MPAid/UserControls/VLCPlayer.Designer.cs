namespace MPAid.UserControls
{
    partial class VlcPlayer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VlcPlayer));
            this.vlcControl = new Vlc.DotNet.Forms.VlcControl();
            this.stopButton = new System.Windows.Forms.Button();
            this.stopImageList = new System.Windows.Forms.ImageList(this.components);
            this.playButton = new System.Windows.Forms.Button();
            this.playImageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl)).BeginInit();
            this.SuspendLayout();
            // 
            // vlcControl
            // 
            this.vlcControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vlcControl.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.vlcControl.Location = new System.Drawing.Point(4, 1);
            this.vlcControl.Name = "vlcControl";
            this.vlcControl.Size = new System.Drawing.Size(542, 280);
            this.vlcControl.TabIndex = 3;
            this.vlcControl.Text = "vlcControl1";
            this.vlcControl.VlcLibDirectory = null;
            this.vlcControl.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.OnVlcControlNeedLibDirectory);
            this.vlcControl.Stopped += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs>(this.OnVlcControlStopped);
            // 
            // stopButton
            // 
            this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stopButton.FlatAppearance.BorderSize = 0;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.ImageIndex = 0;
            this.stopButton.ImageList = this.stopImageList;
            this.stopButton.Location = new System.Drawing.Point(57, 282);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(44, 44);
            this.stopButton.TabIndex = 5;
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            this.stopButton.MouseEnter += new System.EventHandler(this.stopButton_MouseEnter);
            this.stopButton.MouseLeave += new System.EventHandler(this.stopButton_MouseLeave);
            // 
            // stopImageList
            // 
            this.stopImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("stopImageList.ImageStream")));
            this.stopImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.stopImageList.Images.SetKeyName(0, "stop_64_1.png");
            this.stopImageList.Images.SetKeyName(1, "stop_64_2.png");
            // 
            // playButton
            // 
            this.playButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.playButton.FlatAppearance.BorderSize = 0;
            this.playButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.playButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.ImageIndex = 0;
            this.playButton.ImageList = this.playImageList;
            this.playButton.Location = new System.Drawing.Point(4, 283);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(48, 44);
            this.playButton.TabIndex = 6;
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            this.playButton.MouseEnter += new System.EventHandler(this.playButton_MouseEnter);
            this.playButton.MouseLeave += new System.EventHandler(this.playButton_MouseLeave);
            // 
            // playImageList
            // 
            this.playImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("playImageList.ImageStream")));
            this.playImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.playImageList.Images.SetKeyName(0, "play_64_1.png");
            this.playImageList.Images.SetKeyName(1, "play_64_2.png");
            this.playImageList.Images.SetKeyName(2, "pause_64_1.png");
            this.playImageList.Images.SetKeyName(3, "pause_64_2.png");
            // 
            // VlcPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.vlcControl);
            this.Name = "VlcPlayer";
            this.Size = new System.Drawing.Size(549, 327);
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Vlc.DotNet.Forms.VlcControl vlcControl;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.ImageList playImageList;
        private System.Windows.Forms.ImageList stopImageList;
    }
}
