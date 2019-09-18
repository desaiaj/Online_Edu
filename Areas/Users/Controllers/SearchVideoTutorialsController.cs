using OnlineEducation.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Areas.Users.Controllers
{
    [CommonAutoLogOutFunction]
    public class SearchVideoTutorialsController : Controller
    {
        // GET: Users/SearchVideoTutorials
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult res(List<string> Result)
        {
            return View("item");
        }
    }
}