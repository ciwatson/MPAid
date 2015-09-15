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
            this.groupBoxPresets = new System.Windows.Forms.GroupBox();
            this.hmms4 = new System.Windows.Forms.RadioButton();
            this.hmms2 = new System.Windows.Forms.RadioButton();
            this.hmms3 = new System.Windows.Forms.RadioButton();
            this.hmms1 = new System.Windows.Forms.RadioButton();
            this.labelWorkingDir = new System.Windows.Forms.TextBox();
            this.groupBoxCustomize = new System.Windows.Forms.GroupBox();
            this.customizedPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.useCustomizedHMMs = new System.Windows.Forms.CheckBox();
            this.groupBoxPresets.SuspendLayout();
            this.groupBoxCustomize.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPresets
            // 
            this.groupBoxPresets.Controls.Add(this.hmms4);
            this.groupBoxPresets.Controls.Add(this.hmms2);
            this.groupBoxPresets.Controls.Add(this.hmms3);
            this.groupBoxPresets.Controls.Add(this.hmms1);
            this.groupBoxPresets.Location = new System.Drawing.Point(12, 39);
            this.groupBoxPresets.Name = "groupBoxPresets";
            this.groupBoxPresets.Size = new System.Drawing.Size(250, 150);
            this.groupBoxPresets.TabIndex = 1;
            this.groupBoxPresets.TabStop = false;
            this.groupBoxPresets.Text = "Presets";
            // 
            // hmms4
            // 
            this.hmms4.AutoSize = true;
            this.hmms4.Location = new System.Drawing.Point(28, 103);
            this.hmms4.Name = "hmms4";
            this.hmms4.Size = new System.Drawing.Size(176, 19);
            this.hmms4.TabIndex = 3;
            this.hmms4.TabStop = true;
            this.hmms4.Text = "HMMsAnnie/HMMsOriginal";
            this.hmms4.UseVisualStyleBackColor = true;
            // 
            // hmms2
            // 
            this.hmms2.AutoSize = true;
            this.hmms2.Location = new System.Drawing.Point(28, 53);
            this.hmms2.Name = "hmms2";
            this.hmms2.Size = new System.Drawing.Size(194, 19);
            this.hmms2.TabIndex = 2;
            this.hmms2.TabStop = true;
            this.hmms2.Text = "HMMsAnnie/HMMsOldFemale";
            this.hmms2.UseVisualStyleBackColor = true;
            // 
            // hmms3
            // 
            this.hmms3.AutoSize = true;
            this.hmms3.Location = new System.Drawing.Point(28, 78);
            this.hmms3.Name = "hmms3";
            this.hmms3.Size = new System.Drawing.Size(180, 19);
            this.hmms3.TabIndex = 1;
            this.hmms3.TabStop = true;
            this.hmms3.Text = "HMMsAnnie/HMMsOldMale";
            this.hmms3.UseVisualStyleBackColor = true;
            // 
            // hmms1
            // 
            this.hmms1.AutoSize = true;
            this.hmms1.Location = new System.Drawing.Point(28, 28);
            this.hmms1.Name = "hmms1";
            this.hmms1.Size = new System.Drawing.Size(171, 19);
            this.hmms1.TabIndex = 0;
            this.hmms1.TabStop = true;
            this.hmms1.Text = "HMMsAnnie/HMMsFullSet";
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
            // groupBoxCustomize
            // 
            this.groupBoxCustomize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCustomize.Controls.Add(this.useCustomizedHMMs);
            this.groupBoxCustomize.Controls.Add(this.label1);
            this.groupBoxCustomize.Controls.Add(this.customizedPath);
            this.groupBoxCustomize.Location = new System.Drawing.Point(268, 39);
            this.groupBoxCustomize.Name = "groupBoxCustomize";
            this.groupBoxCustomize.Size = new System.Drawing.Size(384, 150);
            this.groupBoxCustomize.TabIndex = 3;
            this.groupBoxCustomize.TabStop = false;
            this.groupBoxCustomize.Text = "Customize";
            // 
            // customizedPath
            // 
            this.customizedPath.Location = new System.Drawing.Point(12, 98);
            this.customizedPath.Name = "customizedPath";
            this.customizedPath.Size = new System.Drawing.Size(360, 21);
            this.customizedPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Specify the path here (according to the format left)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // useCustomizedHMMs
            // 
            this.useCustomizedHMMs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.useCustomizedHMMs.Location = new System.Drawing.Point(12, 32);
            this.useCustomizedHMMs.Name = "useCustomizedHMMs";
            this.useCustomizedHMMs.Size = new System.Drawing.Size(360, 30);
            this.useCustomizedHMMs.TabIndex = 2;
            this.useCustomizedHMMs.Text = "Use customized HMMs set";
            this.useCustomizedHMMs.UseVisualStyleBackColor = true;
            // 
            // HMMsConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(664, 201);
            this.Controls.Add(this.groupBoxCustomize);
            this.Controls.Add(this.labelWorkingDir);
            this.Controls.Add(this.groupBoxPresets);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(680, 240);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(680, 240);
            this.Name = "HMMsConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HMMs Configuration";
            this.groupBoxPresets.ResumeLayout(false);
            this.groupBoxPresets.PerformLayout();
            this.groupBoxCustomize.ResumeLayout(false);
            this.groupBoxCustomize.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPresets;
        private System.Windows.Forms.RadioButton hmms4;
        private System.Windows.Forms.RadioButton hmms2;
        private System.Windows.Forms.RadioButton hmms3;
        private System.Windows.Forms.RadioButton hmms1;
        private System.Windows.Forms.TextBox labelWorkingDir;
        private System.Windows.Forms.GroupBox groupBoxCustomize;
        private System.Windows.Forms.CheckBox useCustomizedHMMs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox customizedPath;
    }
}