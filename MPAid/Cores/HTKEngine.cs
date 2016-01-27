using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MPAid.Cores
{
    class HTKEngine
    {
        static private readonly string HTKRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"HTK");
        private string BatchesFolder = Path.Combine(HTKRoot, @"Batches");
        private string MLFsFolder = Path.Combine(HTKRoot, @"MLFs");

        public void RunBatchFile(string filePath, string arguments = "")
        {
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo(filePath);
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = false;
                processInfo.WorkingDirectory = BatchesFolder;
                //  ***Redirect the output ***
                processInfo.RedirectStandardError = true;
                processInfo.RedirectStandardOutput = true;
                processInfo.RedirectStandardInput = true;

                Process process = Process.Start(processInfo);
                process.StandardInput.WriteLine(arguments);
                //run process sequencially
                 process.WaitForExit();
                //if(process.WaitForExit(10000))
                //{
                //    string output = process.StandardOutput.ReadToEnd();
                //}
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        public IDictionary<string, string> Recognize(String RecordingPath)
        {
            //RunBatchFile(Path.Combine(BatchesFolder, "Recordings2MFCs.bat"), RecordingPath);
            RunBatchFile(Path.Combine(BatchesFolder, "ModelEvaluater.bat"), RecordingPath);
            return Analyze(Path.Combine(MLFsFolder, "RecMLF.mlf"));
        }

        public IDictionary<string, string> Analyze(String ResultPath)
        {
            Dictionary<String, String> RecResult = new Dictionary<string, string>();
            try
            {
                using (FileStream fs = File.OpenRead(ResultPath))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string line;
                        Match m = Match.Empty;
                        string result = "";
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (Regex.Match(line, @"(?<="")(?:\\.|[^""\\])*(?="")").Success)
                            {
                                m = Regex.Match(line, @"(?<="")(?:\\.|[^""\\])*(?="")");
                            }
                            else if (Regex.Match(line, @"\.$").Success)
                            {
                                RecResult.Add(m.Value, result);
                                m = Match.Empty;
                                result = "";
                            }
                            else if(line != "#!MLF!#")
                            {
                                result += line;
                            }
                        }
                    }
                }
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp);
            }
            return RecResult;
        }
    }
}
