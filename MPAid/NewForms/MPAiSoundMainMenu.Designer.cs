namespace MPAid.NewForms
{
    partial class MPAiSoundMainMenu
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.headerBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heritageMāoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modernMāoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feminineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masculineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.greetingLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.learnButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.scanReportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.headerBox);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(552, 332);
            this.splitContainer1.SplitterDistance = 104;
            this.splitContainer1.TabIndex = 0;
            // 
            // headerBox
            // 
            this.headerBox.BackgroundImage = global::MPAid.Properties.Resources.header;
            this.headerBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.headerBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerBox.Location = new System.Drawing.Point(0, 24);
            this.headerBox.Name = "headerBox";
            this.headerBox.Size = new System.Drawing.Size(552, 80);
            this.headerBox.TabIndex = 1;
            this.headerBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.userToolStripMenuItem,
            this.configToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(552, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem,
            this.voiceToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.signOutToolStripMenuItem});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.userToolStripMenuItem.Text = "User";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heritageMāoriToolStripMenuItem,
            this.modernMāoriToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // heritageMāoriToolStripMenuItem
            // 
            this.heritageMāoriToolStripMenuItem.CheckOnClick = true;
            this.heritageMāoriToolStripMenuItem.Name = "heritageMāoriToolStripMenuItem";
            this.heritageMāoriToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.heritageMāoriToolStripMenuItem.Text = "Heritage Māori";
            this.heritageMāoriToolStripMenuItem.Click += new System.EventHandler(this.heritageMāoriToolStripMenuItem_Click);
            // 
            // modernMāoriToolStripMenuItem
            // 
            this.modernMāoriToolStripMenuItem.CheckOnClick = true;
            this.modernMāoriToolStripMenuItem.Name = "modernMāoriToolStripMenuItem";
            this.modernMāoriToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.modernMāoriToolStripMenuItem.Text = "Modern Māori";
            this.modernMāoriToolStripMenuItem.Click += new System.EventHandler(this.modernMāoriToolStripMenuItem_Click);
            // 
            // voiceToolStripMenuItem
            // 
            this.voiceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.feminineToolStripMenuItem,
            this.masculineToolStripMenuItem});
            this.voiceToolStripMenuItem.Name = "voiceToolStripMenuItem";
            this.voiceToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.voiceToolStripMenuItem.Text = "Voice";
            // 
            // feminineToolStripMenuItem
            // 
            this.feminineToolStripMenuItem.CheckOnClick = true;
            this.feminineToolStripMenuItem.Name = "feminineToolStripMenuItem";
            this.feminineToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.feminineToolStripMenuItem.Text = "Feminine";
            this.feminineToolStripMenuItem.Click += new System.EventHandler(this.feminineToolStripMenuItem_Click);
            // 
            // masculineToolStripMenuItem
            // 
            this.masculineToolStripMenuItem.CheckOnClick = true;
            this.masculineToolStripMenuItem.Name = "masculineToolStripMenuItem";
            this.masculineToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.masculineToolStripMenuItem.Text = "Masculine";
            this.masculineToolStripMenuItem.Click += new System.EventHandler(this.masculineToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.signOutToolStripMenuItem.Text = "Sign Out";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.greetingLabel);
            this.splitContainer2.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(552, 224);
            this.splitContainer2.SplitterDistance = 94;
            this.splitContainer2.TabIndex = 0;
            // 
            // greetingLabel
            // 
            this.greetingLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.greetingLabel.AutoSize = true;
            this.greetingLabel.Location = new System.Drawing.Point(176, 32);
            this.greetingLabel.Name = "greetingLabel";
            this.greetingLabel.Size = new System.Drawing.Size(200, 31);
            this.greetingLabel.TabIndex = 0;
            this.greetingLabel.Text = "Kia Ora, User!";
            this.greetingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.learnButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.testButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.scanReportButton, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(552, 126);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // learnButton
            // 
            this.learnButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.learnButton.Location = new System.Drawing.Point(201, 9);
            this.learnButton.Name = "learnButton";
            this.learnButton.Size = new System.Drawing.Size(150, 23);
            this.learnButton.TabIndex = 0;
            this.learnButton.Text = "Learn";
            this.learnButton.UseVisualStyleBackColor = true;
            // 
            // testButton
            // 
            this.testButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.testButton.Location = new System.Drawing.Point(201, 51);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(150, 23);
            this.testButton.TabIndex = 1;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            // 
            // scanReportButton
            // 
            this.scanReportButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.scanReportButton.Location = new System.Drawing.Point(201, 93);
            this.scanReportButton.Name = "scanReportButton";
            this.scanReportButton.Size = new System.Drawing.Size(150, 23);
            this.scanReportButton.TabIndex = 2;
            this.scanReportButton.Text = "Scan Report";
            this.scanReportButton.UseVisualStyleBackColor = true;
            // 
            // MPAiSoundMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 332);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MPAiSoundMainMenu";
            this.Text = "MPAi Sound";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heritageMāoriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modernMāoriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feminineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masculineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label greetingLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button learnButton;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button scanReportButton;
        private System.Windows.Forms.PictureBox headerBox;
    }
}