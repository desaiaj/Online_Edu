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
    public class QueryController : Controller
    {
        // GET: Users/Query
        public ActionResult Index()
        {
            return View("AskQuestion");
        }
        //get Queries
        public ActionResult Queries()
        {
            QueryDataContext loQueryContext = new QueryDataContext();
            List<QueryModel> loQueries = new List<QueryModel>();
            loQueries = loQueryContext.GetQueries();
            return View(loQueries);
        }
        //Add new Query
        public ActionResult AddQuery(QueryModel loQueryData)
        {
            QueryDataContext loQueryContext = new QueryDataContext();
            loQueryData.UserID = Convert.ToDecimal(Session["UserID"]);
            //loQueryData.Query += loQueryData.Desc;
            loQueryContext.Query(loQueryData);
            return RedirectToAction("Queries");
        }
        //Get Ans With Query
        public ActionResult Answer(decimal QueryID=0)
        {
            QueryDataContext loQueryContext = new QueryDataContext();
            QueryModel loQuery = new QueryModel();
            loQuery.loQueryData = loQueryContext.GetQueries(QueryID);
            return View("Answer", loQuery);
        }
        //Add new Answer
        public ActionResult AddAnswer(QueryModel loAnsData)
        {
            QueryDataContext loAnsContext = new QueryDataContext();
            loAnsData.UserID = Convert.ToDecimal(Session["UserID"]);
            loAnsContext.Answer(loAnsData);
            return RedirectToAction("Answer", new { QueryID = loAnsData.QueryID });
        }
    }
}