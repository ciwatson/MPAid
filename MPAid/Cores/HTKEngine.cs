using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MPAid.Cores
{
    class HTKEngine
    {
        static private readonly string HTKRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"HTK");
        private string BatchesFolder = Path.Combine(HTKRoot, @"Batches");

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
                StreamWriter userInput = process.StandardInput;
                userInput.WriteLine(arguments);
                //run process sequencially
                process.WaitForExit();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        public void Recognize(String RecordingPath)
        {
            RunBatchFile(Path.Combine(BatchesFolder, "Recordings2MFCs.bat"), RecordingPath);
            RunBatchFile(Path.Combine(BatchesFolder, "ModelEvaluater.bat"));
        }
    }
}
