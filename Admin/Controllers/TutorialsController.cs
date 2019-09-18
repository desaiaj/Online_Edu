using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineEducation.Models;
using OnlineEducation.Areas.Admin.Models;
using OnlineEducation.Service;

namespace OnlineEducation.Areas.Admin.Controllers
{
    [CommonAutoLogOutFunction]
    public class TutorialsController : Controller
    {
        // GET: Admin/Tutorials
        public ActionResult Index()
        {
            AdminDataContext dbContext = new AdminDataContext();
            TutorialsModel loTutorials = new TutorialsModel();
            loTutorials.loTutorialsData = dbContext.GetTutorials();
            return View("Tutorials", loTutorials);
        }
        public ActionResult GetTutorialsBySearch(string Subject, string Category, string Keywords)
        {
            AdminDataContext dbContext = new AdminDataContext();
            List<TutorialsModel> loTutorials = new List<TutorialsModel>();
            loTutorials = dbContext.GetTutorialsBySearch((Subject=="")?null:Subject,(Category=="")?null:Category,(Keywords=="")?null:Keywords);
            return View("~/Areas/Admin/Views/Tutorials/_GetTutorialsBySearch.cshtml",loTutorials);
        }
    }
}