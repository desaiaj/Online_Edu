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
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserProfile(decimal UserID=16)
        {
            if (UserID != 0)
            {
                EducationDataContext loEduContext = new EducationDataContext();
                UserProfileModel loProfile = new UserProfileModel();
                loProfile.loProfileData = loEduContext.UserProfile(UserID);
                return View("Profile", loProfile);
            }
            return RedirectToAction("Index","Home");
        }
    }
}