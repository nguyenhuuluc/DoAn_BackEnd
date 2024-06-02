namespace YTeAspMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class Doctor
    {
        public Doctor()
        {
            Bookings = new HashSet<Booking>();
        }

        [Key]
        public int IdDoctor { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        public string FullName { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        public int IdSpecialist { get; set; }
        public int IdClinic { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        public string Describe { get; set; }
        public string DescribeHTMl { get; set; }
        public int Status { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public List<Specialist> Specialist { get; set; }
        public List<Schedules> Schedules { get; set; }
    }
}
