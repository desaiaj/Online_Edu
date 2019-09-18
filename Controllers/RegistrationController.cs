using OnlineEducation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Controllers
{
    public class RegistrationController : Controller
    {

        public static string OTP = null;
        public static string Email = null;
        // GET: Registration
        public ActionResult Index()
        {
            return View("RForm");
        }

        public ActionResult checkUserName()
        {
            EducationDataContext loLoginIdContext = new EducationDataContext();
            return null;
        }
        public ActionResult AddUser(UserModel loRegFormData)
        {
            EducationDataContext loEduContext = new EducationDataContext();
            SendOTP(loRegFormData.Email);
            //ViewBag.Email = loRegFormData.Email;
            ViewBag.msg = loEduContext.UserInsert(loRegFormData);
            return RedirectToAction("Confirmation");
        }

        public ActionResult Confirmation(string t = null)
        {
            if (t == "true")
                OTP = null;
            TempData["OTP"] = OTP;//TempData["GOTP"];
            TempData["Email"] = Email;//TempData["GEmail"];
            return View("OTP");
        }
        
        public ActionResult SendOTPforJson(string EmlID)
        {
            SendOTP(EmlID);
            return Json(OTP);
        }
        
        public ActionResult SendOTP(string MailID)
        {

            if (MailID != null && MailID != "") 
            {
                SmtpClient Client = new SmtpClient("smtp.gmail.com");
                Random rnd = new Random();
                OTP = rnd.Next(100000, 999999).ToString();//rnd.Next(1, 10).ToString() + rnd.Next(10).ToString() + rnd.Next(10).ToString() + rnd.Next(10).ToString() + rnd.Next(10).ToString() + rnd.Next(10).ToString();
                //TempData["GOTP"] = OTP;
                Email = MailID;
                string to = MailID;//Request.QueryString["Email"];//TempData["Email"].ToString(); //Profile.GetPropertyValue("Email").ToString(); "ajaydesai157@gmail.com";
                string from = "onlineeduhub2016@gmail.com";//"ajay.megaminds@gmail.com";
                string subject = "OTP for Online Education System";
                string body = @"This is system Automated generated Mail. Please Do Not Reply it  Your OTP Is " + OTP;
                MailMessage mail = new MailMessage(from, to, subject, body);
                Client.EnableSsl = true;
                Client.Port = 443;
                Client.UseDefaultCredentials = false;
                Client.DeliveryMethod = SmtpDeliveryMethod.Network;
                Client.Credentials = new NetworkCredential("onlineeduhub2016@gmail.com", "Admin.Online");//("ajay.megaminds@gmail.com", "CFvgbhnj12#");
                Client.Send(mail);
                ViewBag.msg = "Email Sent";                
            }
            //TempData["OTP"] = 123456;
            return RedirectToAction("Confirmation");
        }


        [HttpGet]
        public ActionResult CheckEmailExist(string lsEmailID)
        {
            EducationDataContext loEduContext = new EducationDataContext();
            Boolean lbIsExistEmail = loEduContext.GetEmail(lsEmailID);
            return Json(lbIsExistEmail, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult CheckMobileExist(string lsMobile)
        {
            EducationDataContext loEduContext = new EducationDataContext();
            Boolean lbIsExistMobile = loEduContext.GetMobile(lsMobile);
            return Json(lbIsExistMobile, JsonRequestBehavior.AllowGet);
        }
    }
}