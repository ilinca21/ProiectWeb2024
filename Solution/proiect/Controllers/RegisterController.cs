using Solution.BusinessLogic.Interfaces;
using Solution.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Solution.Domain.Entities.User;
using Solution.Domain.Entities.Responce;
using Solution.BusinessLogic.MainBL;

namespace proiect.Controllers
{
    public class RegisterController : Controller
    {

        private readonly ISession _session;

        public RegisterController()
        {
            var bl = new BusinessLogic();
            _session = bl.GetSessionBL();
        }
    }
}