using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YTeAspMVC.Models;

namespace YTeAspMVC.Daos
{
    public class SpecialistDao
    {
        YTeDBContext myDb = new YTeDBContext();
        public List<Specialist> GetAll()
        {
            return myDb.Specialists.ToList();
        }
        public void Add(Specialist specialit)
        {
            myDb.Specialists.Add(specialit);
            myDb.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = myDb.Specialists.FirstOrDefault(x => x.IdSpecialist == id);
            myDb.Specialists.Remove(obj);
            myDb.SaveChanges();
        }
        public void Update(Specialist specialist)
        {
            var obj = myDb.Specialists.FirstOrDefault(x => x.IdSpecialist == specialist.IdSpecialist);
            obj.NameSpecialist = specialist.NameSpecialist;
            obj.Description = specialist.Description;
            obj.Image = specialist.Image;
            myDb.SaveChanges();
        }
        public List<Specialist> GetListByName(string keyword)
        {
            return myDb.Specialists.Where(x => x.NameSpecialist.Contains(keyword)).ToList();
        }
        public Specialist GetSpecialistOrderByID(int id)
        {
            return myDb.Specialists.FirstOrDefault(x => x.IdSpecialist == id);
        }
        public List<Specialist> GetListSpecialist(int id)
        {
            var a = myDb.Doctors
                    .Where(d => d.IdSpecialist == id)
                    .Join(
                        myDb.Specialists,
                        doctor => doctor.IdSpecialist,
                        specialit => specialit.IdSpecialist,
                        (doctor, schedule) => schedule
                    )
                    .GroupBy(d => d.NameSpecialist)
                    .Select(group => group.FirstOrDefault());

            var test = a.ToList();
            return test;
        }
        //public List<int> GetCountDoctor(int id)
        //{
        //    var count =  myDb.Doctors
        //    .GroupBy(d => d.IdSpecialist == id)
        //    .Select(group => new
        //    {
        //        IdSpecialist = group.Key,
        //        Count = group.Count()
        //    })
        //    .ToList();

        //    return count;
        //}
        public List<Doctor> GetSpecialistsById(int id)
        {
            var query = from doctor in myDb.Doctors
                        join specialist in myDb.Specialists on doctor.IdSpecialist equals specialist.IdSpecialist
                        where doctor.IdSpecialist == id
                        select doctor;

            return query.ToList() ;
        }
    }
}