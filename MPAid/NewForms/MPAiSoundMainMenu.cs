using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPAid.NewForms
{
    public partial class MPAiSoundMainMenu : Form
    {
        public MPAiSoundMainMenu()
        {
            InitializeComponent();

            string name = UserManagement.getCurrentUser().getName();
            if (name == null)
            {
                greetingLabel.Text = "Kia Ora, User!";
            }
            else
            {
                greetingLabel.Text = "Kia Ora, " + name + "!";
            }
        }
    }
}
