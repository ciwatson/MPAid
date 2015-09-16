using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MPAid
{
    class UserManagement
    {
        private MPAiUser currentUser = null;

        private string userDirRoot = null;
        private string fileName = "AppSettings.dat";

        public UserManagement(string root)
        {
            userDirRoot = root + Path.DirectorySeparatorChar;
        }
        
        public void CreateNewUser(string newUserName)
        {
            // not yet implemented
        }

        private string GetSettingFilePath()
        {
            return (userDirRoot + fileName);
        }

        public void WriteSettings()
        {
            using (BinaryWriter writer = new BinaryWriter(
                File.Open(GetSettingFilePath(), FileMode.Create)))
            {
                //int n = 10;
                //writer.Write(10);
                //for (int i = 0; i < n; i++)
                //{
                //    writer.Write(i + 55);
                //}
            }
        }

        public void ReadSettings()
        {

            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(
                    File.Open(GetSettingFilePath(), FileMode.Open)))
                {
                    int n = reader.ReadInt32();
                    for (int i = 0; i < n; i++)
                    {

                        Console.WriteLine(reader.ReadInt32());
                    }

                }

                Console.ReadLine();
            }
        }
    }
}
