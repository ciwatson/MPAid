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
            //AppDomain.CurrentDomain.SetData("DataDirectory", System.Windows.Forms.Application.StartupPath);
            AppDomain.CurrentDomain.SetData("DataDirectory", @"\\engad.foe.auckland.ac.nz\engdfs\Home\syu702\Documents\Visual Studio 2015\Projects\MPAid\MPAid\App_Data");
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Recording> Recording { get; set; }
        public virtual DbSet<Speaker> Speaker { get; set; }
        public virtual DbSet<Word> Word { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
