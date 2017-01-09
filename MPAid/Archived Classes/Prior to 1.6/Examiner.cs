using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPAid
{
    /// <summary>
    /// This examiner will compare the identified string with the one on file.
    /// *** Only called by other marked code, marked for deletion ***
    /// </summary>
    class Examiner
    {
        private string rec, lab;
        /// <summary>
        /// Constructor, initialising the two strings to compare.
        /// </summary>
        /// <param name="recognized">The identified string.</param>
        /// <param name="laboratory">The correct string, for comparison.</param>
        public Examiner(string recognized, string laboratory)
        {
            rec = recognized;
            lab = laboratory;
        }
        /// <summary>
        /// Compares two strings, checking if the recorded string contains the correct string, or if they are equal.
        /// </summary>
        /// <returns>0 if the strings are equal, 1 if rec contains lab, and 2 otherwise.</returns>
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
        /// <summary>
        /// Checks if the input words match.
        /// </summary>
        /// <returns>True if the identified string contained the correct one, false otherwise.</returns>
        public bool wordsMatch()
        {
            return (getComparedResult() < 2);
        }
    }
}
