using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YTeAspMVC.Models
{
    public class Clinic
    {
        [Key]
        public int IdClinic { get; set; }
        public string NameClinic { get; set; }
        public string Image { get; set; }
        public string DescriptionHTML { get; set; }
        public string Address { get; set; }
        public string CityAddress { get; set; }
    }
}