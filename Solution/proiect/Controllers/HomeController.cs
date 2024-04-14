using proiect.Extensions;
using proiect.Models;
using proiect.VerifyRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proiect.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            string role = SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return View();
            }
            else
            {
                if (role == "Admin")
                {
                    IsAdmin.IsUserAdmin();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
        }
        public ActionResult IndexAdmin()
        {
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

        public ActionResult PageProfilulMeu()
        {
            return View();
        }
        public ActionResult PageToateCazurile()
        {
            return View();
        }
    }
}
