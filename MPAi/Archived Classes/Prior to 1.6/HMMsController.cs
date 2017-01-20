using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPAi
{
    /// <summary>
    /// Class that holds the current HMM file to use. 
    /// *** Only used by other marked files, marked for deletion ***
    /// </summary>
    public static class HMMsController
    {
        /// <summary>
        /// The current HMM file, and its path within the MPAi directory.
        /// </summary>
        private static string hmmsValue = "HMMs/hmm15";
        /// <summary>
        /// Getter for the hmmsValue field.
        /// </summary>
        /// <returns>The HMM file's path, as a string.</returns>
        public static string GetHMMsValue()
        {
            return hmmsValue;
        }
        /// <summary>
        /// Setter for the hmmsValue field. Does nothing if the input vlaue is the current value.
        /// </summary>
        /// <param name="newValue">The value to set the hmmsValue field to.</param>
        public static void SetHMMsValue(string newValue)
        {
            if (newValue != hmmsValue)
                hmmsValue = newValue;
        }
        
    }
}
