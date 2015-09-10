using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPAid
{
    public class WordMapper
    {

        public string GetNameByIndex(int index)
        {
            string objName = null;
            if (Content.TryGetValue(index, out objName))
                return (objName);
            else
                return null;
        }

        public Dictionary<int, string> Content;

        public WordMapper()
        {
            Content = new Dictionary<int, string>();
            Content.Add(1, "tënei");
            Content.Add(2, "täne");
            Content.Add(3, "hau");
            Content.Add(4, "hou");
            Content.Add(5, "pao");
            Content.Add(6, "pau");
            Content.Add(7, "pou");
            Content.Add(8, "pö");
            Content.Add(9, "pai");
            Content.Add(10, "pae");
            Content.Add(11, "kë");
            Content.Add(12, "kei");
            Content.Add(13, "kï");
            Content.Add(14, "hë");
            Content.Add(15, "hei");
            Content.Add(16, "hï");
            Content.Add(17, "tae");
            Content.Add(18, "tai");
            Content.Add(19, "mätao");
            Content.Add(20, "mätau");
            Content.Add(21, "mätou");
            Content.Add(22, "toetoe");
            Content.Add(23, "toi");
            Content.Add(24, "hoihoi");
            Content.Add(25, "hoe");
            Content.Add(26, "mao");
            Content.Add(27, "mau");
            Content.Add(28, "moutere");
            Content.Add(29, "tü");
            Content.Add(30, "matiu");
        }

    }
}
