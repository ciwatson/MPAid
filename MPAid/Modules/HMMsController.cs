using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPAid
{
    class HMMsController
    {
        private string hmmsValue = "HMMsAnnie/HMMsFullSet";

        public string GetHMMsValue()
        {
            return hmmsValue;
        }

        public void SetHMMsValue(string newValue)
        {
            hmmsValue = newValue;
        }
        

    }
}
