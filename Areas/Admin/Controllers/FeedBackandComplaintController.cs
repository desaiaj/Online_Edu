using OnlineEducation.Areas.Admin.Models;
using OnlineEducation.Models;
using OnlineEducation.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Areas.Admin.Controllers
{
    [CommonAutoLogOutFunction]
    public class FeedBackandComplaintController : Controller
    {
        // GET: Admin/FeedBackandComplaint
        public ActionResult Index()
        {
            AdminDataContext loAdminContext = new AdminDataContext();
            FeedBackModel loFeedBack = new FeedBackModel();
            loFeedBack.loComplaints = loAdminContext.GetComplaintsList();
            var s = 0;
            var U = 0;
            foreach (var data in loFeedBack.loComplaints)
            {
                if (data.Solution == null)
                    U++;
                else
                    s++;
            }
            ViewBag.Solved = s;
            ViewBag.UnSolved = U;
            ViewBag.TotalComplaints = loFeedBack.loComplaints.Count();
            return View(loFeedBack);
        }
        public ActionResult AddSolution(FeedBackModel loSolution)
        {
            AdminDataContext loAdminContext = new AdminDataContext();
            loAdminContext.AddSolution(loSolution);

            SmtpClient Client = new SmtpClient("smtp.gmail.com");
            Random rnd = new Random();
            string to = loSolution.EmailID;
            string from = "onlineeduhub2016@gmail.com";//"ajay.megaminds@gmail.com";
            string subject = "Solution for Complaint on Online Education System";
            string body = "<font>Hello dear " + loSolution.UserName + "<br /> Thanks for Contacting Us<br /><p> As your Complaint for Complaint ID - " + loSolution.ComplaintID + " as " + loSolution.Subjet + "we have tried to solve your complaint. The Solution is as below <br /></p><p>" + loSolution.Solution + "</p>Hope It will helpful to you <br/> </r>Thanks From Edu Team</font>";
            MailMessage mail = new MailMessage(from, to, subject, body);
            mail.IsBodyHtml = true;
            Client.EnableSsl = true;
            
            Client.Port = 443;
            Client.UseDefaultCredentials = false;
            Client.DeliveryMethod = SmtpDeliveryMethod.Network;
            Client.Credentials = new NetworkCredential("onlineeduhub2016@gmail.com","Admin.Online");//("ajay.megaminds@gmail.com", "CFvgbhnj12#");
            Client.Send(mail);
            ViewBag.msg = "Email Sent";

            return RedirectToAction("Index");
        }
        public ActionResult GetComplaints(string ID,string status)
        {
            AdminDataContext loAdminContext = new AdminDataContext();
            FeedBackModel loFeedBack = new FeedBackModel();
            loFeedBack.loComplaints = loAdminContext.GetComplaintsList((ID == "") ? null : ID, (status == "") ? null : status);
            return View("~/Areas/Admin/Views/FeedBackandComplaint/_GetComplaintsForSearch.cshtml",loFeedBack);
        }
    }
}