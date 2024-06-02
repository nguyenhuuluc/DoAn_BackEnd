using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YTeAspMVC.Daos;

namespace YTeAspMVC.Controllers
{
    public class ClinicController : Controller
    {
        // GET: Clinic
        ClinicDao clinic = new ClinicDao();
        public ActionResult Index()
        {
            ViewBag.GetList = clinic.GetAll();
            Session.Add("Active", "Clinic");
            return View();
        }
    }
}