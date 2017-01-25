﻿namespace MPAi.Forms.MSGBox
{
    partial class FeedbackScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mailContentTextBox = new System.Windows.Forms.TextBox();
            this.customerEmailTextBox = new System.Windows.Forms.TextBox();
            this.mailSubjectTextBox = new System.Windows.Forms.TextBox();
            this.mailSendButton = new System.Windows.Forms.Button();
            this.mailCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Subject";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Content:";
            // 
            // mailContentTextBox
            // 
            this.mailContentTextBox.Location = new System.Drawing.Point(12, 110);
            this.mailContentTextBox.Multiline = true;
            this.mailContentTextBox.Name = "mailContentTextBox";
            this.mailContentTextBox.Size = new System.Drawing.Size(606, 237);
            this.mailContentTextBox.TabIndex = 3;
            // 
            // customerEmialTextBox
            // 
            this.customerEmailTextBox.Location = new System.Drawing.Point(72, 17);
            this.customerEmailTextBox.Name = "customerEmialTextBox";
            this.customerEmailTextBox.Size = new System.Drawing.Size(546, 20);
            this.customerEmailTextBox.TabIndex = 4;
            // 
            // mailSubjectTextBox
            // 
            this.mailSubjectTextBox.Location = new System.Drawing.Point(72, 54);
            this.mailSubjectTextBox.Name = "mailSubjectTextBox";
            this.mailSubjectTextBox.Size = new System.Drawing.Size(546, 20);
            this.mailSubjectTextBox.TabIndex = 5;
            // 
            // mailSendButton
            // 
            this.mailSendButton.Location = new System.Drawing.Point(543, 358);
            this.mailSendButton.Name = "mailSendButton";
            this.mailSendButton.Size = new System.Drawing.Size(75, 23);
            this.mailSendButton.TabIndex = 6;
            this.mailSendButton.Text = "Send";
            this.mailSendButton.UseVisualStyleBackColor = true;
            this.mailSendButton.Click += new System.EventHandler(this.mailSendButton_Click);
            // 
            // mailCancelButton
            // 
            this.mailCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.mailCancelButton.Location = new System.Drawing.Point(462, 358);
            this.mailCancelButton.Name = "mailCancelButton";
            this.mailCancelButton.Size = new System.Drawing.Size(75, 23);
            this.mailCancelButton.TabIndex = 7;
            this.mailCancelButton.Text = "Cancel";
            this.mailCancelButton.UseVisualStyleBackColor = true;
            this.mailCancelButton.Click += new System.EventHandler(this.mailCancelButton_Click);
            // 
            // FeedbackMSGBox
            // 
            this.AcceptButton = this.mailSendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.mailCancelButton;
            this.ClientSize = new System.Drawing.Size(630, 393);
            this.Controls.Add(this.mailCancelButton);
            this.Controls.Add(this.mailSendButton);
            this.Controls.Add(this.mailSubjectTextBox);
            this.Controls.Add(this.customerEmailTextBox);
            this.Controls.Add(this.mailContentTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FeedbackMSGBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FeedBack Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox mailContentTextBox;
        private System.Windows.Forms.TextBox customerEmailTextBox;
        private System.Windows.Forms.TextBox mailSubjectTextBox;
        private System.Windows.Forms.Button mailSendButton;
        private System.Windows.Forms.Button mailCancelButton;
    }
}