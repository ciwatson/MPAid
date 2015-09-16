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
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            buttonSignUp.ImageNormal = Properties.Resources.ButtonYellow_0;
            buttonSignUp.ImageHighlight = Properties.Resources.ButtonYellow_1;
            buttonSignUp.ImagePressed = Properties.Resources.ButtonYellow_2;

            buttonLogin.ImageNormal = Properties.Resources.ButtonGreen_0;
            buttonLogin.ImageHighlight = Properties.Resources.ButtonGreen_1;
            buttonLogin.ImagePressed = Properties.Resources.ButtonGreen_2;
        }
    }
}
