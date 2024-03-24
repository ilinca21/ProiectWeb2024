using proiect.Models.User;
using Solution.BusinessLogic;
using Solution.BusinessLogic.Interfaces;
using Solution.BusinessLogic.MainBL;
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

        public ActionResult LogIn()
        {
            var ULoginData = new ULoginData
            {
                Credential = "user",
                Password = "password",
                LoginIp = " ",
                LoginDateTime = DateTime.Now
            };
            var test = _session.UserLoginAction(ULoginData);
            return View();
        }
        
        //Get : Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(UserLogin data)
        {
            if (ModelState.IsValid)
            {
                ULoginData uData = new ULoginData
                {
                    Credential = data.Credential,
                    Password = data.Password,
                    LoginIp = Request.UserHostAddress,
                    LoginDateTime = DateTime.Now
                };
                ULoginResp resp = _session.UserLoginAction(uData);
                if (resp.Status)
                {
                    //ADD COOCKIE

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", resp.ActionStatusMsg);
                    return View();
                }
            }
            return View();
        }
    }
}