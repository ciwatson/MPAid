﻿namespace MPAid.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SingleFile")]
    public partial class SingleFile
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SingleFileId { get; set; }

        [Required]
        [StringLength(64)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string Address { get; set; }

        public virtual Recording Audio { get; set; }
        public virtual Recording Video { get; set; }
    }
}
