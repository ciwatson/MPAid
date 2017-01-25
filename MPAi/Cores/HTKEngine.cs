﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MPAi.Cores
{
    /// <summary>
    /// Class that handles the invoking of the batch files used for analysis from within the C# code.
    /// </summary>
    class HTKEngine
    {
        /// <summary>
        /// Sequentially runs a batch file from within the program, supressing output that would be visible to the user.
        /// </summary>
        /// <param name="filePath">The path to the batch file.</param>
        /// <param name="arguments">The arguments to the batch file.</param>
        public void RunBatchFile(string filePath, string arguments = "")
        {
            if (!File.Exists(filePath)) return;
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo(filePath);
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = false;
                processInfo.WorkingDirectory = Path.Combine(Properties.Settings.Default.HTKFolder, @"Batches");
                // Redirect the output
                processInfo.RedirectStandardError = true;
                processInfo.RedirectStandardOutput = true;
                processInfo.RedirectStandardInput = true;

                Process process = Process.Start(processInfo);
                process.StandardInput.WriteLine(arguments);
                process.WaitForExit();

                // Optional: Output debug information to standard output after a timeout.
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
        /// <summary>
        /// Invokes the necessary batch file on a recording to identify what the file is saying, then invokes the analyse method.
        /// </summary>
        /// <param name="RecordingPath">The path to the recording to analyse.</param>
        /// <returns>The IDictionary object output by the analyse method.</returns>
        public IDictionary<string, string> Recognize(String RecordingPath)
        {
            string BatchesFolder = Path.Combine(Properties.Settings.Default.HTKFolder, @"Batches");
            string MLFsFolder = Path.Combine(Properties.Settings.Default.HTKFolder, @"MLFs");
            // Deprecated: This batch file is not used.
            //RunBatchFile(Path.Combine(BatchesFolder, "Recordings2MFCs.bat"), RecordingPath);
            RunBatchFile(Path.Combine(BatchesFolder, "ModelEvaluater.bat"), RecordingPath);
            return Analyze(Path.Combine(MLFsFolder, "RecMLF.mlf"));
        }
        /// <summary>
        /// Analyses the .mlf file created by ModelEvaluater.bat, creating a dictionary mapping the recording to a string representing the words spoken in the recording.
        /// </summary>
        /// <param name="ResultPath">The MLF file to analyse.</param>
        /// <returns>An IDictionary mapping the recording name as a a string to the word detected in the recording.</returns>
        public IDictionary<string, string> Analyze(String ResultPath)
        {
            Dictionary<String, String> RecResult = new Dictionary<string, string>();
            if (File.Exists(ResultPath))
            {
                try
                {
                    // Open a stream to read the file.
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
                                if ((m = Regex.Match(line, @"(?<="")(?:\\.|[^""\\])*(?="")")).Success)  // If the line is in the recording name format
                                {
                                    index = m.Value;    // Save it as the index.
                                }
                                else if (Regex.Match(line, @"\.$").Success) // If the line is in the format of a word
                                {
                                    RecResult.Add(index.TrimStart('*', '/'), ResultModifier.LetterReplace(result.TrimEnd(' ')));    // Replace any delimiter characters or unicodes and add the recording/word pair to the dictionary.
                                    m = Match.Empty;
                                    index = string.Empty;
                                    result = string.Empty;
                                }
                                else if (line != "#!MLF!#") // If not a header line, then it will be a word, add it to the result.
                                {
                                    result += line + " ";
                                }
                                // "#!MLF!#", the header line, is implictly ignored.
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
    /// <summary>
    /// Class to convert the unicode for long vowel characters into the equivalent symbol.
    /// </summary>
    public static class ResultModifier
    {
        /// <summary>
        /// Performs the letter conversion.
        /// </summary>
        /// <param name="value">The text to convert all the unicodes for.</param>
        /// <returns>The input string, but with all unicodes replaced with equivalent characters.</returns>
        public static string LetterReplace(string value)
        {
            value = value.Replace(@"\344", @"ä").Replace(@"\353", @"ë").Replace(@"\357", @"ï").Replace(@"\366", @"ö").Replace(@"\374", @"ü");
            return value;
        }
    }
}
