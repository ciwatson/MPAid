using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordingRenamer
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter the folder of your recordings (enter -1 to exit):\n");
                String path = Console.ReadLine();
                if (path == "-1") return;

                DirectoryInfo dirInfo = new DirectoryInfo(path);
                Renamer renamer = new Renamer();

                foreach (FileInfo item in dirInfo.GetFiles())
                {
                    renamer.rename(item.FullName);
                }

                Console.WriteLine("{0} files were renamed!", dirInfo.GetFiles().Length);
            }
        }
    }

    class Renamer
    {
        public void rename(String fullname)
        {
            try
            {
                String address = Path.GetDirectoryName(fullname);
                String name = Path.GetFileNameWithoutExtension(fullname);
                String ext = Path.GetExtension(fullname);

                try
                {
                    String s = name.Substring(name.IndexOf("_") + 1);
                    int index = int.Parse(name.Substring(name.IndexOf("_") + 1));
                    String label = name.Substring(0, name.IndexOf("_"));

                    String oldName = name + ext;
                    String newName = speakerTable[label] + "-word-" + wordTable[index - 1] + "-" + label + ext;

                    File.Move(address + "\\" + oldName, address + "\\" + newName);
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong name format!");
                    return;
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        //k008m_25    heo  teo
        //k009m_21  mayau x 2
        //k010m_02   hearing tane

        private String[] wordTable =
        {
            "tënei",    //01
            "täne",     //02
            "hau",      //03
            "hou",      //04
            "pao",      //05
            "pau",      //06
            "pou",      //07
            "pö",       //08
            "pai",      //09
            "pae",      //10
            "kë",       //11
            "kei",      //12
            "kï",       //13
            "hë",       //14
            "hei",      //15
            "hï",       //16
            "tae",      //17
            "tai",      //18
            "mätao",    //19
            "mätau",    //20
            "mätou",    //21
            "toetoe",   //22
            "toi",      //23
            "hoihoi",   //24
            "hoe",      //25
            "mao",      //26
            "mau",      //27
            "moutere",  //28
            "tü",       //29
            "matiu"     //30
        };

        private Dictionary<String, String> speakerTable = new Dictionary<string, string>()
        {
            { "K004M", "male" },
            { "K005M", "male" },
            { "K006M", "male" },
            { "K007M", "male" },
            { "K008M", "male" },
            { "K009M", "male" },
            { "K010M", "male" },

            { "L1Y01M", "male" },
            { "L1Y02M", "male" },
            { "L1Y03M", "male" },
            { "L1Y04M", "male" },
            { "L1Y05M", "male" },

            { "L1H01M", "female" },
            { "L1H02M", "female" },
            { "L1H03M", "female" },
            { "L1H04M", "female" },
            { "L1H05M", "female" },
            { "L1H06M", "female" },

            { "R001M", "female" },
            { "R002M", "female" },
            { "R003M", "female" },
            { "R004M", "female" },
            { "R005M", "female" },
            { "R006M", "female" },
            { "R007M", "female" },
            { "R008M", "female" }
        };
    }
}
