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
        static void Main(string[] args)
        {

            if (args.Length > 0)
            {
                if (args[0] == "initDB")
                {
                    Application.Run(new NewForms.LoginScreen("initDB"));
                    return;
                }
            }
            Console.WriteLine("Running Normally.");
            
            Application.Run(new NewForms.LoginScreen());
            //MessageBox.Show("hahoi, hoihoi" + MPAid.Cores.Scoreboard.SimilarityAlgorithm.DamereauLevensheinDistanceAlgorithm("hahoi", "hoihoi") + "\nhoihoi, hahoi" + MPAid.Cores.Scoreboard.SimilarityAlgorithm.DamereauLevensheinDistanceAlgorithm("hoihoi", "hahoi"));
            Application.Exit();
        }
    }
}