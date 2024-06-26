﻿using AutoMapper;

using proiect.Models.Password;
using proiect.Models.User;
using Solution.BusinessLogic;
using Solution.BusinessLogic.DBModel.Seed;
using Solution.BusinessLogic.Interfaces;
using Solution.BusinessLogic.MainBL;
using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.User;
using Solution.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace proiect.Controllers
{
    public class LoginController : BaseController
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
            return RedirectToAction("Index", "Home");
        }
        //Get : Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginPage(UserLogin data)
        {
            HttpContext.Session["UserProfile"] = data;
            if (ModelState.IsValid)
            {
                var dataUser = Mapper.Map<ULoginData>(data);

                dataUser.LoginIp = Request.UserHostAddress;
                dataUser.LoginDateTime = DateTime.Now;

                ULoginResp resp = _session.UserLoginAction(dataUser);
                if (resp.Status)
                {
                    FormsAuthentication.SetAuthCookie(data.Credential, false);
                    HttpCookie cookie = _session.GenCookie(data.Credential);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    Session["UserName"] = data.Credential;
                    if (resp.Message == "Admin")
                        return RedirectToAction("Index", "Admin");
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
        public ActionResult ChangePassword()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(UserRegister user)
        {
            var _dbContext = new UserContext();
            if (ModelState.IsValid)
            {
                if (user.Password == user.ConfirmPassword)
                {
                    var existingUser = _dbContext.Users.FirstOrDefault(u => u.UserName == user.Credential);

                    if (existingUser != null)
                    {
                        // Criptează noua parolă înainte de a o salva în baza de date
                        string encryptedPassword = LoginHelper.HashGen(user.Password);

                        // Actualizează parola criptată în baza de date
                        existingUser.Password = encryptedPassword;

                        _dbContext.SaveChanges();

                        return RedirectToAction("LoginPage", "Login");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Utilizatorul nu a fost găsit.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Parola nouă și confirmarea parolei nu coincid.");
                }
            }

            return View(user);
        }
        public ActionResult ResetPassword()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(UserLogin user)
        {
            if (user.Credential != null)
            {
                string email = user.Credential;
                string codeSend = SendCode.SendCodeToUser(email); // Generate and send code to user's email
                TempData["ResetEmail"] = email; // Store the email in TempData to retrieve later
                TempData["CodeSend"] = codeSend; // Store the code in TempData to retrieve later
            }
            return RedirectToAction("ResetCode", "Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetCode(ModelResetPassword user)
        {
            string codeWrite = user.CodeWrite;
            UDBTable userLogin;
            string email = TempData["ResetEmail"] as string;
            string codeSend = TempData["CodeSend"] as string;

            if (codeWrite != null && codeWrite.Equals(codeSend))
            {
                // Codes match; proceed to reset password for the user
                // Redirect to a view where user can input new password
                using (var db = new UserContext())
                {
                    userLogin = db.Users.FirstOrDefault(us => us.UserName == email);
                }
                if (userLogin == null)
                    Session["LoginStatus"] = "login";

                return RedirectToAction("ChangePassword", "Login", new { email = email });

            }
            else
            {
                // Codes don't match; redirect back to enter code again
                return RedirectToAction("ResetPassword", "Login");
            }
        }

        public ActionResult ResetCode()
        {
            return View();
        }

    }
}