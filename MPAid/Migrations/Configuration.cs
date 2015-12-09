namespace MPAid.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MPAid.Models.MPAidModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MPAid.Models.MPAidModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            try
            {
                String dirPath = @".\Recordings";
                DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
                Modules.NamePaser paser = new Modules.NamePaser();
                foreach(FileInfo item in dirInfo.GetFiles().Where(x => x.FullName.Contains("vowel")))
                {
                    paser.SingleFile = item.FullName;

                    context.AddOrUpdateRecordingFile(paser.SingleFile);
                }
                //Models.Category cty = new Models.Category() { Name = "vowel" };
                //Models.Speaker spk = new Models.Speaker() { Name = "male" };
                //List<Models.Word> words = new List<Models.Word>()
                //{
                //    new Models.Word() { Name = "a", Category = cty },
                //    new Models.Word() { Name = "ae", Category = cty }
                //};

                //List<Models.Recording> rdgs = new List<Models.Recording>();
                //foreach(Models.Word word in words)
                //{
                //    Modules.NamePaser paser = new Modules.NamePaser;
                //    paser.Category = cty.Name;
                //    paser.Speaker = spk.Name;
                //    rdgs.Add(new Models.Recording() {Name =  });
                //}
                //context.Category.AddOrUpdate(x => x.Name, cty);

                //context.Word.AddOrUpdate(x => x.Name, word_list.ToArray());

                //context.Speaker.AddOrUpdate(x => x.Name, spk);

                //context.Recording.AddOrUpdate(x => x.Name, 
                //    new Models.Recording() { }
                //    );
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp);
            }
        }
    }
}
