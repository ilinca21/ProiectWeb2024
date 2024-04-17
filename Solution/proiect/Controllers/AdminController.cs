using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proiect.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult IndexAdmin()
        {
            return View();
        }
        public ActionResult AdaugareCazAdmin()
        {
            return View();
        }
        public ActionResult AdminProfil()
        {
            return View();
        }
        public ActionResult GestionareCazuri()
        {
            return View();
        }
        public ActionResult AdaugareTestimoniale()
        {
            return View();
        }
        public ActionResult CazuriUrgenteAdmin()
        {
            return View();
        }
        public ActionResult CazuriFinisateAdmin()
        {
            return View();
        }
    }
}