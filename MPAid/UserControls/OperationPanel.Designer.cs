namespace MPAid.UserControls
{
    partial class OperationPanel
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
            this.operationTabControl = new System.Windows.Forms.TabControl();
            this.videoPlayerTabPage = new System.Windows.Forms.TabPage();
            this.vlcPlayer = new MPAid.UserControls.VlcPlayer();
            this.recognizerTabPage = new System.Windows.Forms.TabPage();
            this.naudioRecorder = new MPAid.UserControls.NAudioRecorder();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tdButtonFormantPlot = new MPAid.TDButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.operationTabControl.SuspendLayout();
            this.videoPlayerTabPage.SuspendLayout();
            this.recognizerTabPage.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // operationTabControl
            // 
            this.operationTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.operationTabControl.Controls.Add(this.videoPlayerTabPage);
            this.operationTabControl.Controls.Add(this.recognizerTabPage);
            this.operationTabControl.Controls.Add(this.tabPage2);
            this.operationTabControl.Location = new System.Drawing.Point(6, 19);
            this.operationTabControl.Name = "operationTabControl";
            this.operationTabControl.SelectedIndex = 0;
            this.operationTabControl.Size = new System.Drawing.Size(529, 394);
            this.operationTabControl.TabIndex = 0;
            this.operationTabControl.Tag = "";
            this.operationTabControl.SelectedIndexChanged += new System.EventHandler(this.operationTabControlSelectedIndexChanged);
            // 
            // videoPlayerTabPage
            // 
            this.videoPlayerTabPage.Controls.Add(this.vlcPlayer);
            this.videoPlayerTabPage.Location = new System.Drawing.Point(4, 22);
            this.videoPlayerTabPage.Name = "videoPlayerTabPage";
            this.videoPlayerTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.videoPlayerTabPage.Size = new System.Drawing.Size(521, 368);
            this.videoPlayerTabPage.TabIndex = 0;
            this.videoPlayerTabPage.Text = "Video Player";
            this.videoPlayerTabPage.UseVisualStyleBackColor = true;
            // 
            // vlcPlayer
            // 
            this.vlcPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vlcPlayer.Location = new System.Drawing.Point(0, 0);
            this.vlcPlayer.Name = "vlcPlayer";
            this.vlcPlayer.Size = new System.Drawing.Size(518, 365);
            this.vlcPlayer.TabIndex = 0;
            // 
            // recognizerTabPage
            // 
            this.recognizerTabPage.Controls.Add(this.naudioRecorder);
            this.recognizerTabPage.Location = new System.Drawing.Point(4, 22);
            this.recognizerTabPage.Name = "recognizerTabPage";
            this.recognizerTabPage.Size = new System.Drawing.Size(521, 368);
            this.recognizerTabPage.TabIndex = 2;
            this.recognizerTabPage.Text = "Recognizer";
            this.recognizerTabPage.UseVisualStyleBackColor = true;
            // 
            // naudioRecorder
            // 
            this.naudioRecorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.naudioRecorder.Location = new System.Drawing.Point(4, 4);
            this.naudioRecorder.Name = "naudioRecorder";
            this.naudioRecorder.Size = new System.Drawing.Size(514, 361);
            this.naudioRecorder.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(521, 368);
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
            this.groupBox4.Size = new System.Drawing.Size(512, 55);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Formant Plot";
            // 
            // tdButtonFormantPlot
            // 
            this.tdButtonFormantPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tdButtonFormantPlot.BackgroundImage = global::MPAid.Properties.Resources.ButtonYellow_0;
            this.tdButtonFormantPlot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tdButtonFormantPlot.FlatAppearance.BorderSize = 0;
            this.tdButtonFormantPlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tdButtonFormantPlot.Location = new System.Drawing.Point(166, 19);
            this.tdButtonFormantPlot.Name = "tdButtonFormantPlot";
            this.tdButtonFormantPlot.Size = new System.Drawing.Size(145, 27);
            this.tdButtonFormantPlot.TabIndex = 0;
            this.tdButtonFormantPlot.Text = "Open Formant Plot";
            this.tdButtonFormantPlot.UseVisualStyleBackColor = true;
            this.tdButtonFormantPlot.Click += new System.EventHandler(this.tdButtonFormantPlot_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.operationTabControl);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 419);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation Panel";
            // 
            // OperationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "OperationPanel";
            this.Size = new System.Drawing.Size(649, 475);
            this.operationTabControl.ResumeLayout(false);
            this.videoPlayerTabPage.ResumeLayout(false);
            this.recognizerTabPage.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl operationTabControl;
        private System.Windows.Forms.TabPage videoPlayerTabPage;
        private VlcPlayer vlcPlayer;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox4;
        private TDButton tdButtonFormantPlot;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage recognizerTabPage;
        private NAudioRecorder naudioRecorder;
    }
}
