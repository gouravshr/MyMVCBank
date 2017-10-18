using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATM.Web.Controllers
{
    [Authorize(Roles ="SuperAdmin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AsignRole()
        {
            return View();
        }
        public ActionResult CreateRole()
        {
            return View();
        }
    }
}