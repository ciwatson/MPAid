using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MPAid
{
    class MaoriObj
    {
        public string Name;
        public string SoundFilePath;
        public int WordSoundId;

        public Image DefaultImage;
        public ImageList AnimationImages;

        public override string ToString()
        {
            return Name;
        }
    }
}
