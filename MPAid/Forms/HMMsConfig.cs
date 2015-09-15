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
        }

        public string GetValue()
        {
            return (textBox1.Text);
        }

        private void HMMsConfigForm_Load(object sender, EventArgs e)
        {

        }
    
    }
}
