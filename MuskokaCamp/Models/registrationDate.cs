namespace MuskokaCamp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class registrationDate
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string date { get; set; }

        [StringLength(255)]
        public string signInTime { get; set; }

        [StringLength(255)]
        public string signOutTime { get; set; }

        [StringLength(255)]
        public string signedInBy { get; set; }

        [StringLength(255)]
        public string signedOutBy { get; set; }

        public int camperID { get; set; }

        public virtual camperProfile camperProfile { get; set; }
    }
}
