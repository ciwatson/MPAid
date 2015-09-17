using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MPAid
{
    public class MPAiUser
    {
        private string userName;
        private string passWord;

        public MPAiUser(string name, string code)
        {
            userName = name;
            passWord = code;
        }

        public bool codeCorrect(string code)
        {
            return (code.Equals(passWord));
        }

        public string getName()
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
