using proiect.Extensions;
using Solution.BusinessLogic.Interfaces;
using Solution.BusinessLogic.MainBL;
using Solution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace proiect.Attributes
{
    public class AdminModAttribute : ActionFilterAttribute
    {
        private readonly ISession _sessionBusinessLogic;

        public AdminModAttribute()
        {
            var businessLogic = new BusinessLogic();
           _sessionBusinessLogic = businessLogic.GetSessionBL();
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var apiCookie = HttpContext.Current.Request.Cookies["X-KEY"];
            if(apiCookie == null)
            {
                RedirectToLogin(filterContext);
                return;
            }
            var profile = _sessionBusinessLogic.GetUserByCookie(apiCookie.Value);
            if (profile == null)
            {
                RedirectToLogin(filterContext);
                return;
            }

            if (profile.Level != UserRole.Admin)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Home", action = "ErrorAccessDenied" }));
            }
            else
            {
                HttpContext.Current.SetMySessionObject(profile);
            }
        }

        private void RedirectToLogin(ActionExecutingContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new { controller = "Login", action = "LoginPage" }));
        }
    }
}