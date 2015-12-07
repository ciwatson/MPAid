namespace MPAid.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MPAidModel : DbContext
    {
        public MPAidModel()
            : base("name=MPAidModel")
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.Windows.Forms.Application.StartupPath + @"\App_Data");
            //AppDomain.CurrentDomain.SetData("DataDirectory", @"D:\Projects\MPAid\MPAid\App_Data");
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Recording> Recording { get; set; }
        public virtual DbSet<Speaker> Speaker { get; set; }
        public virtual DbSet<Word> Word { get; set; }
        public virtual DbSet<Copy> Copy { get; set; }
        public virtual DbSet<SingleFile> SingleFile { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
