using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPAid
{
    class UserManager
    {
        private string userDirRoot = null;
        private string currentUser = null;
        
        public UserManager(string root)
        {
            userDirRoot = root;
        }
        
        public void CreateNewUser(string newUserName)
        {
            // not yet implemented
        }
        
    }
}
