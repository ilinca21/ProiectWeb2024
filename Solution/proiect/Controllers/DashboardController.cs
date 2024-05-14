using AutoMapper;
using proiect.Extensions;
using proiect.Models.User;
using Solution.BusinessLogic.Interfaces;
using Solution.BusinessLogic.MainBL;
using Solution.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proiect.Controllers
{
    public class DashboardController : BaseController
    {
        public readonly ISession _session;


        private readonly UserMinimal userAuthenticated;

        public DashboardController()
        {
            var bl = new BusinessLogic();
            _session = bl.GetSessionBL();
            userAuthenticated = System.Web.HttpContext.Current.GetMySessionObject();
        }

        public ActionResult PersonalProfile()
        {
            var userData = _session.GetUserById(userAuthenticated.Id);
            if (userAuthenticated != null)
            {
                var userModel = Mapper.Map<UEditData>(userData);
                return View(userModel);
            }

            return RedirectToAction("LoginPage", "Login");
        }

        public ActionResult EditProfile()
        {
            var userModel = new UEditData();
            return View(userModel);
        }

        [HttpGet]
        public ActionResult EditProfile(int? userId)
        {
            if (userId == null)
            {
                userId = userAuthenticated.Id;
            }

            var userData = _session.GetUserById((int)userId);

            if (userData != null)
            {
                var userModel = Mapper.Map<UEditData>(userData);
                return View(userModel);
            }

            return RedirectToAction("LoginPage", "Login");
        }

        [HttpPost]
        public ActionResult EditProfile(UEditData data)
        {
            //SessionStatus();
            //var user = System.Web.HttpContext.Current.GetMySessionObject();
            if (userAuthenticated != null && data.Id == userAuthenticated.Id)
            {
                if (ModelState.IsValid)
                {
                    var existingUser = Mapper.Map<UserEditData>(data);

                    var response = _session.EditProfileAction(existingUser);
                    if (response.Status)
                    {
                        return RedirectToAction("PersonalProfile", "Dashboard");
                    }

                    ModelState.AddModelError("", response.StatusMessage);
                    return View(data);
                }
            }

            return View();
        }
    }
}