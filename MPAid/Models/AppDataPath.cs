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
        /// Combination of the standard MPAi directory, and a folder which will always be called App_Data.
        /// </summary>
        public readonly static string path = Path.Combine(System.Environment.GetEnvironmentVariable("localappdata"),"MPAi");
    }
}
