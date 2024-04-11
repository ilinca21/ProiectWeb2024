using AutoMapper;
using proiect.Models.User;
using Solution.BusinessLogic;
using Solution.BusinessLogic.Interfaces;
using Solution.BusinessLogic.MainBL;
using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

        public ActionResult LoginPage()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            if (Response.Cookies["X-KEY"] != null)
            {
                var cookie = new HttpCookie("X-KEY")
                {
                    Expires = DateTime.Now.AddDays(-1),
                    HttpOnly = true
                };
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("LoginPage", "Login");
        }
        //Get : Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginPage(UserLogin data)
        {
            if (ModelState.IsValid)
            {
                var dataUser = Mapper.Map<ULoginData>(data);

                dataUser.LoginIp = Request.UserHostAddress;
                dataUser.LoginDateTime = DateTime.Now;

                ULoginResp resp = _session.UserLoginAction(dataUser);
                if (resp.Status)
                {
                    HttpCookie cookie = _session.GenCookie(data.Credential);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    Session["UserName"] = data.Credential;
                    if (resp.Message == "Admin")
                        return RedirectToAction("IndexAdmin", "Admin");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", resp.Message);
                    return View(data);
                }
            }
            return View(data);
        }
    }
}