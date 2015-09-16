using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MPAid
{
    public class UserManagement
    {
        private MPAiUser currentUser = null;

        private string userDirRoot = null;
        private string fileName = "AppSettings.dat";
        private bool unchanged = true;

        private List<MPAiUser> allUsers;

        public UserManagement(string root)
        {
            userDirRoot = root + Path.DirectorySeparatorChar;
            allUsers = new List<MPAiUser>();
            ReadSettings();
        }

        public bool CreateNewUser(string newUserName, string newCode)
        {
            unchanged = false;

            IEnumerable<MPAiUser> searchUser =
                from user in allUsers
                where user.getName() == newUserName
                select user;

            if (searchUser.Count() == 0)
            {
                allUsers.Add(new MPAiUser(newUserName, newCode));
                return true;
            }
            else
            { 
                return false;
            }
        }

        public bool AuthenticateSuccess(string username, string code)
        {
            foreach (MPAiUser user in allUsers)
                if (user.getName() == username)
                    return user.codeCorrect(code);
            return false;
        }

        public void ChangeUserCode(string userName, string newCode)
        {

        }

        public void RemoveUserByName(string userName)
        {

        }

        private string GetSettingFilePath()
        {
            return (userDirRoot + fileName);
        }

        public void ReadSettings()
        {
            try
            {
                if (File.Exists(GetSettingFilePath()))
                {
                    using (BinaryReader reader = new BinaryReader(
                        File.Open(GetSettingFilePath(), FileMode.Open)))
                    {
                        int n = reader.ReadInt32();
                        for (int i = 0; i < n; i++)
                            allUsers.Add(new MPAiUser(reader.ReadString(), reader.ReadString()));
                    }
                }
            }
            catch (Exception) { }
        }

        public void WriteSettings()
        {
            if (unchanged)
                return;

            int n = allUsers.Count;
            if (n == 0)
                return;

            try
            {
                using (BinaryWriter writer = new BinaryWriter(
                    File.Open(GetSettingFilePath(), FileMode.Create)))
                {
                    writer.Write(n);
                    foreach (MPAiUser user in allUsers)
                    {
                        writer.Write(user.getName());
                        writer.Write(user.getCode());
                    }
                }
            }
            catch (Exception) { }
        }

    }
}
