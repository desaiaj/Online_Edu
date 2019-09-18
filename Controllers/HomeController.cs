using OnlineEducation.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Controllers
{
    [CommonAutoLogOutFunction]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
                return View("Home");
            else
                return RedirectToAction("Index", "Login");
        }
    }
}