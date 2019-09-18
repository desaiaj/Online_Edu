using OnlineEducation.Models;
using OnlineEducation.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Areas.Users.Controllers
{
    [CommonAutoLogOutFunction]
    public class ExamController : Controller
    {
        static DateTime time = new DateTime();
        static List<string> lsExamQA = new List<string>();
        // GET: Exam
        public ActionResult Index()
        {
            ExamDataContext loExamConext = new ExamDataContext();
            List<ExamModel> loExamModel = new List<ExamModel>();
            loExamModel = loExamConext.GetExamList();
            return View(loExamModel);
        }

        public ActionResult GenerateExamPaper(string ExamID)
        {
            Random rnd = new Random();
            ExamDataContext loExamContext = new ExamDataContext();
            ExamModel loExamModel = new ExamModel();
            //List<ExamModel> lsExamModel = new List<ExamModel>();
            loExamModel.loQA = loExamContext.GenerateExamPaper(Convert.ToDecimal(ExamID));
            var i = 0;
            List<string> options = new List<string>();
            string UserID = Convert.ToString(Session["UserID"]);
            lsExamQA.Insert(0,UserID);

            foreach (var op in loExamModel.loQA)
            {
                options.Add(op.option1);
                options.Add(op.option2);
                options.Add(op.option3);
                options.Add(op.Answer);

                lsExamQA.Add(op.QueNumber.ToString() + op.Answer);
                //lsExamQA.Add(op.Answer);

                int n = 4;
                var indx = rnd.Next(n);

                loExamModel.loQA[i].Answer = options[indx].ToString();
                options.RemoveAt(indx);
                indx = rnd.Next(--n);

                loExamModel.loQA[i].option1 = options[indx].ToString();
                options.RemoveAt(indx);
                indx = rnd.Next(--n);

                loExamModel.loQA[i].option2 = options[indx].ToString();
                options.RemoveAt(indx);
                indx = rnd.Next(--n);

                loExamModel.loQA[i].option3 = options[indx].ToString();
                i++;
                options.Clear();
            }
            time = DateTime.Now ;
            return View(loExamModel);
        }

        public ActionResult GenerateExam()
        {
            return View("InsertQuestion");
        }
        public ActionResult InsertQuestion(ExamModel loExam)
        {
            ExamDataContext loExamContext = new ExamDataContext();
            TempData["msg"] = loExamContext.InsertQuestion(loExam);
            return RedirectToAction("GenerateExam");
        }
        public ActionResult Result()
        {
            ExamDataContext loExamContext = new ExamDataContext();
            List<ResultModel> loResult = new List<ResultModel>();
            loResult = loExamContext.GetResult(Convert.ToDecimal(Session["UserID"]));
            lsExamQA.Clear();
            return View(loResult);
        }
        public ActionResult GenerateResult(FormCollection Form)
        {
            ResultModel loResult = new ResultModel();
            ExamDataContext loExamContext = new ExamDataContext();
            List<string> loFormData = new List<string>();
            loFormData.Add(Session["UserID"].ToString());
            var Right = 0;
            var wrong = 0;
            for (var i = 0; i < 3; i++) 
            {
                var QueNumber = "QueNumber" + (i + 1);
                var Options = "Options" + (i + 1);
                loFormData.Add(string.Concat(Form[QueNumber],Form[Options]));                
            }

            for (var i = 1; i <= 3; i++) 
            {
                if (lsExamQA[i] == loFormData[i])
                {
                    Right++;
                }
                else
                {
                    wrong++;
                }
            }

            loResult.UserID = Convert.ToDecimal(Session["UserID"]);
            loResult.ExamTypeID =Convert.ToDecimal(Form["ExamType"]);
            loResult.Result = (Right >= 8) ? "Pass" : "Fail";
            loResult.TimeTaken = DateTime.Now.Subtract(time).ToString(); 
            loResult.ObtainedMarks = Right;
            loResult.Grade = (Right >= 15) ? "A" : (Right >= 10) ? "B" : (Right >= 5) ? "C" : (Right > 0) ? "D" : "E";
            loResult.Rank = (Right >= 18) ? 1 : (Right >= 15) ? 2 : (Right >= 11) ? 3 : (Right >= 8) ? 4 : 0;
            loResult.CreatedOn = DateTime.Now.Date;
            
            loExamContext.GenerateResult(loResult);

            return RedirectToAction("Result");
        }    
    }
}