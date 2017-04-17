namespace MuskokaCamp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("payment")]
    public partial class payment
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string date { get; set; }

        [Required]
        [StringLength(50)]
        public string amount { get; set; }

        [Required]
        [StringLength(50)]
        public string payment_type { get; set; }

        public int camperID { get; set; }

        public virtual camperProfile camperProfile { get; set; }
    }
}
