using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPAid
{
    /// <summary>
    /// This examiner will compare the result
    /// </summary>
    class Examiner
    {
        private string rec, lab;
        
        public Examiner(string recognized, string laboratory)
        {
            rec = recognized;
            lab = laboratory;
        }

        public int getComparedResult()
        {
            if (rec == lab)
                return 0;
            if (rec.Contains(lab))
                return 1;
            if (!rec.Contains(lab))
                return 2;
            return 0;
        }

        public bool wordsMatch()
        {
            return (getComparedResult() < 2);
        }
    }
}
