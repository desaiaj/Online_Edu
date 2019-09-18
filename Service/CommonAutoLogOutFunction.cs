using OnlineEducation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineEducation.Service
{
    public class UserDataContext : DbContext
    {
        public UserDataContext()
            :base("name=ConString")
        { }

        public string CheckLogin(object UserID)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();
            ProcParam.Add(new SqlParameter("UserID", UserID.handleDBNull()));            
            return new EducationDataContext().Database.SqlQuery<string>("GetMAC".getSql(ProcParam), ProcParam.Cast<object>().ToArray()).FirstOrDefault();
        }
    }
    public class CommonAutoLogOutFunction : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            UserDataContext UContext = new UserDataContext();
            if ((HttpContext.Current.Session["UserID"] == null && filterContext.RequestContext.HttpContext.Request.IsAjaxRequest()) && filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                HttpContext.Current.Response.StatusCode = 403;
                HttpContext.Current.Response.Write("Authentication Failed");
                HttpContext.Current.Response.End();
            }

            if (HttpContext.Current.Session["UserID"] == null || HttpContext.Current.Session["MAC"]==null || HttpContext.Current.Session["MAC"].ToString()!=UContext.CheckLogin(HttpContext.Current.Session["UserID"]))
            {
                if (!string.IsNullOrEmpty(HttpContext.Current.Request.RawUrl))
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "returnUrl", HttpContext.Current.Request.RawUrl }, { "controller", "Login" }, { "action", "Login" }, { "area", "" } });
            }
            //else
            //{
            //    LoginModel loUserSessionModel = (LoginModel)HttpContext.Current.Session["UserID"];

            //    if (!string.IsNullOrEmpty(HttpContext.Current.Request.RawUrl))
            //    {
            //        if (HttpContext.Current.Request.RawUrl.ToLower().Contains(CommonConstants.UrlString.Admin.ToLower()))
            //        {

            //        }
            //        else
            //        {

            //        }
            //    }

            //}

            if (HttpContext.Current.Session["errorTracking"] != null)
                HttpContext.Current.Session["errorTracking"] = null;

            base.OnActionExecuting(filterContext);
        }
    }
}