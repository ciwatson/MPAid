namespace MPAid.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Recording")]
    public partial class Recording
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecordingId { get; set; }

        [Required]
        [StringLength(256)]
        public string Address { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        public int SpeakerId { get; set; }
        [ForeignKey("SpeakerId")]
        public virtual Speaker Speaker { get; set; }

        public int WordId { get; set; }
        [ForeignKey("WordId")]
        public virtual Word Word { get; set; }
    }
}
