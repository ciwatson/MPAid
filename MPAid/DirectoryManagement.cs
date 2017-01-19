using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPAid.Models;
using System.IO;

namespace MPAid
{
    class DirectoryManagement
    {
        private static string scoreboardReportFolder;
        private static string videoFolder;
        private static string audioFolder;
        private static string recordingFolder;

        public static string ScoreboardReportFolder
        {
            get
            {
                if(scoreboardReportFolder == null)
                {
                    string path = Path.Combine(AppDataPath.path, "ScoreboardReports");
                    ensureDirectoryExists(path);
                    return Path.Combine(path);
                }
                else
                {
                    return scoreboardReportFolder;
                }  
            }
            set
            {
                scoreboardReportFolder = value;
            }
        }

        public static string VideoFolder
        {
            get
            {
                if(videoFolder == null)
                {
                    string path = Path.Combine(AppDataPath.path, "Video");
                    ensureDirectoryExists(path);
                    return Path.Combine(path);
                }
                else
                {
                    return videoFolder;
                }
            }
            set
            {
                videoFolder = value;
            }
        }

        public static string AudioFolder
        {
            get
            {
                if(audioFolder == null)
                {
                    string path = Path.Combine(AppDataPath.path, "Audio");
                    ensureDirectoryExists(path);
                    return Path.Combine(path);
                }
                else
                {
                    return audioFolder;
                }
            }
            set
            {
                audioFolder = value;
            }
        }

        public static string RecordingFolder
        {
            get
            {
                if(recordingFolder == null)
                {
                    string path = Path.Combine(AppDataPath.path, "Recording");
                    ensureDirectoryExists(path);
                    return Path.Combine(path);
                }
                else
                {
                    return recordingFolder;
                }
            }
            set
            {
                recordingFolder = value;
            }
        }

        private static void ensureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
