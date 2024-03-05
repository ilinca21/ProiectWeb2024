using proiect.Models.User;
using Solution.BusinessLogic;
using Solution.BusinessLogic.Interfaces;
using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proiect.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;

        public LoginController()
        {
            var bl = new BusinessLogic();
            _session = bl.GetSessionBL();
        }

public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserLogin data)
        {
            var UData = new ULoginData
            {
                Credential = data.Credential,
                Password = data.Password,
                LoginIp = "0.0.0.0",
                LoginDateTime = DateTime.Now
            };

            ULoginResp resp = _session.UserLoginAction(UData);

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}