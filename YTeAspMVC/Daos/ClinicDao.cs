using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YTeAspMVC.Models;

namespace YTeAspMVC.Daos
{
    public class ClinicDao
    {
        YTeDBContext myDb = new YTeDBContext();
        public List<Clinic> GetAll()
        {
            return myDb.Clinic.ToList();
        }
    }
}