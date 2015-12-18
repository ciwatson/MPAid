using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Core;

namespace MPAid.UserControls
{
    public partial class OperationPanel : UserControl
    {
        public VlcPlayer VlcPlayer
        {
            get { return vlcPlayer; }
        }

        public NAudioRecorder NAudioRecorder
        {
            get { return naudioRecorder; }
        }
        public OperationPanel()
        {
            InitializeComponent();

            tdButtonFormantPlot.ImageNormal = Properties.Resources.ButtonYellow_0;
            tdButtonFormantPlot.ImageHighlight = Properties.Resources.ButtonYellow_1;
            tdButtonFormantPlot.ImagePressed = Properties.Resources.ButtonYellow_2;
        }
        private void operationTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            VlcPlayer.VlcControl.Stop();
        }
        private void tdButtonFormantPlot_Click(object sender, EventArgs e)
        {
            tdButtonFormantPlot.Enabled = false;

            // Start formant plot
            FormantPlotController.RunFormantPlot();

            tdButtonFormantPlot.Enabled = true;
        }

        private void buttonRecord_Click(object sender, EventArgs e)
        {
            ////cmd vlc.exe -vvv dshow:// –dshow-vdev=None –dshow-adev=default --sout file/wav:d:\\test.wav
            ////cmd -vvv -I rc --ttl dshow:// vdev=None adev="Logitech USB Headset" --sout=#std{access=file,mux=wav,dst=D:\\test.wav}
            ////cmd dshow:// :dshow-vdev=None :dshow-adev='Logitech USB Headset' :sout=#transcode{vcodec=h264,vb=800,scale=1,acodec=s16l, ab=128, channels=2,samplerate=22050}:std{access=file,mux=wav,dst=D:\\test.wav}
            //String fullName = @"D:\test.wav";
            ////String options = @":sout=#es{access=file,mux=ps,url_audio=D:\test.wav}"; 
            //String VideoOption = ":dshow-vdev=None ";
            //String AudioOption = ":dshow-adev=default";
            ////String options = ":sout=#transcode{vcodec=h264,vb=800,scale=1,acodec=s16l, ab=128, channels=2,samplerate=22050}:std{access=file,mux=wav,dst=" + fullName + "}";
            ////String options = ":sout=file/wav:" + fullName;
            //String options = ":sout=#transcode{vcodec=h264,vb=800,scale=1,acodec=s16l, ab=128, channels=1,samplerate=220500}:std{access=file,mux=wav,dst=D:\test.wav}";
            ////vlcPlayer.VlcControl.Play(new Uri(@"dshow:// :dshow-vdev='None' :dshow-adev='Default'"), options); d:\female-word-hau-L1H01M.wav
            //vlcPlayer.VlcControl.Play(new Uri("dshow://"), options);
            //buttonRecord.Enabled = false;
            //buttonLoadFromFile.Enabled = false;
            //buttonStopRecording.Enabled = true;
        }

        private void buttonStopRecording_Click(object sender, EventArgs e)
        {
            //vlcPlayer.VlcControl.Stop();

            //buttonRecord.Enabled = true;
            //buttonLoadFromFile.Enabled = true;
            //buttonStopRecording.Enabled = false;
        }

        private void buttonShowDir_Click(object sender, EventArgs e)
        {

        }

        private void buttonLoadFromFile_Click(object sender, EventArgs e)
        {

        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {

        }

        private void buttonShowReport_Click(object sender, EventArgs e)
        {

        }
    }
}
