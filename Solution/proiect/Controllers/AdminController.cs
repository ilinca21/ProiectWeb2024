using AutoMapper;
using proiect.Attributes;
using proiect.Extensions;
using proiect.Models.Case;
using proiect.Models.Question;
using proiect.Models.Testimonial;
using proiect.Models.User;
using Solution.BusinessLogic.Interfaces;
using Solution.BusinessLogic.MainBL;
using Solution.Domain.Entities.Case;
using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.Testimonial;
using Solution.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proiect.Controllers
{
    public class AdminController : BaseController
    {
        public readonly ISession _session;
        public readonly ICase _case;
        public readonly ITestimonial _testimonial;
        public readonly IQuestion _question;
        private readonly IUserMonitoring _monitoring;
        private readonly UserMinimal adminAuthenticated;
        // GET: Admin
        public AdminController()
        {
            var bl = new BusinessLogic();
            _monitoring = bl.GetMonitoringBL();
            _session = bl.GetSessionBL();
            _case = bl.GetCaseBL();
            _testimonial = bl.GetTestimonialBL();
            _question = bl.GetQuestionBL();
            adminAuthenticated = System.Web.HttpContext.Current.GetMySessionObject();
        }
        [AdminMod]
        public ActionResult AddUser()
        {
            SessionStatus();

            return View();
        }
        [AdminMod]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(ModelNewUser data)
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
                        caseData.ImagePath = "~/Content/Storage/Cases/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Content/Storage/Cases/"), fileName);
                        caseData.ImageFile.SaveAs(fileName);
                    }

                    var data = Mapper.Map<NewCaseData>(caseData);
                    data.DateAdded = DateTime.Now;
                    data.Author = user.UserName;
                    data.AuthorId = user.Id;

                    var response = _case.AddCaseAction(data);
                    if (response.Status)
                    {
                        return RedirectToAction("CasesManagement", "Admin");
                    }

                    ModelState.AddModelError("", response.StatusMessage);
                    return View(caseData);
                }

                RedirectToAction("Error", "Home");
            }

            return RedirectToAction("Error", "Home");
        }

        public ActionResult EditCase(int? caseId)
        {
            if (caseId == null) return View();
            var caseData = _case.GetById((int)caseId);
            if (caseData != null)
            {
                var caseModel = new CaseData
                {
                    Id = caseData.Id,
                    FullName = caseData.FullName,
                    Age = caseData.Age,
                    City = caseData.City,
                    Address = caseData.Address,
                    Email = caseData.Email,
                    PhoneNumber = caseData.PhoneNumber,
                    Title = caseData.Title,
                    TotalSum = caseData.TotalSum,
                    CollectedSum = caseData.CollectedSum,
                    Currency = caseData.Currency,
                    // Ignorăm ImageFile
                    ImagePath = caseData.ImagePath,
                    StartDate = caseData.StartDate,
                    EndDate = caseData.EndDate,
                    Description = caseData.Description,
                    Status = caseData.Status,
                    DateAdded = caseData.DateAdded,
                    Author = caseData.Author,
                    AuthorId = caseData.AuthorId
                };
                return View(caseModel);
            }

            return RedirectToAction("LoginPage", "Login");
        }

        [HttpPost]
        public ActionResult EditCase(CaseData data)
        {
            //SessionStatus();
            //var user = System.Web.HttpContext.Current.GetMySessionObject();

            if (ModelState.IsValid)
            {
                if (data.ImageFile != null && data.ImageFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(data.ImageFile.FileName);
                    string extension = Path.GetExtension(data.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    data.ImagePath = "~/Content/Storage/Cases/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Content/Storage/Cases/"), fileName);
                    data.ImageFile.SaveAs(fileName);
                }

                var existingCase = Mapper.Map<CaseEditData>(data);
                if (data.ImagePath != null)
                {
                    existingCase.ImagePath = data.ImagePath;
                }

                var response = _case.EditCaseAction(existingCase);
                if (response.Status)
                {
                    return RedirectToAction("CasesManagement", "Admin");
                }

                ModelState.AddModelError("", response.StatusMessage);
                return View(data);
            }

            return View();
        }
        public ActionResult DeleteCase(int caseId)
        {
            SessionStatus();
            var caseToDelete = _case.GetById(caseId);
            if (caseToDelete == null)
            {
                return HttpNotFound();
            }

            _case.Delete((int)caseId);
            _case.Save();
            return RedirectToAction("CasesManagement", "Admin");
        }
        public ActionResult CasesManagement()
        {
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

        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(TestimonialData testimonialData)
        {
            SessionStatus();
            var user = System.Web.HttpContext.Current.GetMySessionObject();

            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    if (testimonialData.ImageFile != null && testimonialData.ImageFile.ContentLength > 0)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(testimonialData.ImageFile.FileName);
                        string extension = Path.GetExtension(testimonialData.ImageFile.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        testimonialData.ImagePath = "~/Content/Storage/Testimonials/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Content/Storage/Testimonials/"), fileName);
                        testimonialData.ImageFile.SaveAs(fileName);
                    }

                    NewTestimonialData data = new NewTestimonialData
                    {
                        ImagePath = testimonialData.ImagePath,
                        DateAdded = DateTime.Now,
                        UserId = user.Id
                    };

                    var response = _testimonial.AddTestimonialAction(data);
                    if (response.Status)
                    {
                        return RedirectToAction("Testimonials", "Admin");
                    }

                    ModelState.AddModelError("", response.StatusMessage);
                    return View(testimonialData);
                }

                RedirectToAction("Error", "Home");
            }

            return RedirectToAction("Error", "Home");
        }

        public ActionResult Testimonials()
        {
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

        public ActionResult Questions()
        {
            var data = _question.GetAll();
            List<QuestionData> allQuestions = new List<QuestionData>();

            if (data.Any())
            {
                foreach (var item in data)
                {
                    var testimonial = Mapper.Map<QuestionData>(item);
                    allQuestions.Add(testimonial);
                }

                return View(allQuestions);
            }

            return RedirectToAction("Error", "Home");
        }
    }
}