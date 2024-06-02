namespace YTeAspMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Number
    {
        [Key]
        public int IdNumber { get; set; }

        public int NumberInt { get; set; }

        public string Day { get; set; }

        public int IdUser { get; set; }

        public virtual User User { get; set; }
    }
}
