using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPAid.NewForms
{
    public partial class MenuStrip : System.Windows.Forms.MenuStrip
    {
        public MenuStrip() : base()
        {
            InitializeComponent();
            checkAppropriateComponents();
        }

        public MenuStrip(IContainer container) : base()
        {
            container.Add(this);

            InitializeComponent();
            checkAppropriateComponents();
        }

        private void checkAppropriateComponents()
        {
            try
            {
                switch (UserManagement.CurrentUser.Voice)
                {
                    case Models.VoiceType.FEMININE_HERITAGE:
                        heritageMāoriToolStripMenuItem.Checked = true;
                        feminineToolStripMenuItem.Checked = true;
                        break;
                    case Models.VoiceType.FEMININE_MODERN:
                        modernMāoriToolStripMenuItem.Checked = true;
                        feminineToolStripMenuItem.Checked = true;
                        break;
                    case Models.VoiceType.MASCULINE_HERITAGE:
                        heritageMāoriToolStripMenuItem.Checked = true;
                        masculineToolStripMenuItem.Checked = true;
                        break;
                    case Models.VoiceType.MASCULINE_MODERN:
                        modernMāoriToolStripMenuItem.Checked = true;
                        masculineToolStripMenuItem.Checked = true;
                        break;
                }
            } catch (NullReferenceException e)
            {

            }
            
        }

        private void heritageMāoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            heritageMāoriToolStripMenuItem.Checked = true;
            modernMāoriToolStripMenuItem.Checked = false;
            UserManagement.CurrentUser.changeVoiceToHeritage();                                     // Change the current user variable...
            UserManagement.getUser(UserManagement.CurrentUser.getName()).changeVoiceToHeritage();   // and the current user in the list of users.
        }

        private void modernMāoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            heritageMāoriToolStripMenuItem.Checked = false;
            modernMāoriToolStripMenuItem.Checked = true;
            UserManagement.CurrentUser.changeVoiceToModern();                                     // Change the current user variable...
            UserManagement.getUser(UserManagement.CurrentUser.getName()).changeVoiceToModern();   // and the current user in the list of users.
        }

        private void feminineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            feminineToolStripMenuItem.Checked = true;
            masculineToolStripMenuItem.Checked = false;
            UserManagement.CurrentUser.changeVoiceToFeminine();                                     // Change the current user variable...
            UserManagement.getUser(UserManagement.CurrentUser.getName()).changeVoiceToFeminine();   // and the current user in the list of users.
        }

        private void masculineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            feminineToolStripMenuItem.Checked = false;
            masculineToolStripMenuItem.Checked = true;
            UserManagement.CurrentUser.changeVoiceToMasculine();                                     // Change the current user variable...
            UserManagement.getUser(UserManagement.CurrentUser.getName()).changeVoiceToMasculine();   // and the current user in the list of users.
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // There will always be only one login screen, and it will always be open if the program is running.
            Application.OpenForms.OfType<LoginScreen>().SingleOrDefault().Show();   
            ((MainFormInterface)Parent).closeThis();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordWindow changePswdForm = new ChangePasswordWindow();
            changePswdForm.ShowDialog(this);
        }
    }
}
