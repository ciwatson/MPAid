using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MPAid.Cores
{
    [Serializable]
    public class SysCfg : ISerializable
    {
        public SysCfg()
        { }
        public SysCfg(string path)
        {
            this.filePath = path;
        }
        #region Serialization Control
        protected SysCfg(SerializationInfo info, StreamingContext context)
        {
            if (info == null) { throw new System.ArgumentNullException("info"); }
            this.audioFolderAddr = info.GetString("recording folder address");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) { throw new System.ArgumentNullException("info"); }
            info.AddValue("recording folder address", this.audioFolderAddr);
        }
        #endregion

        [NonSerialized]
        private String filePath;
        [NonSerialized]
        public static readonly String path = "./SystemConfig.ini";

        private String audioFolderAddr;
        public String AudioFolderAddr
        {
            get
            {
                //by default, the url is ./Audio
                audioFolderAddr = audioFolderAddr == null ? System.Windows.Forms.Application.StartupPath + @"\Audio" : audioFolderAddr;
                System.IO.Directory.CreateDirectory(audioFolderAddr);
                return audioFolderAddr;
            }
            set
            {
                audioFolderAddr = value;
                System.IO.Directory.CreateDirectory(audioFolderAddr);
            }
        }

        private String videoFolderAddr;
        public String VideoFolderAddr
        {
            get
            {
                //by default, the url is ./Video
                videoFolderAddr = videoFolderAddr == null ? System.Windows.Forms.Application.StartupPath + @"\Video" : videoFolderAddr;
                System.IO.Directory.CreateDirectory(videoFolderAddr);
                return videoFolderAddr;
            }
            set
            {
                videoFolderAddr = value;
                System.IO.Directory.CreateDirectory(videoFolderAddr);
            }
        }
    }
}
