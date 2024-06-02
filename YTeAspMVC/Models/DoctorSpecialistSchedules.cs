using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YTeAspMVC.Models
{
    [Table("DoctorSpecialistSchedules")]
    public class DoctorSpecialistSchedules
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdDoctor { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Date { get; set; }
        public int Timetype { get; set; }
        public string NameSpecialist { get; set; }
    }
}