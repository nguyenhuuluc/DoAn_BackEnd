using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YTeAspMVC.Daos;
using YTeAspMVC.Models;

namespace YTeAspMVC.Controllers.Admin
{
    public class AdminSpecialistController : Controller
    {
        // GET: AdminSpecialist
        DoctorDao doctorDao = new DoctorDao();
        SpecialistDao specialistDao = new SpecialistDao();
        YTeDBContext myDb = new YTeDBContext();
        public ActionResult Index()
        {
            ViewBag.Specialist = specialistDao.GetAll();
            ViewBag.Doctorlist = doctorDao.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Specialist specialist)
        {
            var file = Request.Files["file"];
            string reName = DateTime.Now.Ticks.ToString() + file.FileName;
            file.SaveAs(Server.MapPath("~/Content/images/Specialist/" + reName));
            specialist.Image = reName;
            specialistDao.Add(specialist);
            return RedirectToAction("Index", new { msg = "1" });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Specialist specialist)
        {
            string reName = "";
            var objCourse = specialistDao.GetSpecialistOrderByID(specialist.IdSpecialist);
            var file = Request.Files["file"];
            if (file.FileName == "")
            {
                reName = objCourse.Image;
            }
            else
            {
                reName = DateTime.Now.Ticks.ToString() + file.FileName;
                file.SaveAs(Server.MapPath("~/Content/images/" + reName));
            }
            specialist.Image = reName;
            specialistDao.Update(specialist);
            return RedirectToAction("Index", new { msg = "1" });
        }
        public ActionResult Delete(Specialist specialist)
        {          
                specialistDao.Delete(specialist.IdSpecialist);
                return RedirectToAction("Index", new { msg = "1" });
        }
    }
}