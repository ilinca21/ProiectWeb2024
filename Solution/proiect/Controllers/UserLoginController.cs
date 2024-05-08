using Microsoft.AspNet.Identity;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace proiect.Controllers
{
    public class UserLoginController : BaseController
    {
        // GET: UserLogin
        public ActionResult IndexUserLogin()
        {
            SessionStatus();
            return View();
        }
        public ActionResult AdaugareCaz()
        {
            SessionStatus();
            return View();
        }
        public ActionResult Contact()
        {
            SessionStatus();
            return View();
        }
        public ActionResult Desprenoi()
        {
            SessionStatus();
            return View();
        }
        public ActionResult DonatieLunar()
        {
            SessionStatus();
            return View();
        }
        public ActionResult FAQ()
        {
            SessionStatus();
            return View();
        }
        public ActionResult ProfilulMeu()
        {
            SessionStatus();
            return View();
        }
        public ActionResult Testimoniale()
        {
            SessionStatus();
            return View();
        }
        public ActionResult ToateCazurile()
        {
            SessionStatus();
            return View();
        }
        public ActionResult CazuriUrgenteUser()
        {
            SessionStatus();
            return View();
        }
        public ActionResult CazuriFinisateUser()
        {
            SessionStatus();
            return View();
        }
        public ActionResult CardCredit()
        {
            SessionStatus();
            return View();
        }

        public ActionResult ParteneriateCompanii()
        {
            SessionStatus();
            return View();
        }

    }
}
