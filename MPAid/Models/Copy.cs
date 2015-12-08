namespace MPAid.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Copy")]
    public partial class Copy
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CopyId { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        public int RecordingId { get; set; }
        [ForeignKey("RecordingId")]
        public virtual Recording Recording { get; set; }

        public int SingleFileId { get; set; }
        [ForeignKey("SingleFileId")]
        public virtual SingleFile SingleFile { get; set; }
    }
}
