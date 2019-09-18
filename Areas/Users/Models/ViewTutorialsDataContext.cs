using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineEducation.Models
{
    public class ViewTutorialsDataContext : DbContext
    {
        public ViewTutorialsDataContext()
            : base("name=ConString")
        { }

        public List<TutorialsModel> SearchTutorials(string Keywords,string Subject=null,string Category=null)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();

            ProcParam.Add(new SqlParameter("TutorialSearched", Subject.handleDBNull()));
            ProcParam.Add(new SqlParameter("Category", Category.handleDBNull()));
            ProcParam.Add(new SqlParameter("Keywords", Keywords.handleDBNull())); 
            return new ViewTutorialsDataContext().Database.SqlQuery<TutorialsModel>("GetTutorialsBySearch".getSql(ProcParam), ProcParam.Cast<object>().ToArray()).ToList();
        }
        public decimal TutorialsViews(decimal TutorialsID,decimal UserID)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();
            ProcParam.Add(new SqlParameter("TutorialID", TutorialsID.handleDBNull()));
            ProcParam.Add(new SqlParameter("UserID", UserID.handleDBNull()));
            var views= new ViewTutorialsDataContext().Database.SqlQuery<Int32>("TutorialsViews".getSql(ProcParam), ProcParam.Cast<object>().ToArray()).FirstOrDefault();
            
            return Convert.ToDecimal(views);
        }
        public Int32 LikeTutorials(int TutorialsID,string s)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();
            ProcParam.Add(new SqlParameter("TutorialID", TutorialsID.handleDBNull()));
            ProcParam.Add(new SqlParameter("s", (s == "Like" ? 1 : -1).handleDBNull()));

            return Convert.ToInt32(new ViewTutorialsDataContext().Database.SqlQuery<Int32>("LikeTutorials".getSql(ProcParam), ProcParam.Cast<object>().ToArray()).FirstOrDefault());
        }
        public decimal AddtoFavourite(decimal TutorialsID, decimal UserID,int s)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();
            ProcParam.Add(new SqlParameter("UserID", UserID.handleDBNull()));
            ProcParam.Add(new SqlParameter("TutorialID", TutorialsID.handleDBNull()));
            ProcParam.Add(new SqlParameter("s", s.handleDBNull()));

            return Convert.ToDecimal(new ViewTutorialsDataContext().Database.SqlQuery<Int32>("AddFavourite".getSql(ProcParam), ProcParam.Cast<object>().ToArray()).FirstOrDefault());
        }
        public List<TutorialsModel> TutorialHistory(decimal UserID,string s="H")
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();
            ProcParam.Add(new SqlParameter("UserID", UserID.handleDBNull()));
            ProcParam.Add(new SqlParameter("s", s.handleDBNull()));
            return new ViewTutorialsDataContext().Database.SqlQuery<TutorialsModel>("TutorialsHistory".getSql(ProcParam), ProcParam.Cast<object>().ToArray()).ToList();
        }
        public void RemoveFavourite(int TutorialsID, decimal UserID)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();
            ProcParam.Add(new SqlParameter("UserID", UserID.handleDBNull()));
            ProcParam.Add(new SqlParameter("TutorialID", TutorialsID.handleDBNull()));
            new ViewTutorialsDataContext().Database.ExecuteSqlCommand("RemoveFavourite".getSql(ProcParam), ProcParam.Cast<object>().ToArray());
        }        
    }
}