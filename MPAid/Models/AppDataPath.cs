using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MPAid.Models
{
    class AppDataPath
    {
        public readonly static string path = Path.Combine(System.Windows.Forms.Application.StartupPath, @"App_Data");
    }
}
