namespace MPAid.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Speaker")]
    public partial class Speaker
    {
        public Speaker()
        {
            Recordings = new HashSet<Recording>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpeakerId { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        public virtual ICollection<Recording> Recordings { get; set; }
    }
}
