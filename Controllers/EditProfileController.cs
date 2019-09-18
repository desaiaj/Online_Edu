using OnlineEducation.Models;
using OnlineEducation.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Controllers
{
    [CommonAutoLogOutFunction]
    public class EditProfileController : Controller
    {
        static string img1 = null;
        // GET: EditProfile
        public ActionResult Index()
        {
            EducationDataContext EditDataContext = new EducationDataContext();
            UserModel loEditProfile = new UserModel();
            loEditProfile = EditDataContext.UserData(Session["UserID"]);
            img1 = loEditProfile.ProfImg;
            //loEditProfile.DoB = "08/08/1998";
            //loEditProfile.dtDoB = loEditProfile.dtDoB;

            return View("EditProfile", loEditProfile);
        }


        public ActionResult CheckIsImage(string DocumentName)
        {
            var FlName = Path.GetFileName(DocumentName);
            var FExt = Path.GetExtension(DocumentName);

            if (FExt != null && (FExt == ".png" || FExt == ".jpg" || FExt == ".jpeg" || FExt == ".PNG" || FExt == ".JPG" || FExt == ".JPEG"))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult EditProfile(UserModel loEditFormData)
        {
            EducationDataContext loEditContext = new EducationDataContext();
            HttpPostedFileBase Img = loEditFormData.ProfileImg;
            loEditFormData.UserID = Convert.ToDecimal(Session["UserID"]);
            if (loEditFormData.ProfImg == null)
                loEditFormData.ProfImg = img1;
            loEditContext.EditProfile(loEditFormData);

            if (Img != null && (Img.ContentLength <= 102400 && Img.ContentType == "image/png" || Img.ContentType == "image/jpg" || Img.ContentType == "image/jpeg"))
            {
                var path = Request.PhysicalApplicationPath;
                string FExt = Path.GetExtension(Img.FileName);

                if (!Directory.Exists(path + "Uploads/Profile"))
                    Directory.CreateDirectory(path + "Uploads/Profile");
                System.IO.File.Delete(path + "Uploads/Profile/" + loEditFormData.FName + " " + loEditFormData.LName + loEditFormData.UserID);                
                Img.SaveAs(path + "Uploads/Profile/" + loEditFormData.FName + " " + loEditFormData.LName + loEditFormData.UserID + FExt);
                Session["ProfImg"] = loEditFormData.FName + " " + loEditFormData.LName + loEditFormData.UserID + FExt;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
    }
}