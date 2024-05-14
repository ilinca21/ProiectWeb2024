using Solution.BusinessLogic.Interfaces;
using Solution.BusinessLogic.MainBL;
using Solution.Domain.Entities.Case;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proiect.Controllers
{
    public class ListingController : Controller
    {
            // GET: Listing
            private readonly ICase _case;

            public ListingController()
            {
                var bl = new BusinessLogic();
                _case = bl.GetCaseBL();
            }

            public ActionResult Index()
            {
                var data = _case.GetAll();
                List<CaseMinimal> allCases = new List<CaseMinimal>();

                return View(allCases);
            }

            public ActionResult ListingSearchByKey(string key)
            {
                if (key != null)
                {
                    var data = _case.GetCasesByKey(key);
                    if (data.Count() > 0)
                    {
                        TempData["cases"] = data;
                        return RedirectToAction("ListingParameters", new { key = key });
                    }
                }

                return RedirectToAction("Index", "Listing");
            }

            public ActionResult ListingParameters()
            {
                List<CaseMinimal> allCases = new List<CaseMinimal>();

                if (TempData["cases"] is List<CaseMinimal> casesBySearchWrap && casesBySearchWrap.Any())
                {
                    allCases = casesBySearchWrap;
                    return View(allCases);
                }

                return RedirectToAction("Error", "Home");
            }
    }
}