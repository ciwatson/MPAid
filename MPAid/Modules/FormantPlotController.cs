using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using MPAid.Cores;

namespace MPAid
{
    public static class FormantPlotController
    {

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_SHOWNORMAL = 1;

        public static int ShowFormantPlot(string title)
        {
            // Get a handle to the FormantPlot application.
            IntPtr handle = FindWindow(null, title);

            // Verify that FormantPlot is a running process.
            if (handle == IntPtr.Zero)
                return 1;

            // Make FormantPlot the foreground application
            SetForegroundWindow(handle);
            ShowWindow(handle, SW_SHOWNORMAL);

            return 0;
        }

        public static int FormantPlotStarted(string title)
        {
            // Get a handle to the FormantPlot application.
            IntPtr handle = FindWindow(null, title);

            // Verify that FormantPlot is a running process.
            if (handle == IntPtr.Zero)
                return 1;

            return 0;
        }

        private static Process FormantPlotExe;

        public static void RunFormantPlot()
        {
            if (FormantPlotStarted(GetFormantPlotTitle()) == 1)
                StartFormantPlot();
            else
                ShowFormantPlot(GetFormantPlotTitle());
        }

        public static void CloseFormantPlot()
        {
            if ((FormantPlotExe != null) && (!FormantPlotExe.HasExited))
                FormantPlotExe.Kill();
        }

        private static void StartFormantPlot()
        {
            try
            {              
                FormantPlotExe = new Process();
                FormantPlotExe.StartInfo.FileName = "Runner.exe";
                FormantPlotExe.StartInfo.UseShellExecute = true;
                FormantPlotExe.StartInfo.WorkingDirectory = @"D:\Projects\MPAid\MPAid\bin\x86\Debug\Fomant\dist";
                FormantPlotExe.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                FormantPlotExe.Start();

                // Hang up the main application to wait until it finished starting
                while ((FormantPlotStarted(GetFormantPlotTitle()) == 1)
                    && (!FormantPlotExe.HasExited))
                    ;
            }
            catch(Exception exp)
            {
                FormantPlotExe = null;
                Console.WriteLine(exp);
            }
        }

        public static string GetFormantPlotTitle()
        {
            return (@"Formant Plot");
        }
    }
}
