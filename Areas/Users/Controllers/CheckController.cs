using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Areas.Users.Controllers
{
    public class CheckController : Controller
    {
        // GET: Users/Check
        public ActionResult Index()
        {
            return View("_UserMasterPage");
        }
    }
}