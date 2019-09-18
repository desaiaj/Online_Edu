using OnlineEducation.Areas.Admin.Models;
using OnlineEducation.Models;
using OnlineEducation.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Areas.Admin.Controllers
{
    [CommonAutoLogOutFunction]
    public class DeshbordController : Controller
    {
        // GET: Admin/Deshbord
        public ActionResult Index()
        {
            AdminDataContext dbContext = new AdminDataContext();
            List<UserModel> loUserList = new List<UserModel>();

            loUserList = dbContext.GetUsers();
            ViewBag.TotalUsers = loUserList.Count();            
            ViewBag.ActiveUsers = loUserList[0].ActiveUsers;
            ViewBag.DeactiveUsers = loUserList[0].DeactiveUsers;

            List<TutorialsModel> loTutorials = new List<TutorialsModel>();
            loTutorials = dbContext.GetTutorials();
            ViewBag.TotalTutorials = loTutorials.Count();

            List<FeedBackModel> loFeedBackandComplaints = new List<FeedBackModel>();
            loFeedBackandComplaints = dbContext.GetFeedBacksAndComplaints();
            ViewBag.TotalComplaints = loFeedBackandComplaints[0].TotalComplaints;
            ViewBag.TotalFeedBacks = loFeedBackandComplaints[0].TotalFeedBacks;
            ViewBag.SolvedComplaints = loFeedBackandComplaints[0].SolvedComplaints;

            return View();
        }
    }
}