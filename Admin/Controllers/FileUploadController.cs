using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineEducation.Models;
using System.IO;
using OnlineEducation.Service;

namespace OnlineEducation.Areas.Admin.Controllers
{
    [CommonAutoLogOutFunction]
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        public ActionResult Index()
        {
            return View("Tutorials");
        }
        [HttpPost]
        public ActionResult CheckUpload(string DocumentName)
        {
            var FlName = Path.GetFileName(DocumentName);
            var FExt = Path.GetExtension(DocumentName);

            if (FExt != null && FExt == ".doc" || FExt == ".docx" || FExt == ".pdf" || FExt == ".txt")
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        [HttpPost]
        public ActionResult NotesUpload(TutorialsModel FormData)
        {
            HttpPostedFileBase DP = FormData.Doc;

            if (DP != null && (DP.ContentLength <= 10240000 && DP.ContentType == "application/docx" || DP.ContentType == "application/pdf" || DP.ContentType == "text/plain"))
            {
                TutorialsDataContext UploadContext = new TutorialsDataContext();
                var path = Request.PhysicalApplicationPath;                
                if (!Directory.Exists(path + "Uploads"))
                    Directory.CreateDirectory(path + "Uploads");
                DP.SaveAs(path + "Uploads/" + DP.FileName);                
                UploadContext.Upload(Session["UserID"], DP.FileName, path, FormData.Subject, FormData.Category, FormData.Description);
                ViewBag.msg = path;
                ViewData["msg"] = path;                
            }
            else
            {
                ViewBag.msg = "Error occured";
                ViewData["msg"] = "Error Occured";                
            }
            return RedirectToAction("Index", "Tutorials", new { area = "Admin" });
        }
        public ActionResult EditTutorial(TutorialsModel FormData)
        {
            HttpPostedFileBase DP = FormData.Doc;
            TutorialsDataContext UploadContext = new TutorialsDataContext();
            var file="";
            var path = Request.PhysicalApplicationPath;
            if (DP != null && (DP.ContentLength <= 10240000 && DP.ContentType == "application/docx" || DP.ContentType == "application/pdf" || DP.ContentType == "text/plain"))
            {
                file = DP.FileName;
                
                if (!Directory.Exists(path + "Uploads"))
                    Directory.CreateDirectory(path + "Uploads");
                if (System.IO.File.Exists(DP.FileName))
                    System.IO.File.Move(DP.FileName, DP.FileName + "old");
                DP.SaveAs(path + "Uploads/" + DP.FileName);
            }                          
            else
            {
                file=FormData.DocName;
            }
            UploadContext.EditTutorial(Session["UserID"],FormData.TutorialsID, file, path, FormData.Subject, FormData.Category, FormData.Description);            
            return RedirectToAction("Index", "Tutorials");
        }
        public ActionResult DelTutorials(decimal TutorialsID)
        {
            TutorialsDataContext UploadContext = new TutorialsDataContext();
            TutorialsModel lotutorials = new TutorialsModel();
            lotutorials.loTutorialsData = UploadContext.DelTutorial(TutorialsID);
            return View("~/Areas/Admin/Views/Tutorials/_GetTutorialsBySearch.cshtml", lotutorials);
        }
    }
}