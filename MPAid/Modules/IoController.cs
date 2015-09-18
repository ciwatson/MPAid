using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace MPAid
{
    public class IoController
    {

        public string GetAppDataDir()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MPAid";
        }

        public string GetAppDataDir(MPAiUser user)
        {
            return (GetAppDataDir() + Path.DirectorySeparatorChar + user.getName());
        }

        public void ShowInBrowser(string htmlPath)
        {
            Process browser = new Process();
            browser.StartInfo.FileName = htmlPath;
            browser.Start();
        }

        public void ShowInNotepad(string FilePath)
        {
            Process explorer = new Process();
            explorer.StartInfo.FileName = "notepad";
            explorer.StartInfo.Arguments = FilePath;
            explorer.Start();
        }

        public void ShowInExplorer(string FilePath)
        {
            Process explorer = new Process();
            explorer.StartInfo.FileName = "explorer";
            explorer.StartInfo.Arguments = FilePath;
            explorer.Start();
        }

    }
}
