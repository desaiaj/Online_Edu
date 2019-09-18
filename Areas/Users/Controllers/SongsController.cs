using OnlineEducation.Areas.Users.Models;
using OnlineEducation.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Areas.Users.Controllers
{
    [CommonAutoLogOutFunction]
    public class SongsController : Controller
    {
        // GET: Users/Songs
        public ActionResult Index()
        {
            return View();         
        }
        public ActionResult Songs()
        {
            UsersDataContext loUserContext = new UsersDataContext();
            List<SongsModel> loSongData = new List<SongsModel>();
            loSongData = loUserContext.GetSongs();
            return View(loSongData);
        }
    }
}