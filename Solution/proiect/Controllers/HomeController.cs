using AutoMapper;
using proiect.Extensions;
using proiect.Models;
using proiect.Models.Case;
using proiect.Models.Testimonial;
using Solution.BusinessLogic.Interfaces;
using Solution.BusinessLogic.MainBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proiect.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public readonly ICase _case;
        public readonly ITestimonial _testimonial;

        public HomeController()
        {
            var bl = new BusinessLogic();
            _case = bl.GetCaseBL();
            _testimonial = bl.GetTestimonialBL();
        }

        public ActionResult Index()
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return View();
            }

           

            return RedirectToAction("Index", "UserLogin");
        }


        public ActionResult PageToateCazurile()
        {
            SessionStatus(); 
            var data = _case.GetAll();
            List<CaseViewData> allCases = new List<CaseViewData>();

            if (data.Any())
            {
                foreach (var caseData in data)
                {
                    var caseMinimal = Mapper.Map<CaseViewData>(caseData);
                    allCases.Add(caseMinimal);
                }

                return View(allCases);
            }

            return RedirectToAction("Error", "Home");
        }

        public ActionResult PageCazuriUrgente()
        {
            SessionStatus();
            var data = _case.GetAllUrgentCases();
            List<CaseViewData> allCases = new List<CaseViewData>();

            if (data.Any())
            {
                foreach (var caseData in data)
                {
                    var caseMinimal = Mapper.Map<CaseViewData>(caseData);
                    allCases.Add(caseMinimal);
                }

                return View(allCases);
            }

            return RedirectToAction("Error", "Home");
        }

        public ActionResult PageCazuriFinisate()
        {
            SessionStatus();
            var data = _case.GetAllFinishedCases();
            List<CaseViewData> allCases = new List<CaseViewData>();

            if (data.Any())
            {
                foreach (var caseData in data)
                {
                    var caseMinimal = Mapper.Map<CaseViewData>(caseData);
                    allCases.Add(caseMinimal);
                }

                return View(allCases);
            }

            return RedirectToAction("Error", "Home");
        }

        public ActionResult PageTestimoniale()
        {
            SessionStatus();
            var data = _testimonial.GetAll();
            List<TestimonialViewData> allTestimonials = new List<TestimonialViewData>();

            if (data.Any())
            {
                foreach (var testimonialData in data)
                {
                    var testimonial = Mapper.Map<TestimonialViewData>(testimonialData);
                    allTestimonials.Add(testimonial);
                }

                return View(allTestimonials);
            }

            return RedirectToAction("Error", "Home");
        }

        public ActionResult PageContact()
        {
            return View();
        }

        public ActionResult PageParteneriateCompanii()
        {
            return View();
        }

        public ActionResult PageDesprenoi()
        {
            return View();
        }

        public ActionResult PageFAQ()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}
