using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MPAid
{
    class DataManager
    {
        public void WriteSettings(string fileName)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                //int n = 10;
                //writer.Write(10);
                //for (int i = 0; i < n; i++)
                //{
                //    writer.Write(i + 55);
                //}
            }
        }

        public void ReadSettings(string fileName)
        {

            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    int n = reader.ReadInt32();
                    for (int i = 0; i < n; i++)
                    {

                        Console.WriteLine(reader.ReadInt32());
                    }

                }

                Console.ReadLine();
            }
        }

    }
}
