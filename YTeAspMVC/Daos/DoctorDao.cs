using YTeAspMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Helpers;
using System.Web.Razor.Tokenizer.Symbols;

namespace YTeAspMVC.Daos
{
    public class DoctorDao
    {
        YTeDBContext myDb = new YTeDBContext();

        public List<Doctor> GetAll()
        {
            return myDb.Doctors.ToList();
        }
        public List<Doctors_Schedules> GetAllDoctor()
        {
            return myDb.Doctors_Schedules.ToList();
        }
        public List<Doctor> Search(string keyword)
        {
            return myDb.Doctors.Where(x => x.FullName.Contains(keyword)).ToList();
        }
        public List<Doctor> GetListByIdSpecialist(int id)
        {
            var query = from doctor in myDb.Doctors
                        join specialist in myDb.Specialists on doctor.IdSpecialist equals specialist.IdSpecialist
                        where doctor.IdSpecialist == id
                        select doctor;

            var test = query.ToList();
            return test;
        }
        //public List<Specialist> GetListSpecialistbyIdDoctor(int id)
        //{
        //var query = from doctor in myDb.Doctors
        //            join specialist in myDb.Specialists on doctor.IdSpecialist equals specialist.IdSpecialist
        //            where specialist.IdSpecialist == id
        //            select specialist;

        //var test = query.ToList();
        //    return test;

        //}

        //public List<Schedules> GetListByIdSchedules(int id)
        //{
        //    var query = from doctor in myDb.Doctors
        //                join schedule in myDb.Schedule on doctor.IdSchedules equals schedule.IdSchedules
        //                where doctor.IdSchedules == id
        //                select schedule;

        //    var test = query.ToList();
        //    return test;
        //}

        public List<Schedules> GetListSchedulesbyIdDoctor(int id)
        {
            var a = myDb.Doctors
                    .Where(d => d.IdDoctor == id)
                    .Join(
                        myDb.Schedule,
                        doctor => doctor.IdDoctor,
                        schedule => schedule.IdDoctor,
                        (doctor, schedule) => schedule
                    )
                    .GroupBy(d => d.Date)
                    .Select(group => group.FirstOrDefault());
                
            var test = a.ToList();
            return test;

        }

        public List<Schedules> ChangesDate(int id, string date)
        {
            var a = from schedule in myDb.Schedule
                    where (schedule.IdDoctor == id && schedule.Date == date)
                    select schedule;
            var test = a.ToList();
            return test;
        }

        public List<string> GetListSchedulesbyDate(int id, string date)
        {
            var query = myDb.Schedule
                        .Where(s => s.IdDoctor == id && s.Date == date)
                        .Select(s => s.Timetype);

            var test = query.ToList();
            return test;
        }

        public void Add(Doctor doctor)
        {
            myDb.Doctors.Add(doctor);
            myDb.SaveChanges();
        }
        public void DeleteSchedules(int IdSchedules)
        {
            var schedules = myDb.Schedule.FirstOrDefault(x => x.IdSchedules == IdSchedules);
            myDb.Schedule.Remove(schedules);
            myDb.SaveChanges();
        }
        public void Update(Doctor doctor)
        {
            var obj = myDb.Doctors.FirstOrDefault(x => x.IdDoctor == doctor.IdDoctor);
            obj.Email = doctor.Email;
            obj.FullName = doctor.FullName;
            obj.Password = doctor.Password;
            obj.IdSpecialist = doctor.IdSpecialist;
            obj.Describe = doctor.Describe;
            obj.Image = doctor.Image;
            myDb.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = myDb.Doctors.FirstOrDefault(x => x.IdDoctor == id);
            myDb.Doctors.Remove(obj);
            myDb.SaveChanges();
        }

        public bool checkLogin(string email, string password)
        {
            var obj = myDb.Doctors.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (obj == null) { return false; }
            return true;
        }

        public Doctor getUserByEmail(string email)
        {
            return myDb.Doctors.FirstOrDefault(x => x.Email.Equals(email));
        }
        public Doctor GetDoctorByID(int id)
        {
            return myDb.Doctors.FirstOrDefault(x => x.IdDoctor == id);
        }
        public Doctor getDoctor(int id)
        {
            return myDb.Doctors.FirstOrDefault(x => x.IdDoctor == id);
        }
        public List<Doctor> GetTop3()
        {
            return myDb.Doctors.OrderByDescending(x => x.IdDoctor).Take(3).ToList();
        }
    }
}