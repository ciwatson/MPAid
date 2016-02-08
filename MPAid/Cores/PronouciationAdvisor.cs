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
            string advice = "Errors in lexicon.txt!";
            if (lexicon.ReadLexicon())
            {
                string recognizedPronouciation = lexicon.dictionary[recognized];
                advice = string.Format(@"Your recording '{0}' is analyzed as '{1}', having pronouciation '{2}'.{3}{4}", recording, recognized, recognizedPronouciation, Environment.NewLine, Environment.NewLine);
                if (!recognized.Equals(target) && !string.IsNullOrEmpty(target))
                {
                    advice += CompareWords(target, recognized);
                }
            }
            return advice;
        }

        private string CompareWords(string target, string recognized)
        {
            string advice = string.Empty;
            string targetPronouciation = lexicon.dictionary[target];
            advice += string.Format(@"However, compared to the target word '{0}', whose pronouciation is '{1}',{2}{3}", target, targetPronouciation, Environment.NewLine, Environment.NewLine);

            Dictionary<string, string> mismatched = AnalyzePronouciation(targetPronouciation, lexicon.dictionary[recognized]);
            if (mismatched.Count > 0)
            {
                advice += string.Format(@"It sounds that you are mis-pronoucing:{0}", Environment.NewLine);
                foreach (KeyValuePair<string, string> pair in mismatched)
                {
                    advice += string.Format(@"{0} to {1}{2}", pair.Key, pair.Value, Environment.NewLine);
                }
            }
            return advice;
        }

        private Dictionary<string, string> AnalyzePronouciation(string target, string recognized)
        {
            Dictionary<string, string> mismatched = new Dictionary<string, string>();
            string[] targetPhones = target.Split(' ');
            string[] recognizedPhones = recognized.Split(' ');
            for (int i = 0; i < Math.Min(targetPhones.Length, recognizedPhones.Length); i++)
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
            try
            {
                string filepath = Path.Combine(Properties.Settings.Default.HTKFolder, @"Dictionaries", @"lexicon.txt");
                if (File.Exists(filepath))
                {
                    dictionary.Clear();
                    using (FileStream fs = new FileStream(filepath, FileMode.Open))
                    {
                        using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                        {

                            string item;
                            while ((item = sr.ReadLine()) != null)
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
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
            return false;
        }
    }
}
