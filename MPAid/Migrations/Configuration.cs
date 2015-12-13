namespace MPAid.Migrations
{
    using Cores;
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
                NamePaser paser = new NamePaser();
                foreach(FileInfo item in dirInfo.GetFiles().Where(x => x.FullName.Contains("vowel")))
                {
                    paser.SingleFile = item.FullName;

                    context.AddOrUpdateRecordingFile(paser.SingleFile);
                }
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp);
            }
        }
    }
}
