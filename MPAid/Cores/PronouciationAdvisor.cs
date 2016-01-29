using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAid.Cores
{
    class PronouciationAdvisor
    {
        public string Advise(string recording, string target, string recognized)
        {
            string advice = string.Format(@"Your speech {0} was recognized as {1}!{2}", recording, recognized, Environment.NewLine);
            if(!recognized.Equals(target) && !string.IsNullOrEmpty(target))
            {
                advice += CompareWords(target, recognized);
            }
            return advice;
        } 

        private string CompareWords(string target, string recognized)
        {
            string advice = string.Empty;
            if (lexicon.ReadLexicon())
            {
                string targetPronouciation = lexicon.dictionary[target], recognizedPronouciation = lexicon.dictionary[recognized];
                string[] lines =
                {
                    @"Compared with the target word {0},",
                    @"which should be pronouced as {1},",
                    @"It sounds linke you were saying {2},",
                    @"which was pronouced like {3}!"
                };
                advice += string.Format(string.Join(Environment.NewLine, lines), target, targetPronouciation, recognized, recognizedPronouciation);

                Dictionary<string, string> mismatched = AnalyzePronouciation(targetPronouciation, recognizedPronouciation);
                if(mismatched.Count > 0)
                {
                    advice += string.Format(@"You are mis-pronoucing:{0}", Environment.NewLine);
                    foreach(KeyValuePair<string, string> pair in mismatched)
                    {
                        advice += string.Format(@"{0} to {1}{2}", pair.Key, pair.Value, Environment.NewLine);
                    }
                }
            }
            return advice;
        }

        private Dictionary<string, string> AnalyzePronouciation(string target, string recognized)
        {
            Dictionary<string, string> mismatched = new Dictionary<string, string>();
            string[] targetPhones = target.Split(' ');
            string[] recognizedPhones = recognized.Split(' ');
            for(int i = 0; i < Math.Min(targetPhones.Length, recognizedPhones.Length); i++)
            {
                mismatched.Add(targetPhones[i], recognizedPhones[i]);
            }
            return mismatched;
        }

        private LexiconReader lexicon = new LexiconReader();
    }

    class LexiconReader
    {
        public Dictionary<string, string> dictionary = new Dictionary<string, string>();
        public bool ReadLexicon()
        {
            string filepath = Path.Combine(SystemConfigration.configs.HTKFolderAddr.FolderAddr, @"Dictionaries", @"lexicon.txt");
            if (File.Exists(filepath))
            {
                dictionary.Clear();
                using (FileStream fs = new FileStream(filepath, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string item;
                        while((item = sr.ReadLine()) != null)
                        {
                            if (string.IsNullOrEmpty(item)) continue;
                            string word = item.Substring(0, item.IndexOf('[')).Trim(' ');
                            string pronouciation = item.Substring(item.IndexOf(']') + 1).Trim(' ');
                            if (!string.IsNullOrEmpty(word))
                            {
                                dictionary.Add(word, pronouciation);
                            }
                        }
                    }
                }
                return true;
            }
            return false;
        }
    }
}
