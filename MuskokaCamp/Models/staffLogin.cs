namespace MuskokaCamp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("staffLogin")]
    public partial class staffLogin
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string userName { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(255)]
        public string password { get; set; }
    }
}
