using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MPAid.Cores
{
    class NamePaser
    {
        public string SingleFile
        {
            get { return Address + @"\" + FullName; }
            set
            {
                try
                {
                    Address = Path.GetDirectoryName(value);
                    FullName = Path.GetFileName(value);
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp);
                }
            }
        }

        public string FullName
        {
            get
            {
                return FileName + Ext;
            }
            set
            {
                try
                {
                    FileName = Path.GetFileNameWithoutExtension(value);
                    Ext = Path.GetExtension(value);
                }
                catch(Exception exp)
                {
                    Console.WriteLine(exp);
                }   
            }
        }
        public string FileName
        {
            get { return Recording + @"-" + Label; }
            set
            {
                try
                {
                    string[] parts = value.Split('-');
                    if(parts.Length != 4) { throw new Exception("Invilad name format!"); }
                    Speaker = parts[0];
                    Category = parts[1];
                    Word = parts[2];
                    Label = parts[3];
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

        public string Address
        {
            get { return address; }
            set { address = value; }
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

        public string Label
        {
            get { return label; }
            set { label = value; }
        }

        public string Ext
        {
            get { return ext; }
            set { ext = value; }
        }

        public string MediaFormat
        {
            get
            {
                if (audioExtsTable.Contains(ext))
                {
                    return "audio";
                }
                else if (videoExtsTable.Contains(ext))
                {
                    return "video";
                }
                return "unknow";
            }
        }

        private string[] videoExtsTable =
        {
            ".mp4",
            ".avi"
        };

        private string[] audioExtsTable =
        {
            ".wav",
            ".mp3"
        };

        private string address;
        private string speaker;
        private string category;
        private string word;
        private string label;
        private string ext;
    }
}
