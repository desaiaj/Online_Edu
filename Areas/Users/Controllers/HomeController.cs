using OnlineEducation.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Areas.Users.Controllers
{
    [CommonAutoLogOutFunction]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }       
    }
}