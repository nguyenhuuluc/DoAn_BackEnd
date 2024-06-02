namespace YTeAspMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking
    {
        [Key]
        public int IdBooking { get; set; }

        [StringLength(255)]
        public string Day { get; set; }

        [StringLength(255)]
        public string Time { get; set; }

        [StringLength(255)]
        public string Reason { get; set; }

        public int Status { get; set; }

        public int IdUser { get; set; }

        public int IdDoctor { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual User User { get; set; }
    }
}
