using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MPAid.Models
{
    /// <summary>
    /// Wrapper class for the App_Data folder path, allowing it to be accessed easily.
    /// </summary>
    class AppDataPath
    {
        /// <summary>
        /// Returns the location of a temporary folder in the temp space on the user's machine.
        /// </summary>
        private readonly static string temp = Path.Combine(System.Environment.GetEnvironmentVariable("TEMP"), "MPAiTemp");

        /// <summary>
        /// Combination of the standard MPAi directory, and a folder which will always be called App_Data.
        /// </summary>
        public readonly static string path = Path.Combine(System.Environment.GetEnvironmentVariable("localappdata"),"MPAi");

        /// <summary>
        /// Instantiates the temp directory if it doesn't already exist.
        /// </summary>
        public static string Temp
        {
            get
            {
                if (!Directory.Exists(temp))
                {
                    Directory.CreateDirectory(temp);
                }
                return temp;
            }
        }
    }
}