namespace MPAid
{
    partial class HMMsConfigForm
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
            this.groupPresets = new System.Windows.Forms.GroupBox();
            this.hmms4 = new System.Windows.Forms.RadioButton();
            this.hmms2 = new System.Windows.Forms.RadioButton();
            this.hmms3 = new System.Windows.Forms.RadioButton();
            this.hmms1 = new System.Windows.Forms.RadioButton();
            this.labelWorkingDir = new System.Windows.Forms.TextBox();
            this.groupCustomize = new System.Windows.Forms.GroupBox();
            this.useCustomizedHMMs = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.customizedPath = new System.Windows.Forms.TextBox();
            this.groupPresets.SuspendLayout();
            this.groupCustomize.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPresets
            // 
            this.groupPresets.Controls.Add(this.hmms4);
            this.groupPresets.Controls.Add(this.hmms2);
            this.groupPresets.Controls.Add(this.hmms3);
            this.groupPresets.Controls.Add(this.hmms1);
            this.groupPresets.Location = new System.Drawing.Point(12, 39);
            this.groupPresets.Name = "groupPresets";
            this.groupPresets.Size = new System.Drawing.Size(280, 150);
            this.groupPresets.TabIndex = 1;
            this.groupPresets.TabStop = false;
            this.groupPresets.Text = "Presets";
            // 
            // hmms4
            // 
            this.hmms4.AutoSize = true;
            this.hmms4.Location = new System.Drawing.Point(20, 103);
            this.hmms4.Name = "hmms4";
            this.hmms4.Size = new System.Drawing.Size(222, 19);
            this.hmms4.TabIndex = 3;
            this.hmms4.Text = "HMMsAnnie/HMMsOriginal/hmm15";
            this.hmms4.UseVisualStyleBackColor = true;
            // 
            // hmms2
            // 
            this.hmms2.AutoSize = true;
            this.hmms2.Location = new System.Drawing.Point(20, 53);
            this.hmms2.Name = "hmms2";
            this.hmms2.Size = new System.Drawing.Size(240, 19);
            this.hmms2.TabIndex = 2;
            this.hmms2.Text = "HMMsAnnie/HMMsOldFemale/hmm15";
            this.hmms2.UseVisualStyleBackColor = true;
            // 
            // hmms3
            // 
            this.hmms3.AutoSize = true;
            this.hmms3.Location = new System.Drawing.Point(20, 78);
            this.hmms3.Name = "hmms3";
            this.hmms3.Size = new System.Drawing.Size(226, 19);
            this.hmms3.TabIndex = 1;
            this.hmms3.Text = "HMMsAnnie/HMMsOldMale/hmm15";
            this.hmms3.UseVisualStyleBackColor = true;
            // 
            // hmms1
            // 
            this.hmms1.AutoSize = true;
            this.hmms1.Checked = true;
            this.hmms1.Location = new System.Drawing.Point(20, 28);
            this.hmms1.Name = "hmms1";
            this.hmms1.Size = new System.Drawing.Size(217, 19);
            this.hmms1.TabIndex = 0;
            this.hmms1.TabStop = true;
            this.hmms1.Text = "HMMsAnnie/HMMsFullSet/hmm15";
            this.hmms1.UseVisualStyleBackColor = true;
            // 
            // labelWorkingDir
            // 
            this.labelWorkingDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWorkingDir.Location = new System.Drawing.Point(12, 12);
            this.labelWorkingDir.Name = "labelWorkingDir";
            this.labelWorkingDir.ReadOnly = true;
            this.labelWorkingDir.Size = new System.Drawing.Size(640, 21);
            this.labelWorkingDir.TabIndex = 2;
            // 
            // groupCustomize
            // 
            this.groupCustomize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCustomize.Controls.Add(this.useCustomizedHMMs);
            this.groupCustomize.Controls.Add(this.label1);
            this.groupCustomize.Controls.Add(this.customizedPath);
            this.groupCustomize.Location = new System.Drawing.Point(298, 39);
            this.groupCustomize.Name = "groupCustomize";
            this.groupCustomize.Size = new System.Drawing.Size(354, 150);
            this.groupCustomize.TabIndex = 3;
            this.groupCustomize.TabStop = false;
            this.groupCustomize.Text = "Customize";
            // 
            // useCustomizedHMMs
            // 
            this.useCustomizedHMMs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.useCustomizedHMMs.Location = new System.Drawing.Point(12, 32);
            this.useCustomizedHMMs.Name = "useCustomizedHMMs";
            this.useCustomizedHMMs.Size = new System.Drawing.Size(330, 30);
            this.useCustomizedHMMs.TabIndex = 2;
            this.useCustomizedHMMs.Text = "Use customized HMMs";
            this.useCustomizedHMMs.UseVisualStyleBackColor = true;
            this.useCustomizedHMMs.CheckedChanged += new System.EventHandler(this.useCustomizedHMMs_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Specify the path here (according to the format left)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customizedPath
            // 
            this.customizedPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customizedPath.Location = new System.Drawing.Point(12, 98);
            this.customizedPath.Name = "customizedPath";
            this.customizedPath.Size = new System.Drawing.Size(330, 21);
            this.customizedPath.TabIndex = 0;
            this.customizedPath.MouseHover += new System.EventHandler(this.customizedPath_MouseHover);
            // 
            // HMMsConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(664, 201);
            this.Controls.Add(this.groupCustomize);
            this.Controls.Add(this.labelWorkingDir);
            this.Controls.Add(this.groupPresets);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(680, 240);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(680, 240);
            this.Name = "HMMsConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HMMs Configuration";
            this.groupPresets.ResumeLayout(false);
            this.groupPresets.PerformLayout();
            this.groupCustomize.ResumeLayout(false);
            this.groupCustomize.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupPresets;
        private System.Windows.Forms.RadioButton hmms4;
        private System.Windows.Forms.RadioButton hmms2;
        private System.Windows.Forms.RadioButton hmms3;
        private System.Windows.Forms.RadioButton hmms1;
        private System.Windows.Forms.TextBox labelWorkingDir;
        private System.Windows.Forms.GroupBox groupCustomize;
        private System.Windows.Forms.CheckBox useCustomizedHMMs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox customizedPath;
    }
}