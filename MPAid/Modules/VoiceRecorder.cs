using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MPAid
{
    class VoiceRecorder
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
        private string _outputFolderName = null, _fileName = null;
        private string _fullWavFilePath = null;
        private int PathSource = 0;

        public VoiceRecorder(string OutputFolderName, string FileName)
        {
            PathSource = 1;
            _outputFolderName = OutputFolderName;
            _fileName = FileName;

            CheckAndCreateDir();
        }

        public VoiceRecorder(string FullWavFilePath)
        {
            PathSource = 0;
            _fullWavFilePath = FullWavFilePath;

            CheckAndCreateDir();
        }

        private string GetFullPath()
        {
            if (PathSource == 1)
                return (_outputFolderName + _fileName + ".wav");
            else
                return (_fullWavFilePath);
        }

        private void CheckAndCreateDir()
        {
            string targetDir = Path.GetDirectoryName(GetFullPath());
            if (!Directory.Exists(targetDir))
                try
                {
                    Directory.CreateDirectory(targetDir);
                }
                catch { }
        }

        public void Start()
        {
            mciSendString("open new Category waveaudio Alias recsound", "", 0, 0);
            mciSendString("record recsound", "", 0, 0);
        }

        public string Quoted(string source)
        {
            return string.Format("\"{0}\"", source);
        }

        public void StopAndSave()
        {
            mciSendString(@"save recsound " + Quoted(GetFullPath()), "", 0, 0);
            mciSendString("close recsound ", "", 0, 0);
        }
    }
}
