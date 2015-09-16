using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MPAid
{
    class MPAiUser
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
    }
}
