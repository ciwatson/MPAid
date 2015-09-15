using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPAid
{
    public static class HMMsController
    {
        private static string hmmsValue = "HMMs/hmm15";

        public static string GetHMMsValue()
        {
            return hmmsValue;
        }

        public static void SetHMMsValue(string newValue)
        {
            if (newValue != hmmsValue)
                hmmsValue = newValue;
        }
        
    }
}
