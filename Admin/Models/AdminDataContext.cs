using OnlineEducation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineEducation.Areas.Admin.Models
{
    //Admin
    public class AdminDataContext : DbContext
    {
        public AdminDataContext()
            : base("name=ConString")
        { }
        public List<UserModel> GetUsers()
        {
            AdminDataContext dc = new AdminDataContext();
            return dc.Database.SqlQuery<UserModel>("EXEC GetUsers").ToList<UserModel>();
        }

        public List<TutorialsModel> GetTutorials()
        {
            AdminDataContext dc = new AdminDataContext();
            return dc.Database.SqlQuery<TutorialsModel>("EXEC GetTutorialsList").ToList();
        }

        public List<TutorialsModel> GetTutorialsBySearch(string Subject, string Category, string Keywords)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();
            TutorialsDataContext sqldb = new TutorialsDataContext();

            ProcParam.Add(new SqlParameter("Subject", Subject.handleDBNull()));
            ProcParam.Add(new SqlParameter("Category", Category.handleDBNull()));
            ProcParam.Add(new SqlParameter("Keywords", Keywords.handleDBNull()));            
            return new AdminDataContext().Database.SqlQuery<TutorialsModel>("GetTutorialsBySearch".getSql(ProcParam),ProcParam.ToArray()).ToList();    
        }
        public List<UserModel> RecordForDashBord()
        {
            AdminDataContext dc = new AdminDataContext();
            return dc.Database.SqlQuery<UserModel>("EXEC GetRecordForDashbord").ToList<UserModel>();
        }

        public List<UserModel> GetUsersBySearch(string Name = null, string Email = null, string Mobile = null, string Status = null)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();
           
            ProcParam.Add(new SqlParameter("Subject", Name.handleDBNull()));
            ProcParam.Add(new SqlParameter("Email", Email.handleDBNull()));
            ProcParam.Add(new SqlParameter("Mobile", Mobile.handleDBNull()));
            ProcParam.Add(new SqlParameter("Status", Status.handleDBNull()));
            return new AdminDataContext().Database.SqlQuery<UserModel>("GetUserBySearch".getSql(ProcParam), ProcParam.ToArray()).ToList();
        }
        public List<FeedBackModel> GetFeedBacksAndComplaints(decimal ComplaintID=0)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();       
            ProcParam.Add(new SqlParameter("ComplaintID", ComplaintID.handleDBNull()));
            return new AdminDataContext().Database.SqlQuery<FeedBackModel>("EXEC GetFeedBacksAndComplaints @ComplaintID", ProcParam.ToArray()).ToList();
        }
        //public List<FeedBackModel> GetComplaintsData(decimal ComplaintID = 0)
        //{
        //    List<SqlParameter> ProcParam = new List<SqlParameter>();
        //    ProcParam.Add(new SqlParameter("ComplaintID", ComplaintID.handleDBNull()));

        //    return new AdminDataContext().Database.SqlQuery<FeedBackModel>("EXEC GetFeedBacksAndComplaints @ComplaintID", ProcParam.ToArray()).ToList();
        //}
        public List<FeedBackModel> GetComplaintsList(string id=null,string status=null)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();

            ProcParam.Add(new SqlParameter("id", id.handleDBNull()));
            ProcParam.Add(new SqlParameter("status", status.handleDBNull()));

            return new AdminDataContext().Database.SqlQuery<FeedBackModel>("EXEC GetComplaintsList @id,@status",ProcParam.ToArray()).ToList();
        }  
        public void AddSolution(FeedBackModel loSolution)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();

            ProcParam.Add(new SqlParameter("ComplaintID", loSolution.ComplaintID.handleDBNull()));
            ProcParam.Add(new SqlParameter("Solution", loSolution.Solution.handleDBNull()));
            ProcParam.Add(new SqlParameter("Date", DateTime.Now.Date.ToShortDateString()));
            
            new AdminDataContext().Database.ExecuteSqlCommand("exec AddSolution @ComplaintID,@Solution,@Date", ProcParam.ToArray());
        }
    }
}