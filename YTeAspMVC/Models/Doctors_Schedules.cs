using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YTeAspMVC.Models
{
    public class Doctors_Schedules
    {
        [Key]
        public int Id { get; set; }
        public int IdDoctor { get; set; }
        public int IdSpecialist { get; set; }
        public int IdSchedules { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        public string FullName { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        public string Describe { get; set; }
        public int Status { get; set; }
        public string Date { get; set; }
        public int Timetype { get; set; }
        //public virtual ICollection<Doctor> Doctors { get; set; }
        //public virtual ICollection<Schedules> Schedules { get; set; }

    }
}