using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MPAid
{
    class HtmlConfig
    {
        private string userRecFileNamePrefix = "userRecording-";
        private string sampleRecFileNamePrefix = "sampleRecording-";
        private string recFileNameSuffix = ".wav";

        public string myWord = null;
        public string outputDir = "MPAidOutput";
        public string soundFolderName = "sound";
        public string imageFolderName = "image";
        public string reportFileName = "report.html";
        public string annieDir = null;
        public string correctnessValue;

        public List<string> listRecognized;

        public HtmlConfig(string rootDir)
        {
            annieDir = rootDir;
        }

        public enum pathType
        {
            fullUserRecPath = 0,
            fullSampleRecPath = 1,
            partialUserRecPath = 2,
            partialSampleRecPath = 3
        }

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

        private string GetUserRecPath(int id)
        {
            return string.Format("{0}{2}{1}{3}{1}{4}{5}{6}",
                annieDir, Path.DirectorySeparatorChar, outputDir, soundFolderName,
                userRecFileNamePrefix, id.ToString("D4"), recFileNameSuffix);
        }

        private string GetSampleRecPath(int id)
        {
            return string.Format("{0}{2}{1}{3}{1}{4}{5}{6}",
                annieDir, Path.DirectorySeparatorChar, outputDir, soundFolderName,
                sampleRecFileNamePrefix, id.ToString("D4"), recFileNameSuffix);
        }

        private string GetUserRecHtmlPath(int id)
        {
            return string.Format("{0}{1}{2}{3}{4}", soundFolderName, Path.DirectorySeparatorChar,
                userRecFileNamePrefix, id.ToString("D4"), recFileNameSuffix);
        }

        private string GetSampleRecHtmlPath(int id)
        {
            return string.Format("{0}{1}{2}{3}{4}", soundFolderName, Path.DirectorySeparatorChar,
                sampleRecFileNamePrefix, id.ToString("D4"), recFileNameSuffix);
        }

        public string GetReportImageDir()
        {
            return string.Format("{0}{1}{2}{1}{3}{1}",
                annieDir, Path.DirectorySeparatorChar, outputDir, imageFolderName);
        }

        public string GetUserRecordingDir()
        {
            return string.Format("{0}{1}{2}{1}{3}{1}",
                annieDir, Path.DirectorySeparatorChar, outputDir, soundFolderName);
        }

        public string GetHtmlFullPath()
        {
            return string.Format("{0}{1}{2}{1}{3}",
                annieDir, Path.DirectorySeparatorChar, outputDir, reportFileName);
        }

    }
}
