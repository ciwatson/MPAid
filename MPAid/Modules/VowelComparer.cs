using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPAid.Models;
namespace MPAid.Modules
{
    public class VowelComparer : IComparer<Word>
    {
        public int Compare(Word x, Word y)
        {
            if (table.FindIndex(i => i == x.Name) > table.FindIndex(i => i == y.Name))
            {
                return 1;
            }
            else if (table.FindIndex(i => i == x.Name) < table.FindIndex(i => i == y.Name))
            {
                return -1;
            }
            else if (table.FindIndex(i => i == x.Name) == table.FindIndex(i => i == y.Name))
            {
                if (table.Contains(x.Name) || table.Contains(y.Name)) return 0;
                else return x.Name.CompareTo(y.Name);
            }
            return 0;
        }

        private List<String> table = new List<string>()
        {
            "o",
            "a",
            "e",
            "i",
            "u",
            "ae",
            "ai",
            "ao",
            "au",
            "ou"
        };
    }
}
