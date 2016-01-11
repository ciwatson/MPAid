using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace MPAid
{
    class PaEngine
    {

        private PaConfig myConfig;

        public PaEngine(PaConfig config)
        {
            myConfig = config;
        }

        public void RunBatFile()
        {
            try
            {
                Process bat = new Process();
                bat.StartInfo.WorkingDirectory = myConfig.AnnieDir;
                bat.StartInfo.FileName = myConfig.batFilePath;
                bat.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                bat.Start();
                bat.WaitForExit();
            }
            catch { }
        }

        private bool informed = false;

        public bool NeedAdmin()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(myConfig.batFilePath))
                {
                    sw.WriteLine("echo off");
                    sw.WriteLine("color 0A");
                    sw.WriteLine("title Test file");
                    sw.WriteLine("echo This is a test file.");
                }
                return false;
            }
            catch (Exception ex)
            {
                if (!informed)
                {
                    informed = true;
                    MessageBox.Show("Something wrong happened :( \n"
                        + ex.Message, "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return true;
            }
        }

        public void CheckAndCreateDirs()
        {
            string targetDir = myConfig.AnnieDir + myConfig.outputDir;
            if (!Directory.Exists(targetDir))
                try
                {
                    Directory.CreateDirectory(targetDir);
                }
                catch { }
        }

        public void Start()
        {
            try
            {
                if (NeedAdmin())
                    return;

                CheckAndCreateDirs();
                GenerateFiles();
                RunBatFile();
            }
            catch(Exception)
            {

            }
        }

        public void GenerateFiles()
        {
            CreateScript1();
            CreateScript2();
            CreateBatchFile();
        }

        public string GetReportPath()
        {
            return (myConfig.AnnieDir + myConfig.outputDir + "\\" + myConfig.HResultsOut);
        }

        private string GetWordBetween(string source, string key1, string key2)
        {
            string tmpStr = source;
            tmpStr = tmpStr.Substring(tmpStr.IndexOf(key1));
            tmpStr = tmpStr.Remove(tmpStr.IndexOf(key2));
            string result = tmpStr.Substring(key1.Length);
            return result;
        }

        private const string MaoriEncodingCode = "iso-8859-1";
        private string strResultUnavailable = "Result unavailable";

        public string GetRecognizedWord()
        {
            string tmpStr = null;
            try
            {
                using (StreamReader sr = new StreamReader(GetReportPath(),
                    Encoding.GetEncoding(MaoriEncodingCode)))
                    tmpStr = sr.ReadToEnd();
                string locator = "REC: ", locator2 = ((char)10).ToString();
                const string errorMessage = "No transcriptions found";

                // this indicates that the result was not available
                if ((tmpStr.Contains(errorMessage)) && (tmpStr.Length > 0))
                    return strResultUnavailable;

                // this indicates that the word is correct
                if ((!tmpStr.Contains(locator)) && (tmpStr.Length > 0))
                    return myConfig.currentWord;
                
                string result = GetWordBetween(tmpStr, locator, locator2);
                return result;
            }
            catch (Exception)
            {
                return strResultUnavailable;
            }
        }

        private const string fullMark = "100.00";

        public string GetOverallResult()
        {
            const string prefix = "Correctness";
            string tmpStr = null;
            try
            {
                using (StreamReader sr = new StreamReader(GetReportPath()))
                    tmpStr = sr.ReadToEnd();
                string locator = "WORD: %Corr=", locator2 = ", Acc=";
                string result = GetWordBetween(tmpStr, locator, locator2);
                return string.Format("{0} = {1}%", prefix, result);
            }
            catch (Exception)
            {
                return strResultUnavailable;
            }
        }

        public bool wavFilesOK()
        {
            if (myConfig.audioList == null)
                return false;
            if (myConfig.audioList.Count == 0)
                return false;
            foreach (string item in myConfig.audioList)
                if (!File.Exists(item))
                    return false;
            return true;
        }

        private string ToMfcFileName(string wavFileName)
        {
            string wavFileExt = ".wav";
            string result = wavFileName.Remove(wavFileName.LastIndexOf(wavFileExt));
            result += ".mfc";
            return result;
        }

        private void CreateScript1()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(
                    myConfig.AnnieDir + "\\user\\" + myConfig.script1, false))
                    foreach (string wavFile in myConfig.audioList)
                        sw.WriteLine(string.Format("{0} {1}",
                            AddQuote(wavFile), AddQuote(ToMfcFileName(wavFile))));
            }
            catch { }
        }

        private void CreateScript2()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(
                    myConfig.AnnieDir + "\\user\\" + myConfig.script2, false))
                    foreach (string wavFile in myConfig.audioList)
                        sw.WriteLine(AddQuote(ToMfcFileName(wavFile)));
            }
            catch { }
        }

        // Add double quote for a string
        private string AddQuote(string targetStr)
        {
            if (string.IsNullOrEmpty(targetStr))
                return targetStr;

            if (string.IsNullOrEmpty(targetStr.Trim()))
                return targetStr;

            targetStr = targetStr.Trim();

            if (!targetStr.Contains(" "))
                return targetStr;

            if (!targetStr.Contains((char)34))
            {
                targetStr = (char)34 + targetStr;
                targetStr += (char)34;
            }

            return targetStr;
        }

        // This is one way how Annie's recognizer is called
        private void CreateBatchFile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(myConfig.batFilePath))
                {
                    sw.WriteLine("echo off");
                    sw.WriteLine("color 0A");
                    sw.WriteLine("title Processing");
                    sw.WriteLine(string.Format(@"HCopy -T 1 -C user/config0 -S user/{0}", myConfig.script1));
                    sw.WriteLine(string.Format(@"HVite -H -C user/config1 {4}/macros -H {4}/hmmdefs -S user/{0} -l * -T 4 -i {1}/{2} -w user/wordNetwork -p 0.0 -s 5.0 user/dictionary user/tiedList > {1}/{3}",
                        myConfig.script2, myConfig.outputDir, myConfig.mlf0A, myConfig.HViteOut, HMMsController.GetHMMsValue()));
                    sw.WriteLine(string.Format(@"HVite -H -C user/config1 {3}/macros -H {3}/hmmdefs -S user/{0} -l * -a -f -i {1}/{2} -w user/wordNetwork -p 0.0 -s 5.0 user/dictionary user/tiedList",
                        myConfig.script2, myConfig.outputDir, myConfig.mlf0B, HMMsController.GetHMMsValue()));
                    sw.WriteLine(string.Format(@"HResults -t -I user/{0} user/tiedList {1}/{2} > {1}/{3}",
                        myConfig.transcript, myConfig.outputDir, myConfig.mlf0A, myConfig.HResultsOut));
                }
            }
            catch { }
        }

        // You can create different ways to run Annie's recognizer
        private void CreateBatchFileType2()
        {
            using (StreamWriter sw = new StreamWriter(myConfig.batFilePath))
            {
                sw.WriteLine("echo off");
                sw.WriteLine("color 0A");
                sw.WriteLine("title Processing");
                
                // Add your code here 
                // please use a different way to call the recognizer

            }
        }
    }
}
