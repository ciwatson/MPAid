using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.IO;

namespace MPAid.Cores
{
    public class NAudioPlayer
    {
        private WaveFileReader reader;
        public NAudioPlayer()
        {
        }
        public void Play(string filePath)
        {
            try
            {
                if (!File.Exists(filePath)) throw new Exception(string.Format("No such a file:{0}!", filePath));
                reader = new WaveFileReader(filePath);
                var waveOut = new WaveOutEvent();
                waveOut.Init(reader);
                waveOut.PlaybackStopped += WaveOut_PlaybackStopped; ;
                waveOut.Play();
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp);
            }
        }
        private void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (sender != null) (sender as WaveOutEvent).Dispose();
            if (reader != null)
            {
                reader.Dispose();
                reader = null;
            }
        }
    }
}
