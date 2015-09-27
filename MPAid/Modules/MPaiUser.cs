using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace MPAid
{
    public class MPAiUser
    {
        private string userName;
        private string passWord;
        private readonly string adminStr = "admin";

        [DisplayName("UserName")]
        public string UserID
        {
            get { return userName; }
            set
            {
                // prevent the user from changing the name of the admin
                if (userName != adminStr)
                    userName = value;
            }
        }

        [DisplayName("Password")]
        public string UserPswd
        {
            get { return passWord; }
            set { passWord = value; }
        }

        [DisplayName("IsAdministrator")]
        public bool IsAdmin
        {
            get { return isAdmin(); }
        }

        public MPAiUser(string name, string code)
        {
            userName = name;
            passWord = code;
        }

        public bool codeCorrect(string code)
        {
            return (code.Equals(passWord));
        }

        // Only when username == admin, then the user is an admin
        public bool isAdmin()
        {
            return (getName() == adminStr);
        }

        public string getName()
        {
            return userName.ToLower();
        }

        public string getName(bool formal)
        {
            return userName;
        }

        public string getCode()
        {
            return passWord;
        }

        public override bool Equals(System.Object obj)
        {
            if (obj is MPAiUser)
            {
                MPAiUser otherUser = (MPAiUser)obj;
                if (userName == null || passWord == null)
                    return false;
                return ((userName.ToLower() == otherUser.getName().ToLower())
                    && (passWord == otherUser.getCode()));
            }
            else
                return false;
        }

        public override string ToString()
        {
            return userName;
        }
    }
}
