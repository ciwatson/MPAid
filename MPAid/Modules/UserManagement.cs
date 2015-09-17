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
        //private bool unchanged = true;

        private List<MPAiUser> allUsers;

        public UserManagement(string root)
        {
            userDirRoot = root + Path.DirectorySeparatorChar;
            allUsers = new List<MPAiUser>() { new MPAiUser("admin", "admin") };
            ReadSettings();
        }

        public bool CreateNewUser(string newUserName, string newCode)
        {
            //unchanged = false;

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

        public bool ContainUser(MPAiUser candidate)
        {
            foreach (MPAiUser item in allUsers)
            {
                if (item.getName() == candidate.getName())
                    return true;
            }
            return false;
        }

        public bool CreateNewUser(MPAiUser candidate)
        {
            //unchanged = false;

            if (allUsers.Contains(candidate))
                return false;
            else
            {
                allUsers.Add(candidate);
                return true;
            }
        }

        public MPAiUser getLastUser()
        {
            if (currentUser != null)
                return currentUser;
            else
                return null;
        }

        //public bool AuthenticateUser(string username, string code)
        //{
        //    foreach (MPAiUser user in allUsers)
        //        if (user.getName() == username)
        //            return user.codeCorrect(code);
        //    return false;
        //}

        public bool AuthenticateUser(MPAiUser tUser)
        {
            currentUser = tUser;
            return (allUsers.Contains(tUser));
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

                        // restore the last used user
                        string name = reader.ReadString();
                        string code = reader.ReadString();
                        currentUser = new MPAiUser(name, code);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public void WriteSettings()
        {
            //if (unchanged)
            //    return;

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

                    // store the last used user
                    writer.Write(currentUser.getName());
                    writer.Write(currentUser.getCode());
                }
            }
            catch (Exception ex)
            {
                
            }
        }

    }
}
