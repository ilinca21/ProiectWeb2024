using proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proiect.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Index";


            return View();
        }

        public ActionResult UserPage()
        {
            return View();
        }

        public ActionResult LoginPage()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }

        public ActionResult CreateAccount()
        {
            return View();
        }

        public ActionResult PageFAQ()
        {
            return View();
        }
        public ActionResult PageAdaugareCaz()
        {
            return View();
        }
        public ActionResult PageContact()
        {
            return View();
        }
        public ActionResult PageDesprenoi()
        {
            return View();
        }

        public ActionResult PageTestimoniale()
        {
            return View();
        }
        public ActionResult PageDonatieLunar()
        {
            return View();
        }

    }
}
