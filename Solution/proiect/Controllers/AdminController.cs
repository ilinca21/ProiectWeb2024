using proiect.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proiect.Controllers
{
    public class AdminController : BaseController
    {
            [AdminMod]
            public ActionResult IndexAdmin()
            {
                SessionStatus();
                return View();
            }
            public ActionResult AdaugareCazAdmin()
            {
                SessionStatus();
                return View();
            }
            public ActionResult AdminProfil()
            {
                SessionStatus();
                return View();
            }
            public ActionResult GestionareCazuri()
            {
                SessionStatus();
                return View();
            }
            public ActionResult AdaugareTestimoniale()
            {
                SessionStatus();
                return View();
            }
            public ActionResult CazuriUrgenteAdmin()
            {
                SessionStatus();
                return View();
            }
            public ActionResult CazuriFinisateAdmin()
            {
                SessionStatus();
                return View();
            }
      }
}