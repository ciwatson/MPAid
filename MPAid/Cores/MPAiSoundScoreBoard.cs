using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAid.Cores
{
    class MPAiSoundScoreBoardItem
    {
        string vowel;

        public string Vowel
        {
            get { return vowel; }
        }

        float correctnessPercentage;

        public float CorrectnessPercentage
        {
            get { return correctnessPercentage; }
        }

        public MPAiSoundScoreBoardItem(string vowel, float correctnessPercentage)
        {
            this.vowel = vowel;
            this.correctnessPercentage = correctnessPercentage;
        }
    }
    class MPAiSoundScoreBoard
    {
        private List<MPAiSoundScoreBoardItem> content = new List<MPAiSoundScoreBoardItem>();

        public List<MPAiSoundScoreBoardItem> Content {
            get { return content; }
        }

        float overallCorrectnessPercentage;

        public float OverallCorrectnessPercentage
        {
            get { return overallCorrectnessPercentage; }
        }

        public MPAiSoundScoreBoard(float overallCorrectnessPercentage)
        {
            this.overallCorrectnessPercentage = overallCorrectnessPercentage;
        }

        public void AddScoreBoardItem(string vowel, float correctnessPercentage)
        {
            Content.Add(new MPAiSoundScoreBoardItem(vowel, correctnessPercentage));
        }
    }
}
