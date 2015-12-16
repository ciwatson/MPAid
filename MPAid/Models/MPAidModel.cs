namespace MPAid.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Migrations;
    using Cores;
    public partial class MPAidModel : DbContext
    {
        public MPAidModel()
            : base("name=MPAidModel")
        {
            //AppDomain.CurrentDomain.SetData("DataDirectory", System.Windows.Forms.Application.StartupPath + @"\App_Data");
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDataPath.path);
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Recording> Recording { get; set; }
        public virtual DbSet<Speaker> Speaker { get; set; }
        public virtual DbSet<Word> Word { get; set; }
        public virtual DbSet<SingleFile> SingleFile { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
         
            base.OnModelCreating(modelBuilder);
        }

        public void AddOrUpdateRecordingFile(String recordingFile)
        {
            try
            {
                NamePaser paser = new NamePaser();
                paser.SingleFile = recordingFile;

                Speaker spk = this.Speaker.SingleOrDefault(x => x.Name == paser.Speaker);
                if (spk == null)
                {
                    spk = new Speaker()
                    {
                        Name = paser.Speaker
                    };
                    this.Speaker.AddOrUpdate(x => x.Name, spk);
                    this.SaveChanges();
                }

                Category cty = this.Category.SingleOrDefault(x => x.Name == paser.Category);
                if (cty == null)
                {
                    cty = new Category()
                    {
                        Name = paser.Category
                    };
                    this.Category.AddOrUpdate(x => x.Name, cty);
                    this.SaveChanges();
                }

                Word word = this.Word.SingleOrDefault(x => x.Name == paser.Word);
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

                Recording rd = this.Recording.SingleOrDefault(x => x.Name == paser.Recording); ;
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

                SingleFile sf = this.SingleFile.SingleOrDefault(x => x.Name == paser.FullName);
                if (sf == null)
                {
                    sf = new SingleFile()
                    {
                        Name = paser.FullName,
                        Address = paser.Address,
                    };

                    //this.SingleFile.AddOrUpdate(x => x.Name, sf);
                    //this.SaveChanges();
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
}
