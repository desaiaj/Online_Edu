using OnlineEducation.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Areas.Users.Controllers
{
    [CommonAutoLogOutFunction]
    public class GamesController : Controller
    {
        // GET: Users/Games
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _2048()
        {
            return View("G2048");
        }
        public ActionResult Hextris()
        {
            return View();
        }
        public ActionResult Snake()
        {
            return View();
        }
    }
}