namespace YTeAspMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Specialist")]
    public partial class Specialist
    {
        //public Specialist()
        //{
        //    Doctors = new HashSet<Doctor>();
        //}
        [Key]
        public int IdSpecialist { get; set; }

        public string NameSpecialist { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        //public int CountId { get; set; }
        public List<Doctor> Doctor { get; set; }
    }
}
