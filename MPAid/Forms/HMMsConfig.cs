using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MPAid
{
    public partial class HMMsConfigForm : Form
    {
        public HMMsConfigForm()
        {
            InitializeComponent();
            InitUI();
        }

        private void InitUI()
        {
            customizedPath.Text = cPathInitial;
            customizedPath.ForeColor = Color.Gray;

            bool notCustomize = true;
            foreach (Control c in groupPresets.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rb = (RadioButton)c;
                    if (rb.Text.Equals(HMMsController.GetHMMsValue()))
                    {
                        rb.Checked = true;
                        notCustomize = false;
                    }                    
                }
            }
            if (notCustomize)
            {
                useCustomizedHMMs.Checked = true;
                customizedPath.Text = HMMsController.GetHMMsValue();
                customizedPath.ForeColor = Color.Black;
            }
            
        }

        public void SetWorkingFolder(string annieDir)
        {
            labelWorkingDir.Text = "Working Directory - " + annieDir;
        }

        public string GetHMMsValue()
        {
            if (useCustomizedHMMs.Checked && customizedPath.Text != null)
                return customizedPath.Text;

            foreach (Control c in groupPresets.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rb = (RadioButton)c;
                    if (rb.Checked)
                        return rb.Text;
                }
            }

            return null;
        }

        private string cPathInitial = "Specify the path here (according to the format left)";

        private void customizedPath_MouseHover(object sender, EventArgs e)
        {
            if (customizedPath.Text == cPathInitial)
            {
                customizedPath.Text = "";
                customizedPath.ForeColor = Color.Black;
                customizedPath.Focus();
            }
        }

        private void useCustomizedHMMs_CheckedChanged(object sender, EventArgs e)
        {
            groupPresets.Enabled = !useCustomizedHMMs.Checked;
        }

    }
}
