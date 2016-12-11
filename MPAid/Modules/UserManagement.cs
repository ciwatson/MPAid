using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MPAid
{
    /// <summary>
    /// Maintains details of all of the users of the system, the current user, and the administrator.
    /// </summary>
    public class UserManagement
    {
        private MPAiUser currentUser = null;
        private string userDirRoot = null;
        private string fileName = "AppSettings.dat";    // At present, this does not exist. 
        //Deprecated: Optimisation feature, commit logs suggest that it may cause errors, all references to it have been commented out.
        //private bool unchanged = true;
        private readonly string adminStr = "admin";

        private List<MPAiUser> allUsers;
        /// <summary>
        /// Constructor for the UserManagement class, restores current user's settings, all users, and creates an admin user if one doesn't already exist.
        /// </summary>
        /// <param name="root">The current MPAid root directory.</param>
        public UserManagement(string root)
        {
            userDirRoot = root + Path.DirectorySeparatorChar;
            allUsers = new List<MPAiUser>();
            ReadSettings();

            if (allUsers.Count == 0)            
                allUsers.Add(new MPAiUser(adminStr, adminStr));
        }
        /// <summary>
        /// Returns the users of the system.
        /// </summary>
        /// <returns>A list of all the MPAiUsers.</returns>
        public List<MPAiUser> GetAllUsers()
        {
            return allUsers;
        }
        /// <summary>
        /// Checks if a user already exists with the same username as the one input, and adds the user to the database if not.
        /// </summary>
        /// <param name="newUserName">The username of the new user.</param>
        /// <param name="newCode">The password of the new user.</param>
        /// <returns>True if the creation was successful, false if not.</returns>
        public bool CreateNewUser(string newUserName, string newCode)
        {
            //unchanged = false;

            IEnumerable<MPAiUser> searchUser =
                from user in allUsers
                where user.getName() == newUserName.ToLower()
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
        /// <summary>
        /// Checks whether the input user already exists in the system.
        /// </summary>
        /// <param name="candidate">The user to check, as an MAPiUser.</param>
        /// <returns>True if the user is in the system, false if not.</returns>
        public bool ContainUser(MPAiUser candidate)
        {
            foreach (MPAiUser item in allUsers)
                if (item.getName() == candidate.getName())
                    return true;

            return false;
        }
        /// <summary>
        /// Checks if a user already exists with the same username as the user input, and adds the user to the database if not.
        /// </summary>
        /// <param name="candidate">The user to add to the system, as an MPAiUser.</param>
        /// <returns>True if the creation was successful, false if not.</returns>
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
        /// <summary>
        /// Gets the current user of the system.
        /// </summary>
        /// <returns>The current user of the system as an MPAi object, if one exists. Null if not.</returns>
        public MPAiUser getCurrentUser()
        {
            if (currentUser != null)
                return currentUser;
            else
                return null;
        }
        /// <summary>
        /// Checks if the current user is the administrator.
        /// </summary>
        /// <returns>True if the current user is the administrator, false if not.</returns>
        public bool currentUserIsAdmin()
        {
            return (getCurrentUser().getName() == adminStr);
        }
        // Deprecated: AuthenticateUser now takes an MPAiUser object, which all valid users have.
        //public bool AuthenticateUser(string username, string code)
        //{
        //    foreach (MPAiUser user in allUsers)
        //        if (user.getName() == username)
        //            return user.codeCorrect(code);
        //    return false;
        //}

        /// <summary>
        /// Checks if the current user is a valid, existing user, and sets them to the current user. 
        /// </summary>
        /// <param name="tUser">The user to authenticate, as an MPAiUser object.</param>
        /// <returns>True if the user exists already, false otherwise.</returns>
        public bool AuthenticateUser(MPAiUser tUser)
        {
            currentUser = tUser;
            return (allUsers.Contains(tUser));
        }
        /// <summary>
        /// Changes the current user's password.
        /// </summary>
        /// <param name="userName">The username of the user to change, as a string.</param>
        /// <param name="newCode">The new password for the specified user, as a string.</param>
        public void ChangeUserCode(string userName, string newCode)
        {
            allUsers.Remove(currentUser);
            currentUser = new MPAiUser(userName, newCode);
            allUsers.Add(currentUser);
        }
        /// <summary>
        /// Removes the specified user from the system.
        /// </summary>
        /// <param name="userToRemove">The user to remove, as an MPAiUser object.</param>
        public void RemoveUser(MPAiUser userToRemove)
        {
            allUsers.Remove(userToRemove);
        }
        /// <summary>
        /// Returns a string representing the settings file on the user's computer.
        /// </summary>
        /// <returns>The path to the settings file, as a string.</returns>
        private string GetSettingFilePath()
        {
            return (userDirRoot + fileName);
        }
        /// <summary>
        /// Opens the settings file and populates the allUsers field with the data found there.
        /// Also restores the last user to access the system to current user status.
        /// </summary>
        public void ReadSettings()
        {
            try
            {
                if (File.Exists(GetSettingFilePath()))  // This should have an else clause indicating an error - there is currently no AppSetttings file in the system, however, so it simply skips this step.
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
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }
        /// <summary>
        /// Writes all users to the settings file, and creates it if it does not already exist.
        /// </summary>
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
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

    }
}
