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
    public class UsersListController : Controller
    {
        // GET: UsersList
        public ActionResult Index()
        {
            AdminDataContext logetUserContext = new AdminDataContext();
            List<UserModel> UserDetail = new List<UserModel>();

            UserDetail = logetUserContext.GetUsers();
            ViewBag.Tuser = UserDetail.Count();
            
            return View("UsersList", UserDetail);
        }
        public ActionResult GetSearchedUsers(string Name, string Email, string Mobile, string Status)
        {
            AdminDataContext logetUserContext = new AdminDataContext();
            UserModel UserModel= new UserModel();
            UserModel.UserDetail = logetUserContext.GetUsersBySearch((Name == "") ? null : Name, (Email == "") ? null : Email, (Mobile == "") ? null : Mobile, (Status == "") ? null : Status);
            
            return View("~/Areas/Admin/Views/UsersList/_UsersBySearch.cshtml",UserModel);
        }
    }
}