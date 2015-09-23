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
    public partial class AdminConsole : Form
    {
        private UserManagement allUsers;
        private MPAiUser currentUser;

        public AdminConsole(UserManagement users)
        {
            InitializeComponent();

            SetUserManagement(users);
        }
        
        private void SetUserManagement(UserManagement users)
        {
            allUsers = users;
            currentUser = allUsers.getCurrentUser();
        }


    }
}
