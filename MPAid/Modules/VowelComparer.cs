using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAid.Modules
{
    public class VowelComparer : IComparer<String>
    {
        public int Compare(String x, String y)
        {
            if (table.FindIndex(i => i == x) > table.FindIndex(i => i == y))
            {
                return -1;
            }
            else if (table.FindIndex(i => i == x) < table.FindIndex(i => i == y))
            {
                return 1;
            }
            else if (table.FindIndex(i => i == x) == table.FindIndex(i => i == y))
            {
                if (table.Contains(x) || table.Contains(y)) return 0;
                else return x.CompareTo(y);
            }
            return 0;
        }

        private List<String> table = new List<string>()
        {
            "a",
            "ae"
        };
    }
}
