using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.IO.Pipes;
using System.Windows.Forms;
using System.Threading;
using MPAi.Models;
using MPAi.Cores.Scoreboard;
using NAudio.CoreAudioApi;

namespace MPAi
{
    /// <summary>
    /// Class to runs and closes plots written in python which has been converting into an exe.
    /// Creates a proccess which runs the exe file for the requested plot.
    /// 
    /// Also serves as the 'middle man' between the C# and Python code. Via a pipe can send and recieve messages
    /// from the python code.
    /// 
    /// Due the nature of the exes. This class limits the project to be purely windows based.
    /// </summary>
    public static class PlotController

    {

        public enum PlotType { formantPlot, vowelPlot }

        private static PlotType? plotType;
        private static VoiceType? voiceType;
        private static Thread pipeThread;
        private static PythonPipe pythonPipe;

        // Calls to the windows USER32.dll file, to make changes to the Python user interface.

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_SHOWNORMAL = 1;
        /// <summary>
        /// If the  plot is running in the background, brings it to the foreground.
        /// </summary>
        /// <param name="title">The title of the  plot.</param>
        /// <returns>1 if the  plot is not currently running, 0 if it has been shown successfully.</returns>
        public static int ShowPlot(string title)
        {
            // Get a handle to the Plot application.
            IntPtr handle = FindWindow(null, title);

            // Verify that Plot is a running process.
            if (handle == IntPtr.Zero)
                return 1;

            // Make Plot the foreground application
            SetForegroundWindow(handle);
            ShowWindow(handle, SW_SHOWNORMAL);

            return 0;
        }
        /// <summary>
        /// Returns a value indicating if a  plot has been started.
        /// </summary>
        /// <param name="title">The title of the  Plot</param>
        /// <returns>1 if the  plot is not currently running, 0 if it has been shown successfully.</returns>
        public static int PlotStarted(string title)
        {
            // Get a handle to the Plot application.
            IntPtr handle = FindWindow(null, title);

            // Verify that Plot is a running process.
            if (handle == IntPtr.Zero)
                return 1;

            return 0;
        }

        private static Process PlotExe;
        private static bool shutdown;
        private static bool exitRequest = false;
        private static Process currentPlotProcess;

        public static Process getCurrentPlotProcess() {
            return currentPlotProcess;
                
        }

        /// <summary>
        /// Method called by the button to show the  plot. 
        /// If there is already a  plot running, it is brought into the foreground.
        /// If not, a new process is created.
        /// 
        /// requestedPlotType determines if RunPlot runs a Vowel or Formant Plot.
        /// requestedVoiceType determines if we use heratage/ modern and masculine/feminine for the plots. 
        /// </summary>
        public static void RunPlot(PlotType? requestedPlotType, VoiceType? requestedVoiceType)
        {
            exitRequest = false;
            plotType = requestedPlotType;
            voiceType = requestedVoiceType;

           

            var deviceEnum = new MMDeviceEnumerator();
            var devices = deviceEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active).ToList();
            if (devices.Count == 0)
            {
                MessageBox.Show("No recording device detected.\nVowel Plot requires a working microphone to function correctly.\nPlease plug in Microphone, or update Drivers.");

                NewForms.MPAiSoundMainMenu menu = new MPAi.NewForms.MPAiSoundMainMenu();
                menu.Show();

            }
            else
            {

                foreach (var process in Process.GetProcessesByName("VowelRunner"))
                {
                   
                    process.Kill();
                    process.WaitForExit();
                    process.Dispose();
                }


                if (PlotStarted(GetPlotTitle()) == 1)
                    StartPlot();
                else
                    ShowPlot(GetPlotTitle());

            }
           

            
        }
        /// <summary>
        /// Used to clean up after a  plot has been closed, as the process is simply put into the background.
        /// If this is called when the process does not exist yet, it does nothing.
        /// </summary>
        public static void ClosePlot()
        {
            Console.WriteLine("Close Requested...");
            PlotExe.CloseMainWindow();

            NewForms.MPAiSoundMainMenu menu = new MPAi.NewForms.MPAiSoundMainMenu();
            menu.Show();
        }


        /// <summary>
        /// Creates a new process, connects it to the python Runner file, and starts the  plot. 
        /// Also tidies up after an older process if it is still running.
        /// </summary>
        private static async void StartPlot()
        {
            
            try
            {
                // Before starting a new process, tidy up any old ones in the background.
                //  ClosePlot();


                pythonPipe = new PythonPipe();

                pipeThread = new Thread(new ThreadStart(pythonPipe.ConnectAndRecieve));
                pipeThread.IsBackground = true;
                pipeThread.Start();

                Console.WriteLine("after Thread");



                PlotExe = new Process();
                //PlotExe.StartInfo.FileName = Path.Combine(Properties.Settings.Default.FomantFolder, @"dist",@"VowelRunner.exe");


                if (plotType == PlotType.vowelPlot)
                {
                    PlotExe.StartInfo.FileName = @"VowelRunner.exe";
                }
                else if (plotType == PlotType.formantPlot)
                {
                    PlotExe.StartInfo.FileName = @"PlotRunner.exe";
                }




                // Gets the arguments required for the console command to run the exe file.
                // based on the requested voiceType.
                switch (voiceType)
                {
                    case VoiceType.MASCULINE_HERITAGE:
                        PlotExe.StartInfo.Arguments = @"masculine heritage";
                        break;
                    case VoiceType.MASCULINE_MODERN:

                        PlotExe.StartInfo.Arguments = @"masculine modern";
                        break;
                    case VoiceType.FEMININE_HERITAGE:
                        PlotExe.StartInfo.Arguments = @"feminine heritage";
                        break;
                    case VoiceType.FEMININE_MODERN:
                        PlotExe.StartInfo.Arguments = @"feminine modern";
                        break;
                    default:
                        PlotExe.StartInfo.Arguments = @"masculine heritage";
                        break;
                }
                
                PlotExe.StartInfo.UseShellExecute = true;
                PlotExe.StartInfo.WorkingDirectory = Path.Combine(Properties.Settings.Default.FomantFolder, "Dist");

                //PlotExe.StartInfo.WorkingDirectory = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Fomant", "Dist");

                PlotExe.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

                Console.WriteLine(Path.Combine(PlotExe.StartInfo.WorkingDirectory, PlotExe.StartInfo.FileName));
                //PlotExe.StartInfo.FileName = Path.Combine(PlotExe.StartInfo.WorkingDirectory, PlotExe.StartInfo.FileName);
                currentPlotProcess = PlotExe;
                PlotExe.Start();
                int count = 0;
                // Hang up the main application to wait until it finished starting
                while ((PlotStarted(GetPlotTitle()) == 1) && (!exitRequest))
                {
                    count++;
                    Console.Write(count);

                    // Wait 5 ms before checking if secondary application has started, preventing CPU blocking.
                    await System.Threading.Tasks.Task.Delay(5);
                }
                Console.WriteLine(PlotStarted(GetPlotTitle()));
                Console.WriteLine(!PlotExe.HasExited);
                Console.WriteLine("End of first loop.");
                while ( !exitRequest)
                {

                    await System.Threading.Tasks.Task.Delay(10);

                }



                Console.WriteLine("Request end of program.");

                StopThread();
                ClosePlot();


            }
            catch (Exception exp)
            {

                PlotExe = null;
                Console.WriteLine(exp);
            }
        }

        private static void StopThread()
        {

            shutdown = true;
            pythonPipe.requestShutDown();
        }

        public static void RequestShutDown() {
            Console.WriteLine("Request ShutDown, exitRequest made.");
            exitRequest = true;
        }

       
        /// <summary>
        /// Getter for the title of the  plot.  
        /// </summary>
        /// <returns>The title of the  plot, as a string.</returns>
        public static string GetPlotTitle()
        {
            if (plotType == PlotType.vowelPlot)
            {
                return (@"Vowel Plot");
            }
            else if (plotType == PlotType.formantPlot)
            {
                return (@"Fomant Plot");
            }
            return null;

        }
    }
    /// <summary>
    /// Python Pipe creates a connection between the c# and python applications, allowing the python to relay stats back to the c# in order to display to the user.
    /// </summary>
    public class PythonPipe
    {
        private Boolean pipeServerIsClosed;
        private Boolean firstTime;
        private Boolean shutdown = false;
       
        
        public void requestShutDown()
        {
            shutdown = true;
        }

        public void ConnectAndRecieve()
        {
            pipeServerIsClosed = false;
            firstTime = true;


            while (!pipeServerIsClosed)
            {

                if (!shutdown)
                {
                    Console.WriteLine("PythonPipe.connectAndRecieve is running in its own thread");
                    // Open the named pipe.

                    ////firstTime = false;

                    

                    using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("NPSSVowelPlot", PipeDirection.InOut, 254))
                    {

                        Console.WriteLine("Waiting for connection...");
                        pipeServer.WaitForConnection();

                        Console.WriteLine("Connected.");
                        var binaryReader = new BinaryReader(pipeServer);
                        Console.WriteLine("Messages from VowelPlot.py...");
                        while (true)
                        {
                            try
                            {

                                var recievedLength = (int)binaryReader.ReadUInt64();            // Read string length
                                string recievedString = new string(binaryReader.ReadChars(recievedLength - 1));

                                if (recievedString.Length == 1) {
                                    break;
                                }
                                String[] recievedStringList = recievedString.Split('\n');
                                int length = recievedStringList.Length;
                                Console.WriteLine(length);
                                MPAiSoundScoreBoardSession session = UserManagement.CurrentUser.SoundScoreboard.NewScoreBoardSession();
                                

                                int count = 0;
                                foreach (String str in recievedStringList) {
                                    String[] lineStringList = str.Split(' ');
                                    if (count > 0)
                                    {
                                        //vowels
                                        String vowel = lineStringList[0];
                                        float correctnessPercentage;
                                        if (!float.TryParse(lineStringList[1], out correctnessPercentage))
                                        {
                                            throw new Exception("Could not parse String to Float");
                                        }

                                        session.AddScoreBoardItem(vowel, correctnessPercentage);
                                    }
                                    else {
                                        //total
                                        float overallPercentage;
                                        
                                        if (!float.TryParse(lineStringList[1], out overallPercentage))
                                        {
                                            throw new Exception("Could not parse String to Float");
                                        }
                                        Console.WriteLine(overallPercentage);
                                        session.OverallCorrectnessPercentage = overallPercentage;
                                    }
                                    count++;


                                }

                                ReportLauncher.GenerateMPAiSoundScoreHTML(UserManagement.CurrentUser.SoundScoreboard);

                            }
                            catch (EndOfStreamException)
                            {
                                break;
                            }
                        }
                        Console.WriteLine("Requesting plotcontrooler to shut down ");
                        PlotController.RequestShutDown();
                    }



                } else
                {
                    break;
                }


            }


        }
    }
}