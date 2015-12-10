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
            this.recordingFolderAddr = info.GetString("recording folder address");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) { throw new System.ArgumentNullException("info"); }
            info.AddValue("recording folder address", this.recordingFolderAddr);
        }
        #endregion

        [NonSerialized]
        private String filePath;
        [NonSerialized]
        public static readonly String path = "./SystemConfig.ini";

        private String recordingFolderAddr;
        public String RecordingFolderAddr
        {
            get
            {
                //by default, the url is ./Recordings
                return recordingFolderAddr == null ? System.Windows.Forms.Application.StartupPath + @"\Recordings" : recordingFolderAddr;
            }
            set
            {
                recordingFolderAddr = value;
            }
        }
    }
}
