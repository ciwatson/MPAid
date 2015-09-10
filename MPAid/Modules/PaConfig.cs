using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MPAid
{
    class PaConfig
    {
        ///<summary>
        ///The default configurations are listed as below
        ///</summary>

        public string script1 = "mpaidScript1.scp";
        public string script2 = "mpaidScript2.scp";
        public string transcript = "wordTranscript.mlf";
        public string HViteOut = "mpaidHViteOut";
        public string mlf0A = "mpaid0A.mlf";
        public string mlf0B = "mpaid0B.mlf";
        public string outputDir = "MPAidOutput";
        public string HResultsOut = "FinalResult.txt";

        public string currentWord = null;
        public string AnnieDir = null;
        public List<string> audioList = null;
        public string batFilePath = null;

        public bool TranscriptOK()
        {
            if (File.Exists(transcript))
                return true;
            else
                return false;
        }
    }
}
