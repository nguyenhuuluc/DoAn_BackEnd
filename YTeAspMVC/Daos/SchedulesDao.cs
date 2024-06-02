using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YTeAspMVC.Models;

namespace YTeAspMVC.Daos
{
    public class SchedulesDao
    {
        YTeDBContext myDb = new YTeDBContext();
        public List<Schedules> GetAll()
        {
            return myDb.Schedule.ToList();
        }
        public void Add(Schedules schedules)
        {
            myDb.Schedule.Add(schedules);
            myDb.SaveChanges();
        }
    }
}