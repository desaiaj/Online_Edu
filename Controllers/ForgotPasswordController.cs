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
    public class ForgotPasswordController : Controller
    {
        public static string OTP = null;
        public static string Email = null;
        // GET: ForgotPassword
        public ActionResult Index()
        {
            TempData["FEmail"] = Email;
            TempData["OTP"] = OTP;
            return View();
        }
        public ActionResult expire(string t=null)
        {
            if (t == "true")
                OTP = null;
            TempData["OTP"] = OTP;
            TempData["Email"] = Email;
            return RedirectToAction("Index");
        }
        public ActionResult Confirmation(FormCollection Form)
        {
            if (OTP == Form["txtOTP"])
                return RedirectToAction("ChangePassword");
            else
                return RedirectToAction("Index");
        }
        public ActionResult SendOTPforJson(string EmlID)
        {
            SendOTP(null,EmlID);
            return Json(OTP);
        }
        public ActionResult SendOTP(FormCollection formdata, string Mail=null)
        {            
            string MailID = (Mail==null)?formdata["Email"]:Mail;
            
            if (MailID != null)
            {
                SmtpClient Client = new SmtpClient("smtp.gmail.com");
                Random rnd = new Random();
                OTP = rnd.Next(100000, 999999).ToString();
                Email = MailID;
                string to = MailID;
                string from = "onlineeduhub2016@gmail.com"; //"ajay.megaminds@gmail.com";
                string subject = "OTP for Online Education System";
                string body = "This is system Automated generated Mail. Please Do Not Reply it <br/>  Your OTP for Forgot Password Is" + OTP;
                MailMessage mail = new MailMessage(from, to, subject, body);
                mail.IsBodyHtml = true;
                Client.EnableSsl = true;
                Client.Port = 587;
                Client.UseDefaultCredentials = false;
                Client.DeliveryMethod = SmtpDeliveryMethod.Network;
                Client.Credentials = new NetworkCredential("onlineeduhub2016@gmail.com", "Admin.Online");//("ajay.megaminds@gmail.com", "CFvgbhnj12#");
                Client.Send(mail);
                ViewBag.msg = "Email Sent";
            }            
            return RedirectToAction("index");
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult UpdatePassword(UserModel loUserData)
        {
            EducationDataContext loEduContext = new EducationDataContext();
            loUserData.Email = Email;
            loEduContext.UpdatePassword(loUserData);
            OTP = null;
            Email = null;
            return RedirectToAction("Index","Login");
        }
    }
}