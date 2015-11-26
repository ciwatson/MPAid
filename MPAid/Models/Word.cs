namespace MPAid.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Word")]
    public partial class Word
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        public virtual ICollection<Recording> Recordings { get; set; }
        public virtual Category Category { get; set; }
    }
}
