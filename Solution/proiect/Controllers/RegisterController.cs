using Solution.BusinessLogic.Interfaces;
using Solution.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Solution.Domain.Entities.User;
using Solution.Domain.Entities.Responce;
using Solution.BusinessLogic.MainBL;
using proiect.Models.User;

namespace proiect.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ISession _session;

        public RegisterController()
        {
            var bl = new BusinessLogic();
            _session = bl.GetSessionBL();
        }

        // GET: Register
        public ActionResult CreateAccount()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAccount(UserRegister data)
        {
           
            if (ModelState.IsValid)
            {
                URegisterData uData = new URegisterData
                {
                    Name = data.Name,
                    Password = data.Password,
                    ConfirmPassword = data.ConfirmPassword,
                    UserName = data.Credential,
                    LoginIp = Request.UserHostAddress,
                    LoginDateTime = DateTime.Now
                };
                ULoginResp resp = _session.RegisterNewUserAction(uData);
                if (resp.Status)
                {
                    //ADD COOKIE
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", resp.ActionStatusMsg);
                }
            }
            return View(data);
        }
    }
}