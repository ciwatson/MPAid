using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAid.Cores
{
    public delegate float SimilarityAlgorithmCallBack(string str1, string str2);
    class ScoreBoardItem
    {
        public ScoreBoardItem()
        {

        }
        public ScoreBoardItem(string recognisedText, string expectingText)
            : this()
        {
        }
        public ScoreBoardItem(string recognisedText)
            : this(recognisedText, recognisedText)
        {}
        public float Similarity(SimilarityAlgorithmCallBack simi)
        {
            return simi(recognisedText, expectingText);
        }
        private string recognisedText;
        public string RecognisedText
        {
            get { return recognisedText; }
            set { recognisedText = value; }
        }
        private string expectingText;
        public string ExpectingText
        {
            get { return expectingText; }
            set { expectingText = value; }
        }
    }
    class ScoreBoard
    {
        public float CalculateCorrectness
        {
            get { return CalculateScore / content.Count;}
        }

        public float CalculateScore
        {
            get
            {
                float sum = 0;
                foreach(ScoreBoardItem item in content)
                {
                    sum += item.Similarity(SimilarityAlgorithm.DamereauLevensheinDistanceAlgorithm);
                }
                return sum;
            }
        }
     
        public List<ScoreBoardItem> content = new List<ScoreBoardItem>();
    }

    public static class SimilarityAlgorithm
    {
        public static float DamereauLevensheinDistanceAlgorithm(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1))
            {
                if (string.IsNullOrEmpty(str2))
                    return 0;
                return str2.Length;
            }

            if (string.IsNullOrEmpty(str2))
            {
                return str1.Length;
            }

            int n = str1.Length;
            int m = str2.Length;
            int[,] d = new int[n + 1, m + 1];

            // initialize the top and right of the table to 0, 1, 2, ...
            for (int i = 0; i <= n; d[i, 0] = i++) ;
            for (int j = 1; j <= m; d[0, j] = j++) ;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (str2[j - 1] == str1[i - 1]) ? 0 : 1;
                    int min1 = d[i - 1, j] + 1;
                    int min2 = d[i, j - 1] + 1;
                    int min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }
            return 1 - (float)d[n, m] / m;
        }
    }
}
