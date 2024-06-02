using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YTeAspMVC.Models
{
    [Table("Schedules")]
    public class Schedules
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSchedules { get; set; }
        public string Date { get; set; }
        public string Timetype { get; set; }
        public int IdDoctor { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}