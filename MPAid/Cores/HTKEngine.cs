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
        public void RunBatchFile(string filePath, string arguments = "")
        {
            if (!File.Exists(filePath)) return;
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo(filePath);
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = false;
                processInfo.WorkingDirectory = Path.Combine(SystemConfigration.configs.HTKFolderAddr.FolderAddr, @"Batches");
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
            string BatchesFolder = Path.Combine(SystemConfigration.configs.HTKFolderAddr.FolderAddr, @"Batches");
            string MLFsFolder = Path.Combine(SystemConfigration.configs.HTKFolderAddr.FolderAddr, @"MLFs");
            //RunBatchFile(Path.Combine(BatchesFolder, "Recordings2MFCs.bat"), RecordingPath);
            RunBatchFile(Path.Combine(BatchesFolder, "ModelEvaluater.bat"), RecordingPath);
            return Analyze(Path.Combine(MLFsFolder, "RecMLF.mlf"));
        }

        public IDictionary<string, string> Analyze(String ResultPath)
        {
            Dictionary<String, String> RecResult = new Dictionary<string, string>();
            if (File.Exists(ResultPath))
            {
                try
                {
                    using (FileStream fs = File.OpenRead(ResultPath))
                    {
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            string line;
                            Match m = Match.Empty;
                            string index = string.Empty;
                            string result = string.Empty;
                            while ((line = sr.ReadLine()) != null)
                            {
                                if ((m = Regex.Match(line, @"(?<="")(?:\\.|[^""\\])*(?="")")).Success)
                                {
                                    index = m.Value;
                                }
                                else if (Regex.Match(line, @"\.$").Success)
                                {
                                    RecResult.Add(index.TrimStart('*', '/'), result.TrimEnd(' '));
                                    m = Match.Empty;
                                    index = string.Empty;
                                    result = string.Empty;
                                }
                                else if (line != "#!MLF!#")
                                {
                                    result += line + " ";
                                }
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp);
                }
            }
            return RecResult;
        }
    }
}
