using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YTeAspMVC.Daos;
using YTeAspMVC.Models;
using YTeAspMVC.Request;

namespace YTeAspMVC.Controllers
{
    public class DoctorController : Controller
    {
        DoctorDao doctorDao = new DoctorDao(); 
        SpecialistDao specialistDao = new SpecialistDao();
        SchedulesDao scheduleDao = new SchedulesDao();
        // GET: Doctor
        public ActionResult Index(FormCollection form)
        {
            DateTime aDateTime = DateTime.Now;
            ViewBag.CurrentDate = aDateTime.Year + "-" + aDateTime.Month + "-" + aDateTime.Day;
            var keyword = form["namedoctor"];
            ViewBag.List = String.IsNullOrEmpty(keyword) ? doctorDao.GetAll() : doctorDao.Search(keyword);
            ViewBag.Specialist = specialistDao.GetAll();
            ViewBag.Schedule = scheduleDao.GetAll();
            Session.Add("Active", "Doctor");
            return View();
        }

        public ActionResult Index2(FormCollection form)
        {
            DateTime aDateTime = DateTime.Now;
            ViewBag.CurrentDate = aDateTime.Year + "-" + aDateTime.Month + "-" + aDateTime.Day;
            var keyword = form["namedoctor"];
            ViewBag.List = String.IsNullOrEmpty(keyword) ? doctorDao.GetAll() : doctorDao.Search(keyword);
            ViewBag.Doctors = doctorDao.GetAll();
            foreach( var doctor in ViewBag.Doctors)
            {
                doctor.Schedules = doctorDao.GetListSchedulesbyIdDoctor(doctor.IdDoctor);
                //doctor.Schedules = doctorDao.ChangesDate(doctor.IdDoctor, doctor.Schedules.Date);
            }
            ViewBag.Specialist = specialistDao.GetAll();
            ViewBag.Schedule = scheduleDao.GetAll();
            Session.Add("Active", "Doctor");
            return View();
        }

        //[Route("Doctor-GetList/{key}")]
        public ActionResult GetList(string id)
        {
            DateTime aDateTime = DateTime.Now;
            ViewBag.CurrentDate = aDateTime.Year + "-" + aDateTime.Month + "-" + aDateTime.Day;
            ViewBag.List = doctorDao.GetListByIdSpecialist(Convert.ToInt32(id));
            ViewBag.Specialist = specialistDao.GetAll();
            ViewBag.Schedule = scheduleDao.GetAll();
            Session.Add("Active", "Doctor");
            return View();
        }
        public ActionResult GetList2(string id)
        {
            YTeDBContext myDb = new YTeDBContext();
            DateTime aDateTime = DateTime.Now;
            ViewBag.CurrentDate = aDateTime.Year + "-" + aDateTime.Month + "-" + aDateTime.Day;
            ViewBag.Doctors = doctorDao.GetListByIdSpecialist(Convert.ToInt32(id));
            foreach (var doctor in ViewBag.Doctors)
            {
                doctor.Schedules = doctorDao.GetListSchedulesbyIdDoctor(doctor.IdDoctor);
                //doctor.Schedules = doctorDao.ChangesDate(doctor.IdDoctor, doctor.Schedules.Date);
            }
            ViewBag.Specialist = specialistDao.GetAll();
            Session.Add("Active", "Doctor");
            return View();
        }

        [HttpPost]
        public ActionResult Add(Schedules schedules)
        {
            scheduleDao.Add(schedules); 
            TempData["message"] = "Đăng ký lịch thành công";
            return RedirectToAction("ScheduleExamination", "AdminDoctor");

            //bool check = bookingDao.CheckExistScheduleInDay(booking.Day, booking.Time, user.IdUser, booking.IdDoctor);
            //if (check)
            //{
            //    booking.IdUser = user.IdUser;
            //    bookingDao.Add(booking);
            //    return RedirectToAction("HistoryBooking", "Authencation", new { mess = "1" });
            //}
            //else
            //{
            //    return RedirectToAction("HistoryBooking", "Authencation", new { mess = "2" });
            //}
        }

        [HttpPost]
        public JsonResult ChangesDate(int id, string date)
        {
            YTeDBContext myDb = new YTeDBContext();
            var query = myDb.Schedule.Where(s => s.IdDoctor == id && s.Date == date)
                        .Select(s => new { s.Timetype, s.IdDoctor, s.IdSchedules }).ToList();

            return Json(query, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            doctorDao.DeleteSchedules(id);
            return Json(JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail(string id)
        {
            ViewBag.DetailDoctor = doctorDao.GetDoctorByID(Convert.ToInt32(id));
            return View();
        }
    }
}