using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MPAid.Cores
{
    static class SystemConfigration
    {
        static public SysCfg configs = Serializer<SysCfg>.Load<BinaryFormatter>(SysCfg.path);
    }

    [Serializable]
    public class SysCfg : ISerializable
    {
        public SysCfg()
        {
            audioFolderAddr = new FolderAddress("Audio");
            videoFolderAddr = new FolderAddress("Video");
            recordingFolderAddr = new FolderAddress("Recording");
            reportFolderAddr = new FolderAddress("Report");
            htkFolderAddr = new FolderAddress("HTK");
            fomantFolderAddr = new FolderAddress("Fomant");
        }
        public SysCfg(string path)
            : this()
        {
            this.filePath = path;
        }
        #region Serialization Control
        protected SysCfg(SerializationInfo info, StreamingContext context)
        {
            if (info == null) { throw new System.ArgumentNullException("info"); }
            this.audioFolderAddr = info.GetValue("Audio Recording Folder Address", typeof(FolderAddress)) as FolderAddress;
            this.videoFolderAddr = info.GetValue("Video Recording Folder Address", typeof(FolderAddress)) as FolderAddress;
            this.recordingFolderAddr = info.GetValue("Personal Recording Folder Address", typeof(FolderAddress)) as FolderAddress;
            this.reportFolderAddr = info.GetValue("Personal Report Folder Address", typeof(FolderAddress)) as FolderAddress;
            this.htkFolderAddr = info.GetValue("HTK Folder Address", typeof(FolderAddress)) as FolderAddress;
            this.fomantFolderAddr = info.GetValue("Fomant Slot Folder Address", typeof(FolderAddress)) as FolderAddress;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) { throw new System.ArgumentNullException("info"); }
            info.AddValue("Audio Recording Folder Address", this.audioFolderAddr);
            info.AddValue("Video Recording Folder Address", this.videoFolderAddr);
            info.AddValue("Personal Recording Folder Address", this.recordingFolderAddr);
            info.AddValue("Personal Report Folder Address", this.reportFolderAddr);
            info.AddValue("HTK Folder Address", this.htkFolderAddr);
            info.AddValue("Fomant Slot Folder Address", this.fomantFolderAddr);
        }
        #endregion

        [NonSerialized]
        private String filePath;
        [NonSerialized]
        public static readonly String path = "./SystemConfig.ini";

        private FolderAddress audioFolderAddr;
        public FolderAddress AudioFolderAddr
        {
            get {return audioFolderAddr; }
            set{ audioFolderAddr = value; }
        }

        private FolderAddress videoFolderAddr;
        public FolderAddress VideoFolderAddr
        {
            get{return videoFolderAddr;}
            set {videoFolderAddr = value;}
        }

        private FolderAddress recordingFolderAddr;
        public FolderAddress RecordingFolderAddr
        {
            get { return recordingFolderAddr; }
            set { recordingFolderAddr = value; }
        }

        private FolderAddress reportFolderAddr;
        public FolderAddress ReportFolderAddr
        {
            get { return reportFolderAddr; }
            set { reportFolderAddr = value; }
        }

        private FolderAddress htkFolderAddr;
        public FolderAddress HTKFolderAddr
        {
            get { return htkFolderAddr; }
            set { htkFolderAddr = value; }
        }
        private FolderAddress fomantFolderAddr;
        public FolderAddress FomantFolderAddr
        {
            get { return fomantFolderAddr; }
            set { fomantFolderAddr = value; }
        }
    }

    [Serializable]
    public class FolderAddress : ISerializable
    {
        public FolderAddress()
        {}

        public FolderAddress(String subFolder)
            : this()
        {
            this.subFolder = subFolder;
        }

        #region Serialization Control
        protected FolderAddress(SerializationInfo info, StreamingContext context)
        {
            if (info == null) { throw new System.ArgumentNullException("info"); }
            this.baseFolder = info.GetString("Base Folder Address");
            this.subFolder = info.GetString("Sub Folder Address");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) { throw new System.ArgumentNullException("info"); }
            info.AddValue("Base Folder Address", this.baseFolder);
            info.AddValue("Sub Folder Address", this.subFolder);
        }
        #endregion

        private String baseFolder;
        public String BaseFolder
        {
            get { return string.IsNullOrEmpty(baseFolder) ? System.Windows.Forms.Application.StartupPath : baseFolder; }
            set { baseFolder = value; }
        }

        private String subFolder;
        public String SubFolder
        {
            get { return subFolder; }
            set { subFolder = value; }
        }

        private String folderAddr;
        public String FolderAddr
        {
            get
            {
                folderAddr = string.IsNullOrEmpty(folderAddr) ? Path.Combine(BaseFolder, SubFolder) : folderAddr;
                System.IO.Directory.CreateDirectory(folderAddr);
                return folderAddr;
            }
            set
            {
                folderAddr = value;
            }
        }
    }
}
