using FYPWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYPWebApp.Controllers
{
    public class HomeController : Controller
    {
        PatientRepository patrep;
        public HomeController()
        {
            patrep = new PatientRepository("");
        }
        public ActionResult patientinfo()
        {
            return View();
        }
        public ActionResult Create(Patient model)
        {
            if (model != null && ModelState.IsValid)
            {
                patrep.Add(model);
            }
            return RedirectToAction("patientinfo");
        }
        public ActionResult diagnosis()
        {
            return View();
        }
        public ActionResult Prescription()
        {
            return View();
        }
        public ActionResult Surgery()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}