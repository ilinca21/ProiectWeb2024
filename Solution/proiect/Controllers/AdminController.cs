using proiect.Attributes;
using proiect.Models.User;
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
    public class AdminController : BaseController
    {
        private readonly IUserMonitoring _monitoring;
        // GET: Admin
        public AdminController()
        {
            var bl = new BusinessLogic();
            _monitoring = bl.GetMonitoringBL();
        }
        [AdminMod]
        public ActionResult AdaugareUser()
        {
            SessionStatus();

            return View();
        }
        [AdminMod]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdaugareUser(ModelNewUser data)
        {
            if (ModelState.IsValid)
            {
                ANewUser uData = new ANewUser
                {
                    Credential = data.Credential,
                    Email = data.Email,
                    Password = data.Password,
                    ConfirmPassword = data.ConfirmPassword,
                    Level = data.Level
                };
                ULoginResp resp = _monitoring.AddNewUser(uData);
                if (resp.Status)
                {
                    return RedirectToAction("Users", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", resp.Message);  // Ensure this property name is correct
                    return RedirectToAction("UserPage", "LoginUser");
                }
            }
            return View(data);
        }

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