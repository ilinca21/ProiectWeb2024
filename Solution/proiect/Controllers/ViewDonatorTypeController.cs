using Solution.BusinessLogic.Interfaces;
using Solution.BusinessLogic.MainBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proiect.Controllers
{
    public class ViewDonatorTypeController : Controller
    {
        // GET: ViewDonatorType
        private readonly IDonatorType _donatorType;
        public ViewDonatorTypeController()
        {
            var businessLogic = new BusinessLogic();
            _donatorType = businessLogic.GetDonatorTypeBL();
        }

        public ActionResult TypePage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetDonatorType(int id)
        {
            var donatorTypeDetail = _donatorType.GetDetailDonatorType(id);
            return View(donatorTypeDetail);
        }
    }
}