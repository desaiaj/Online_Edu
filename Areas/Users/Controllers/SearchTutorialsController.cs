using OnlineEducation.Models;
using OnlineEducation.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Areas.Users.Controllers
{
    [CommonAutoLogOutFunction]
    public class SearchTutorialsController : Controller
    {
        // GET: Users/SearchTutorials
        public ActionResult Index()
        {
            ViewTutorialsDataContext loTutorialContext = new ViewTutorialsDataContext();
            TutorialsModel loTutorial = new TutorialsModel();
            loTutorial.loTutorialsHistory = loTutorialContext.TutorialHistory(Convert.ToDecimal(Session["UserID"]));
            loTutorial.loTutorialsData = loTutorialContext.TutorialHistory(Convert.ToDecimal(Session["UserID"]), "F");
            return View(loTutorial);
        }        
        public ActionResult SearchTutorials(string Keywords,string Subject=null,string Category=null)
        {                                                          
            ViewTutorialsDataContext loTutorialContext = new ViewTutorialsDataContext();
            TutorialsModel loUpload = new TutorialsModel();
            loUpload.loTutorialsData = loTutorialContext.SearchTutorials((Keywords=="")?null:Keywords);
            return View("~/Areas/Users/Views/SearchTutorials/_Search.cshtml", loUpload);
        }        
        public ActionResult TutorialsViews(int TutorialsID)
        {
            ViewTutorialsDataContext loTutorialContext = new ViewTutorialsDataContext();            
            var Views= loTutorialContext.TutorialsViews(TutorialsID,Convert.ToDecimal(Session["UserID"]));
            return Json(Views,JsonRequestBehavior.AllowGet);
        }
        public ActionResult LikeTutorials(int TutorialsID,string s)
        {
            ViewTutorialsDataContext loTutorialContext = new ViewTutorialsDataContext();            
            var Likes = loTutorialContext.LikeTutorials(TutorialsID,s);
            return Json(Likes,JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddToFavourite(int TutorialsID,string s)
        {
            ViewTutorialsDataContext loTutorialContext = new ViewTutorialsDataContext();
            var Likes = loTutorialContext.AddtoFavourite(TutorialsID, Convert.ToDecimal(Session["UserID"]), (s == "AddFavourite") ? 1 : 0);
            return Json(Likes, JsonRequestBehavior.AllowGet);
        }
        public ActionResult RemoveFavourite(int TutorialsID)
        {
            ViewTutorialsDataContext loTutorialContext = new ViewTutorialsDataContext();
            TutorialsModel loTutorial = new TutorialsModel();
            loTutorialContext.RemoveFavourite(TutorialsID, Convert.ToDecimal(Session["UserID"]));
            return RedirectToAction("Index");
        }        
    }
}