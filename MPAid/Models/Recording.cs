namespace MPAid.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Recording")]
    public partial class Recording
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        public virtual Speaker Speaker { get; set; }
        public virtual Word Word { get; set; }
    }
}
