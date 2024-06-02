using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YTeAspMVC.Daos;

namespace YTeAspMVC.Controllers
{
    public class SpecialistController : Controller
    {
        // GET: Specialist
        SpecialistDao specialistDao = new SpecialistDao();
        DoctorDao doctorDao = new DoctorDao();
        SchedulesDao scheduleDao = new SchedulesDao();
        public ActionResult Index()
        {
            ViewBag.Specialist = specialistDao.GetAll();
            Session.Add("Active", "Specialist");
            return View();
        }
        public ActionResult Detail(string id)
        {
            ViewBag.SelectAll = specialistDao.GetSpecialistsById(Convert.ToInt32(id));
            ViewBag.OrderByID = specialistDao.GetSpecialistOrderByID(Convert.ToInt32(id));

            foreach (var doctor in ViewBag.SelectAll)
            {
                doctor.Schedules = doctorDao.GetListSchedulesbyIdDoctor(doctor.IdDoctor);
            }

            ViewBag.Specialist = specialistDao.GetAll();
            ViewBag.Schedule = scheduleDao.GetAll();
            Session.Add("Active", "Doctor");

            return View();
        }

    }
}