using OnlineEducation.Areas.Admin.Models;
using OnlineEducation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Controllers
{
    public class HomesController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            EducationDataContext loEducontext = new EducationDataContext();
            FeedBackModel loData = new FeedBackModel();
            loData.loUserModel = new EducationDataContext().UserDataForIndex();
            return View("index",loData);
        }
        public ActionResult FeedBack(FeedBackModel loFeedBack,FormCollection Form)
        {
            EducationDataContext loEduContext = new EducationDataContext();
            loEduContext.FeedBack(loFeedBack, Form["ContactFor"]);            
            return RedirectToAction("Index");
        }
        public ActionResult AboutUs()
        {
            QueryDataContext loQContext = new QueryDataContext();
            List<QueryModel> loq = new List<QueryModel>();
            loq = loQContext.GetQueries();
            var c = 0;
            foreach (var d in loq)
            {
                if (d.Answer != null)
                    c++;
            }
            TempData["Q"] = loq.Count();
            TempData["TA"] = c;
            AdminDataContext loEduContext = new AdminDataContext();
            List<UserModel> loUsers = new List<UserModel>();
            loUsers = loEduContext.GetUsers();
            TempData["U"] = loUsers.Count();
            TempData["FC"] = loEduContext.GetFeedBacksAndComplaints().Count();            
            return View();
        }       
    }
}