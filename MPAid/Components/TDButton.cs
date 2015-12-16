using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MPAid
{
    class TDButton : Button
    {
        public Image ImageNormal;
        public Image ImageHighlight;
        public Image ImagePressed;

        public TDButton()
        {
            this.MouseDown += TDButton_MouseDown;
            this.MouseUp += TDButton_MouseUp;
            this.MouseEnter += TDButton_MouseEnter;
            this.MouseLeave += TDButton_MouseLeave;
        }

        void TDButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = ImageNormal;
        }

        void TDButton_MouseEnter(object sender, EventArgs e)
        {
            this.BackgroundImage = ImageHighlight;
        }

        void TDButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = ImageNormal;
        }

        private void TDButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = ImagePressed;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TDButton
            // 
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResumeLayout(false);

        }

    }
}
