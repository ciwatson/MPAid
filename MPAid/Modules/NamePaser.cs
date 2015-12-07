using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAid.Modules
{
    class NamePaser
    {
        public string SingleFile
        {
            get { return Name + "." + Ext; }
            set
            {
                try
                {
                    string[] parts = value.Split('.');
                    if (parts.Length != 2) { throw new Exception("Invilad file name!"); }
                    Name = parts[0];
                    Ext = parts[1];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public string Name
        {
            get { return Recording + "-" + Copy; }
            set
            {
                try
                {
                    string[] parts = value.Split('-');
                    if(parts.Length != 4) { throw new Exception("Invilad name format!"); }
                    Speaker = parts[0];
                    Category = parts[1];
                    Word = parts[2];
                    copy = parts[3];
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public string Recording
        {
            get { return Speaker + "-" + Category + "-" + Word; }
        }

        public string Speaker
        {
            get { return speaker; }
            set { speaker = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public string Word
        {
            get { return word; }
            set { word = value; }
        }

        public string Copy
        {
            get { return copy; }
            set { copy = value; }
        }

        public string Ext
        {
            get { return ext; }
            set { ext = value; }
        }
        private string speaker;
        private string category;
        private string word;
        private string copy;
        private string ext;
    }
}
