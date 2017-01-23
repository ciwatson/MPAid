namespace MPAi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Migrations;
    using Cores;
    using System.Runtime.Remoting.Contexts;
    using System.IO;
    /// <summary>
    /// Class handling the persistence contexts and object persistence for MPAi.
    /// </summary>
    public partial class MPAiModel : DbContext
    {
        /// <summary>
        /// Default constructor.
        /// Sets the domain for the data base to work inside, that specified in the AppDataPath class, and initialises the database.
        /// </summary>
        public MPAiModel()
            : base("name=MPAiModel")
        {
            // Deprecated: The AppDataPath class holds this value, making it easier to change.
            //AppDomain.CurrentDomain.SetData("DataDirectory", System.Windows.Forms.Application.StartupPath + @"\App_Data");
            if (!Directory.Exists(Path.Combine(AppDataPath.Path, "Database")))
            {
                Directory.CreateDirectory(Path.Combine(AppDataPath.Path, "Database"));
            }
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(AppDataPath.Path, "Database"));

            Database.SetInitializer<MPAiModel>(new MPAiModelInitializer());
        }
        //Variables representing the set of values taken out of the database.
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Recording> Recording { get; set; }
        public virtual DbSet<Speaker> Speaker { get; set; }
        public virtual DbSet<Word> Word { get; set; }
        public virtual DbSet<SingleFile> SingleFile { get; set; }

        public static MPAiModel InitializeDBModel()
        {
            MPAiModel DBModel;
            DBModel = new MPAiModel();
            DBModel.Database.Initialize(false);
            DBModel.Recording.Load();
            DBModel.Speaker.Load();
            DBModel.Category.Load();
            DBModel.Word.Load();
            DBModel.SingleFile.Load();
            return DBModel;
        }

        public bool IsSpeakerString(string str)
        {
            foreach(Speaker speaker in Speaker)
            {
                if(str.Equals(speaker.Name))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCategoryString(string str)
        {
            foreach (Category category in Category)
            {
                if (str.Equals(category.Name))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsWordString(string str)
        {
            foreach (Word word in Word)
            {
                if (str.Equals(word.Name))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Override used to configure some database settings before the database is linked to the context object.
        /// Relations between classes and the nature of such relations are defined here,
        /// as well as which fields are to be used as foreign keys.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the database model being used to create a persistence context.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Deprecated: The code no longer uses separate video and audio recording classes.

            //modelBuilder.Entity<AudioRecording>()
            //    .HasMany(a => a.Audio)
            //    .WithRequired(c => c.Audio)
            //    .Map(m => m.MapKey("AudioId"));

            //modelBuilder.Entity<VideoRecording>()
            //    .HasOptional(v => v.Video)
            //    .WithOptionalDependent(c => c.Video)
            //    .Map(m => m.MapKey("VideoId"));

            modelBuilder.Entity<Recording>()
                .HasMany(r => r.Audios)
                .WithOptional(s => s.Audio)
                .Map(m => m.MapKey("AudioId"));

            modelBuilder.Entity<Recording>()
                .HasOptional(r => r.Video)
                .WithOptionalDependent(s => s.Video)
                .Map(m => m.MapKey("VideoId"));
         
            base.OnModelCreating(modelBuilder); // Continues creating the persistence context.
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordingFile"></param>
        public void AddOrUpdateRecordingFile(String recordingFile)
        {
            try
            {
                NameParser paser = new NameParser();
                paser.SingleFile = recordingFile;
                // Should only be one speaker per recording.
                Speaker spk = this.Speaker.SingleOrDefault(x => x.Name == paser.Speaker);
                // Handle the case where the file has no speaker set, by creating and adding one from the file name.
                if (spk == null)
                {
                    spk = new Speaker()
                    {
                        Name = paser.Speaker
                    };
                    this.Speaker.AddOrUpdate(x => x.Name, spk);
                    this.SaveChanges();
                }
                // Should only be one category per recording.
                Category cty = this.Category.SingleOrDefault(x => x.Name == paser.Category);
                //Handle the case where the file has no category set, by creating and adding one from the file name.
                if (cty == null)
                {
                    cty = new Category()
                    {
                        Name = paser.Category
                    };
                    this.Category.AddOrUpdate(x => x.Name, cty);
                    this.SaveChanges();
                }
                // Should only be one word per recording.
                Word word = this.Word.SingleOrDefault(x => x.Name == paser.Word);
                // Handle the case where the file has no word set, by creating and adding one from the file name and category.
                // The category has been created above if it did not already exist.
                if (word == null)
                {
                    word = new Word()
                    {
                        Name = paser.Word,
                        CategoryId = cty.CategoryId
                    };
                    this.Word.AddOrUpdate(x => x.Name, word);
                    this.SaveChanges();
                }
                // Should only be one recording per recording object.
                Recording rd = this.Recording.SingleOrDefault(x => x.Name == paser.Recording); ;
                // Handle the case where a recording has no associated entry, by creating and adding one from the file name, speaker and word.
                // The speaker and word have been created above if they did not already exist.
                if (rd == null)
                {
                    rd = new Recording()
                    {
                        Name = paser.Recording,
                        SpeakerId = spk.SpeakerId,
                        WordId = word.WordId
                    };
                    this.Recording.AddOrUpdate(x => x.Name, rd);
                    this.SaveChanges();
                }
                // Should have a single file for each recording. 
                SingleFile sf = this.SingleFile.SingleOrDefault(x => x.Name == paser.FullName);
                // Handle the case where there is no file, by creating a filename from the path in the name, 
                // and associating it with an audio or video recording (created above if they did not already exist) based on it's file type.
                if (sf == null)
                {
                    sf = new SingleFile()
                    {
                        Name = paser.FullName,
                        Address = paser.Address,
                    };
                    if (paser.MediaFormat == "audio")
                    {
                        sf.Audio = rd;
                    }
                    else if (paser.MediaFormat == "video")
                    {
                        sf.Video = rd;
                    }
                    this.SingleFile.AddOrUpdate(x => x.Name, sf);
                    this.SaveChanges();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }
    }
    /// <summary>
    /// Implementation of a database context initialiser that sets up a database based on the files in the Audio folder. 
    /// </summary>
    public class MPAiModelInitializer : CreateDatabaseIfNotExists<MPAiModel>
    {
        /// <summary>
        /// If the database doesn't exist, it is created.
        /// If it does exist, and the Audio folder a) exists and b) contains at least one .wav file, then
        /// Each .wav file is added to the database, or updated if it is already in the database. 
        /// </summary>
        /// <param name="context">The current MPAiModel object representing the persistence context.</param>
        protected override void Seed(MPAiModel context)
        {
            if(Directory.Exists(DirectoryManagement.AudioFolder))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(DirectoryManagement.AudioFolder);
                foreach(FileInfo fInfo in dirInfo.GetFiles("*.wav", SearchOption.AllDirectories))   // Also searches subdirectories.
                {
                    if(fInfo.Extension.Contains("wav"))
                    {
                        context.AddOrUpdateRecordingFile(Path.Combine(fInfo.DirectoryName, fInfo.FullName));
                    }
                }
            }
            if (Directory.Exists(DirectoryManagement.VideoFolder))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(DirectoryManagement.VideoFolder);
                foreach (FileInfo fInfo in dirInfo.GetFiles("*.mp4", SearchOption.AllDirectories))   // Also searches subdirectories.
                {
                    if (fInfo.Extension.Contains("mp4"))
                    {
                        context.AddOrUpdateRecordingFile(Path.Combine(fInfo.DirectoryName, fInfo.FullName));
                    }
                }
            }
            base.Seed(context); // Does nothing. There is no Audio folder, so nothing to add or update.
        }
    }
}
