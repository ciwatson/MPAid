using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MPAi
{
    /// <summary>
    /// Contains variables used to generate the HTML file in HtmlGenerator.
    /// *** Only called by other marked code, marked for deletion ***
    /// </summary>
    class HtmlConfig
    {
        private string userRecFileNamePrefix = "userRecording-";
        private string sampleRecFileNamePrefix = "sampleRecording-";
        private string recFileNameSuffix = ".wav";

        public string myWord = null;
        public string outputDir = "report";
        public string soundFolderName = "sound";
        public string imageFolderName = "image";
        public string reportFileName = "report.html";
        public string logoCorrect = "correct.png";
        public string logoWrong = "wrong.png";
        public string reportDir = null;
        public string correctnessValue;

        public List<string> listRecognized;
        /// <summary>
        /// Constructor. Ensures all images are present and available for use, and assigns the directory to create the HTML file in.
        /// </summary>
        /// <param name="rootDir">The directory to create the HTML report in, as a string.</param>
        public HtmlConfig(string rootDir)
        {
            reportDir = rootDir;
            CheckAndCreateImages();
        }
        /// <summary>
        /// Enum to abstract the different types of path used in the GetRecPath method.
        /// </summary>
        public enum pathType
        {
            fullUserRecPath = 0,
            fullSampleRecPath = 1,
            partialUserRecPath = 2,
            partialSampleRecPath = 3
        }
        /// <summary>
        /// Handles the different types of path, and calls the appropriate method to generate a complete system path from it.
        /// </summary>
        /// <param name="id">The ID of the recording that the path leads to.</param>
        /// <param name="type">The enum representing the path type of the recording.</param>
        /// <returns></returns>
        public string GetRecPath(int id, pathType type)
        {
            switch (type)
            {
                case pathType.fullUserRecPath:
                    return GetUserRecPath(id);
                case pathType.fullSampleRecPath:
                    return GetSampleRecPath(id);
                case pathType.partialUserRecPath:
                    return GetUserRecHtmlPath(id);
                case pathType.partialSampleRecPath:
                    return GetSampleRecHtmlPath(id);
                default:
                    return null;
            }
        }
        /// <summary>
        /// Converts a full user recording path to a string.
        /// </summary>
        /// <param name="id">The id of the recording, as an int.</param>
        /// <returns>The path to the recording, as a string.</returns>
        private string GetUserRecPath(int id)
        {
            return string.Format("{0}{2}{1}{3}{1}{4}{5}{6}",
                reportDir, Path.DirectorySeparatorChar, outputDir, soundFolderName,
                userRecFileNamePrefix, id.ToString("D4"), recFileNameSuffix);
        }
        /// <summary>
        /// Converts a full sample recording path to a string.
        /// </summary>
        /// <param name="id">The id of the recording, as an int.</param>
        /// <returns>The path to the recording, as a string.</returns>
        private string GetSampleRecPath(int id)
        {
            return string.Format("{0}{2}{1}{3}{1}{4}{5}{6}",
                reportDir, Path.DirectorySeparatorChar, outputDir, soundFolderName,
                sampleRecFileNamePrefix, id.ToString("D4"), recFileNameSuffix);
        }
        /// <summary>
        /// Converts a partial (starting from the MPAi directory) user recording path to a string.
        /// </summary>
        /// <param name="id">The id of the recording, as an int.</param>
        /// <returns>The path to the recording, as a string.</returns>
        private string GetUserRecHtmlPath(int id)
        {
            return string.Format("{0}{1}{2}{3}{4}", soundFolderName, Path.DirectorySeparatorChar,
                userRecFileNamePrefix, id.ToString("D4"), recFileNameSuffix);
        }
        /// <summary>
        /// Converts a partial (starting from the MPAi directory) sample recording path to a string.
        /// </summary>
        /// <param name="id">The id of the recording, as an int.</param>
        /// <returns>The path to the recording, as a string.</returns>
        private string GetSampleRecHtmlPath(int id)
        {
            return string.Format("{0}{1}{2}{3}{4}", soundFolderName, Path.DirectorySeparatorChar,
                sampleRecFileNamePrefix, id.ToString("D4"), recFileNameSuffix);
        }
        /// <summary>
        /// Gets the directory with the images stored in it.
        /// </summary>
        /// <returns>The image directory, as a string.</returns>
        public string GetReportImageDir()
        {
            return string.Format("{0}{1}{2}{1}{3}{1}",
                reportDir, Path.DirectorySeparatorChar, outputDir, imageFolderName);
        }
        /// <summary>
        /// Gets the directory with the user's recordings in it.
        /// </summary>
        /// <returns>The user recording directory, as a string.</returns>
        public string GetUserRecordingDir()
        {
            return string.Format("{0}{1}{2}{1}{3}{1}",
                reportDir, Path.DirectorySeparatorChar, outputDir, soundFolderName);
        }
        /// <summary>
        /// Gets the full path to the HTML report.
        /// </summary>
        /// <returns>The path, as a string.</returns>
        public string GetHtmlFullPath()
        {
            return string.Format("{0}{1}{2}{1}{3}",
                reportDir, Path.DirectorySeparatorChar, outputDir, reportFileName);
        }
        /// <summary>
        /// Checks that the image directory exists, and if not, creates it and adds relevant images to it.
        /// </summary>
        private void CheckAndCreateImages()
        {
            if (!Directory.Exists(GetReportImageDir()))
            {
                try
                {
                    Directory.CreateDirectory(GetReportImageDir());
                    File.WriteAllBytes(GetReportImageDir() + logoCorrect, Properties.Resources.correct);
                    File.WriteAllBytes(GetReportImageDir() + logoWrong, Properties.Resources.wrong);
                }
                catch (Exception)
                {
                    
                }           
            }
        }
    }
}
