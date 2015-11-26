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
        }

        public virtual DbSet<Speaker> Speaker { get; set; }
        public virtual DbSet<Recording> Recording { get; set; }
        public virtual DbSet<Word> Word { get; set; }
        public virtual DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
