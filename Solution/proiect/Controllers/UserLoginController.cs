using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.Exchange.WebServices.Data;
using proiect.Extensions;
using proiect.Models.Card;
using proiect.Models.Case;
using proiect.Models.Question;
using Solution.BusinessLogic.Interfaces;
using Solution.BusinessLogic.MainBL;
using Solution.Domain.Entities.Card;
using Solution.Domain.Entities.Case;
using Solution.Domain.Entities.Question;
using Solution.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace proiect.Controllers
{
    public class UserLoginController : BaseController
    {
        // GET: UserLogin
        public readonly ISession _session;
        public readonly ICase _case;
        public readonly ICard _card;
        public readonly IQuestion _question;

        private readonly UserMinimal userAuthenticated;

        public UserLoginController()
        {
            var bl = new BusinessLogic();
            _session = bl.GetSessionBL();
            _case = bl.GetCaseBL();
            _card = bl.GetCardBL();
            _question = bl.GetQuestionBL();
            userAuthenticated = System.Web.HttpContext.Current.GetMySessionObject();
        }

        public ActionResult Index()
        {
            SessionStatus();
            return View();
        }

        public ActionResult AddCase()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCase(CaseData caseData)
        {
            SessionStatus();
            var user = System.Web.HttpContext.Current.GetMySessionObject();

            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    if (caseData.ImageFile != null && caseData.ImageFile.ContentLength > 0)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(caseData.ImageFile.FileName);
                        string extension = Path.GetExtension(caseData.ImageFile.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        caseData.ImagePath = "~/Content/PostsImages/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Content/PostsImages/"), fileName);
                        caseData.ImageFile.SaveAs(fileName);
                    }

                    var data = Mapper.Map<NewCaseData>(caseData);
                    data.DateAdded = DateTime.Now;
                    data.Author = user.UserName;
                    data.AuthorId = user.Id;

                    var response = _case.AddCaseAction(data);
                    if (response.Status)
                    {
                        return RedirectToAction("PageToateCazurile", "Home");
                    }

                    ModelState.AddModelError("", response.StatusMessage);
                    return View(caseData);
                }

                RedirectToAction("Error", "Home");
            }

            return RedirectToAction("Error", "Home");
        }

        public ActionResult MonthlyDonation()
        {
            SessionStatus();
            var user = System.Web.HttpContext.Current.GetMySessionObject();

            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    var cardData = _card.GetByUserId((int)user.Id);

                    if (cardData != null)
                    {
                        var data = Mapper.Map<UCardData>(cardData);
                        var response = _card.PayAction(data);

                        if (response.Status)
                        {
                            return RedirectToAction("Index", "UserLogin");
                        }

                        ModelState.AddModelError("", response.StatusMessage);

                        return RedirectToAction("CreditCard", "UserLogin");
                    }

                    return RedirectToAction("CreditCard", "UserLogin");
                }

                return RedirectToAction("CreditCard", "UserLogin");
            }

            return RedirectToAction("Error", "Home");
        }

        public ActionResult FAQ()
        {
            SessionStatus();
            return View();
        }

        [HttpPost]
        public ActionResult FAQ(QuestionData questionData)
        {
            SessionStatus();
            var user = System.Web.HttpContext.Current.GetMySessionObject();

            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    var data = Mapper.Map<NewQuestionData>(questionData);
                    data.DateAdded = DateTime.Now;
                    data.UserId = user.Id;

                    var response = _question.AddQuestionAction(data);
                    if (response.Status)
                    {
                        return RedirectToAction("FAQ", "UserLogin");
                    }

                    ModelState.AddModelError("", response.StatusMessage);
                    return RedirectToAction("Error", "Home");
                }

                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction("LoginPage", "Login");
        }

        public ActionResult CreditCard()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreditCard(CardData cardData)
        {
            SessionStatus();
            var user = System.Web.HttpContext.Current.GetMySessionObject();

            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    var data = Mapper.Map<NewCardData>(cardData);
                    data.DateAdded = DateTime.Now;
                    data.UserId = user.Id;

                    var response = _card.AddCardAction(data);
                    if (response.Status)
                    {
                        return RedirectToAction("Index", "UserLogin");
                    }

                    ModelState.AddModelError("", response.StatusMessage);
                    return View(cardData);
                }

                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction("LoginPage", "Login");
        }

    }
}
