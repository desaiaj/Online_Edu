using OnlineEducation.Models;
using OnlineEducation.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Controllers
{
    [CommonAutoLogOutFunction]
    public class ExpertController : Controller
    {
        // GET: Expert
        public ActionResult Index()
        {
            return View("Expert");
        }
        public ActionResult BecomeExpert(ExpertModel loExpertModel)
        {
            ExpertDataContext loExpertConext = new ExpertDataContext();
            loExpertModel.UserID = Convert.ToDecimal(Session["UserID"]);
            loExpertConext.BecomeExpert(loExpertModel);
            return View();
        }
        public ActionResult CheckEligibility()
        {
            ExpertDataContext loExpertConext = new ExpertDataContext();
            var Date = loExpertConext.CheckEliligibility(Convert.ToDecimal(Session["UserID"]));
            var d = DateTime.Now.Subtract(Date);
            if (d.TotalDays < 183)
                return Json(Date.ToShortDateString(), JsonRequestBehavior.AllowGet);
            else
                return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}