using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineEducation.Models;
using System.Net.NetworkInformation;
using OnlineEducation.Areas.Admin.Models;

namespace OnlineEducation.Controllers
{
    public class LoginController : Controller
    {
        static string Email = null;
        static string pass = null;
        // GET: Account
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                if (Convert.ToInt32(Session["UserID"]) != 1)
                    return RedirectToAction("Index", "Home", new { area = "Users" });
                else
                    return RedirectToAction("Index", "UsersList", new { area = "Admin" });
            }
            if (TempData["msg"] != null)
                ViewBag.error = TempData["msg"].ToString();
            if (TempData["loggedin"] != null)
            {
                LoginModel loCredentials = new LoginModel();
                loCredentials.LoginID = Email;
                loCredentials.UPassword = pass;

                ViewBag.log = TempData["loggedin"].ToString();
                return View("Login", loCredentials);
            }
            return View("Login");
        }

        public ActionResult Login()
        {
            if (Request.Cookies["Remember"] != null)
            {
                if (!CheckMAC(Request.Cookies["Remember"].Values.Get("UserID")))
                {
                    TempData["loggedin"] = "Logged in another System, do u want to log out from all the system?";
                    DestroyCookies();
                    return RedirectToAction("Index");
                }
                else
                    return RedirectToAction("LoginWithCoockie");
            }
            else
                return RedirectToAction("Index");
        }

        public ActionResult LoginWithCoockie()
        {
            if (Request.Cookies["Remember"] != null)
            {
                EducationDataContext loLoginContext = new EducationDataContext();
                LoginModel loCredentials = new LoginModel();
                loCredentials = loLoginContext.CheckLogin(Request.Cookies["Remember"].Values.Get("Email"));
                if (loCredentials.UPassword == Request.Cookies["Remember"].Values.Get("Password"))
                {
                    loCredentials.LoginID = loCredentials.Email;
                    return View("Login", loCredentials);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult LoginCredentials(LoginModel loLoginFormData, FormCollection form)
        {
            EducationDataContext loLoginContext = new EducationDataContext();
            LoginModel loCredentials = new LoginModel();
            //Remember Me is not set
            if (loLoginFormData.UPassword != null && loLoginFormData.LoginID != null)
            {
                loCredentials = loLoginContext.CheckLogin(loLoginFormData.LoginID);

                if (loCredentials.BlockID != 0)
                {
                    TempData["msg"] = "You Are Blocked please Contact us for more info";
                    return RedirectToAction("Index");//With Block Info
                }

                if (loCredentials.Email == null && loCredentials.MobileNo.ToString() == null)
                {
                    return RedirectToAction("Index");
                }
                else if (loCredentials.UPassword != loLoginFormData.UPassword)
                {
                    TempData["msg"] = "Wrong";
                    return RedirectToAction("Index");
                }

                if (!CheckMAC(loCredentials.UserID.ToString()))
                {
                    TempData["loggedin"] = "U r allready loggedin into another system";
                    Email = loLoginFormData.LoginID;
                    pass = loLoginFormData.UPassword;
                    DestroyCookies();
                    return RedirectToAction("Index");
                }
                else
                {
                    if (loCredentials.UPassword == loLoginFormData.UPassword)
                    {
                        if (form["RememberMe"] == "Remember")
                        {
                            HttpCookie ck = new HttpCookie("Remember");
                            ck.Values.Add("Email", loCredentials.Email);
                            ck.Values.Add("MobileNo", loCredentials.MobileNo.ToString());
                            ck.Values.Add("Password", loCredentials.UPassword);
                            ck.Expires = DateTime.Now.AddDays(5);
                            Response.Cookies.Add(ck);
                        }
                        Session.Timeout = 1200;
                        Session["UserName"] = loCredentials.FullName;
                        Session["UserID"] = loCredentials.UserID;
                        Session["Email"] = loCredentials.Email;
                        Session["MobileNo"] = loCredentials.MobileNo;
                        Session["ProfImg"] = loCredentials.ProfImg;
                        Email = pass = null;
                        if (loCredentials.ISActive == "InActive")
                        {
                            return RedirectToAction("SendOTP", "Registration", new { MailID = loCredentials.Email });
                        }

                        GetMAC(null, true);
                        if (loCredentials.UserID == 1)
                        {
                            return RedirectToAction("Index", "Deshbord", new { area = "Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Users" });
                        }
                    }
                    else
                    {
                        TempData["msg"] = "Wrong";
                        return RedirectToAction("Index");
                    }
                }
            }
            else
                return RedirectToAction("Index");
        }

        public ActionResult CheckOTP(string OTP, string txtOTP, string Email)
        {
            if (OTP == txtOTP)
            {
                new EducationDataContext().UpdateStatus(Email);
                return Json(true);
                //return View("Login");
            }
            else
            {
                return Json(false);
            }
        }

        Boolean GetMAC(string dbMAC, bool t)
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                PhysicalAddress address = adapter.GetPhysicalAddress();
                EducationDataContext loMacContext = new EducationDataContext();
                if (adapter.OperationalStatus.ToString() == "Up" && t == true && (adapter.NetworkInterfaceType.ToString() == "Ethernet" || adapter.Name == "Wi-Fi"))
                {
                    loMacContext.InsertMACAddress(address.ToString(), Session["UserID"]);
                    Session["MAC"] = address.ToString();
                    return false;
                }
                if (adapter.OperationalStatus.ToString() == "Up" && dbMAC != null && (adapter.NetworkInterfaceType.ToString() == "Ethernet" || adapter.Name == "Wi-Fi"))
                {
                    if (dbMAC == address.ToString())
                        return true;
                }
            }
            return false;
        }

        bool CheckMAC(string UserId)
        {
            EducationDataContext loCheckMacContext = new EducationDataContext();
            string dbMAC = loCheckMacContext.GetMacAddress(UserId);
            if (dbMAC == null || GetMAC(dbMAC, false))
                return true;
            else
                return false;
        }
        public ActionResult LogOut()
        {
            EducationDataContext lsLogoutContext = new EducationDataContext();
            lsLogoutContext.LogOut(Session["UserID"]);
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            ViewBag.msg = "Logged Out Successfully";
            Email = pass = null;
            return RedirectToAction("Index", "Homes");
        }

        public ActionResult LogoutFromAll()
        {
            EducationDataContext lsLogoutContext = new EducationDataContext();
            LoginModel loCredentials = new LoginModel();
            loCredentials.LoginID = Email;
            loCredentials.UPassword = pass;
            lsLogoutContext.LogOut(null, Email, pass);
            return RedirectToAction("LoginCredentials", loCredentials);
        }
        void DestroyCookies()
        {
            HttpCookie ck = new HttpCookie("Remember");
            ck.Values.Clear();
            ck.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(ck);
        }

        public ActionResult CheckUserNameExist(string lsUserName)
        {
            EducationDataContext loEduContext = new EducationDataContext();
            Boolean lbIsExistEmail = loEduContext.GetUserName(lsUserName);
            return Json(lbIsExistEmail, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Block(decimal UserID, string status)
        {
            EducationDataContext loEduContext = new EducationDataContext();
            if (status == "Block")
            {
                loEduContext.BlockUnblock(UserID, 1);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else if (status == "UnBlock")
            {
                loEduContext.BlockUnblock(UserID, 0);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}