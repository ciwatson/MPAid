using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPAid
{
    class FileMapper
    {
        private string prefix, middle, suffix, uniformFormat = "{0}{1}M_{2}.wav";
        private int upperLimit = 0, lowerLimit = 0;

        public FileMapper()
        {

        }

        public FileMapper(int Gender, int SoundId)
        {
            suffix = SoundId.ToString("D2");

            switch (Gender)
            {
                case 0:
                    prefix = "R0";
                    lowerLimit = 1;
                    upperLimit = 8;
                    break;
                case 1:
                    prefix = "K0";
                    lowerLimit = 4;
                    upperLimit = 10;
                    break;
                case 2:
                    prefix = "L1Y";
                    lowerLimit = 1;
                    upperLimit = 5;
                    break;
                case 3:
                    prefix = "L1H";
                    lowerLimit = 1;
                    upperLimit = 5;
                    break;
                default:
                    break;
            }
        }

        public string GetWordSoundName(int index)
        {
            middle = index.ToString("D2");
            return (string.Format(uniformFormat, prefix, middle, suffix));
        }

        public List<string> GetAllFileNames()
        {
            List<string> result = new List<string>();
            for (int i = lowerLimit; i <= upperLimit; i++)            
                result.Add(GetWordSoundName(i));
            return result;
        }

        public string GetUserTempPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MPAid";
        }

    }
}
