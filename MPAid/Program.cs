using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MPAid
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NewForms.LoginScreen());
            //MessageBox.Show("hahoi, hoihoi" + MPAid.Cores.Scoreboard.SimilarityAlgorithm.DamereauLevensheinDistanceAlgorithm("hahoi", "hoihoi") + "\nhoihoi, hahoi" + MPAid.Cores.Scoreboard.SimilarityAlgorithm.DamereauLevensheinDistanceAlgorithm("hoihoi", "hahoi"));
        }
    }
}