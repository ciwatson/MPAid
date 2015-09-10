using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace MPAid
{
    class ResManager
    {
        private List<MaoriObj> Vowels;
        private List<MaoriObj> Words;
        private WordMapper myDictionary = new WordMapper();

        public ResManager()
        {
            BuildVowelList();
            BuildWordList();

            //This method must happen AFTER BuildVowelList();
            BuildPictureIndex();
        }

        private void BuildPictureIndex()
        {
            foreach (MaoriObj m in Vowels)
            {
                string imagePath = string.Format("{0}{1}.jpg", GetImageDir(), m.Name);
                if (File.Exists(imagePath))
                    m.DefaultImage = Image.FromFile(imagePath);

                //If there are animations for the vowel
                string animationDir = string.Format("{0}{1}", GetImageDir(), m.Name);
                if (Directory.Exists(animationDir))
                {
                    try
                    {
                        m.AnimationImages = new ImageList() { ColorDepth = ColorDepth.Depth16Bit };
                        string[] imageFileNames = Directory.GetFiles(animationDir);
                        m.AnimationImages.ImageSize = Image.FromFile(imageFileNames[0]).Size;
                        foreach (string imageFile in imageFileNames)
                            m.AnimationImages.Images.Add(Image.FromFile(imageFile));
                    }
                    catch { }
                }
            }
        }

        private void BuildVowelList()
        {
            Vowels = new List<MaoriObj>();

            Vowels.Add(new MaoriObj()
            {
                Name = "a",
                SoundFilePath = GetSoundDir() + "a.wav"
            });

            Vowels.Add(new MaoriObj()
            {
                Name = "ae",
                SoundFilePath = GetSoundDir() + "ae.wav"
            });

            Vowels.Add(new MaoriObj()
            {
                Name = "ai",
                SoundFilePath = GetSoundDir() + "ai.wav"
            });

            Vowels.Add(new MaoriObj()
            {
                Name = "ao",
                SoundFilePath = GetSoundDir() + "ao.wav"
            });

            Vowels.Add(new MaoriObj()
            {
                Name = "au",
                SoundFilePath = GetSoundDir() + "au.wav"
            });

            Vowels.Add(new MaoriObj()
            {
                Name = "e",
                SoundFilePath = GetSoundDir() + "e.wav"
            });

            Vowels.Add(new MaoriObj()
            {
                Name = "i",
                SoundFilePath = GetSoundDir() + "i.wav"
            });

            Vowels.Add(new MaoriObj()
            {
                Name = "o",
                SoundFilePath = GetSoundDir() + "o.wav"
            });

            Vowels.Add(new MaoriObj()
            {
                Name = "ou",
                SoundFilePath = GetSoundDir() + "ou.wav"
            });

            Vowels.Add(new MaoriObj()
            {
                Name = "u",
                SoundFilePath = GetSoundDir() + "u.wav"
            });
        }

        private void BuildWordList()
        {
            List<int> Indexes = new List<int>()
            {
                3,  15, 25, 24, 4,  14,
                16, 12, 11, 13, 26, 30,
                27, 28, 19, 20, 21, 10,
                9,  5,  6,  7,  8,  17,
                18, 22, 23, 2,  1,  29
            };

            Words = new List<MaoriObj>();
            foreach (int i in Indexes)
                Words.Add(new MaoriObj()
                {
                    Name = myDictionary.GetNameByIndex(i),
                    WordSoundId = i
                });
        }

        public List<MaoriObj> GetVowelList()
        {
            return Vowels;
        }

        public List<MaoriObj> GetWordList()
        {
            return Words;
        }

        public string GetFormantPlotExeName()
        {
            const string OldName = @"MPAi.exe";
            const string NewName = @"Runner.exe";
            if (File.Exists(NewName))
                return (NewName);
            if (File.Exists(OldName))
                return (OldName);
            return (NewName);
        }

        public string GetFormantPlotTitle()
        {
            return (@"Formant Plot");
        }

        private string GetWorkingDir()
        {
            return Directory.GetCurrentDirectory();
        }

        private string GetWorkingDirParent()
        {
            DirectoryInfo parent = Directory.GetParent(GetWorkingDir());
            if (parent != null)
                return parent.FullName;
            else
                return GetWorkingDir();
        }

        public string GetSoundDir()
        {
            return GetWorkingDirParent() + "\\sounds\\";
        }

        private string GetImageDir()
        {
            return GetWorkingDirParent() + "\\images\\";
        }

        public string GetAnnieDir()
        {
            return GetWorkingDirParent() + "\\Annie\\";
        }

        private List<string> GetRandomWordSoundList(string Dir, int Gender, int SoundId)
        {
            List<string> result = new List<string>();
            FileMapper files = new FileMapper(Gender, SoundId);

            foreach (string item in files.GetAllFileNames())
            {
                string proposedPath = Dir + item;
                if (File.Exists(proposedPath))
                    result.Add(proposedPath);
            }

            return result;
        }

        public string GetWordSound(int Gender, int SoundId)
        {
            return (GetRandomWordSoundList(GetSoundDir(), Gender, SoundId)[0]);
        }

        public string GetWordSound(int Gender, int SoundId, bool Random)
        {
            List<string> soundList = GetRandomWordSoundList(GetSoundDir(), Gender, SoundId);
            if (soundList.Count == 0)
                return null;
            if (Random) { 
                return (soundList[mathLib.RndInt(0, soundList.Count - 1)]);
            }
            else
                return (soundList[0]);
        }

        public List<string> GetWordSoundList(int Gender, int SoundId)
        {
            return (GetRandomWordSoundList(GetSoundDir(), Gender, SoundId));
        }

        public void PlaySound(string SoundFilePath, bool Sync)
        {
            try
            {
                SoundPlayer soundPlayer = new SoundPlayer();
                soundPlayer.SoundLocation = SoundFilePath;
                if (!Sync)
                    soundPlayer.Play();
                else
                    soundPlayer.PlaySync();
            }
            catch { }
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

        public string GetUserTempPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MPAid";
        }

        ///<summary>
        ///This method copies a file from sourcePath to destPath,
        ///ALSO it checks the target directory before copying
        ///</summary>
        public void SuperCopy(string sourceFileName, string destFileName, bool overwrite)
        {
            try
            {
                string targetDir = Path.GetDirectoryName(destFileName);
                if (!Directory.Exists(targetDir))
                    Directory.CreateDirectory(targetDir);
                File.Copy(sourceFileName, destFileName, overwrite);
            }
            catch { }
        }

    }
}
