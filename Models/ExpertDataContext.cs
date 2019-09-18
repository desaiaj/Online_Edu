using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineEducation.Models
{
    public class ExpertDataContext : DbContext
    {
        public ExpertDataContext()
            : base("name=ConString")
        { }
        public string BecomeExpert(ExpertModel loExpertData)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();

            ProcParam.Add(new SqlParameter("UserID", loExpertData.UserID.handleDBNull()));
            ProcParam.Add(new SqlParameter("Expertise", loExpertData.Expertise.handleDBNull()));
            ProcParam.Add(new SqlParameter("Qualification", loExpertData.Qualification.handleDBNull()));
            ProcParam.Add(new SqlParameter("Remarks", loExpertData.Remarks.handleDBNull()));
            ProcParam.Add(new SqlParameter("Likes", 1));
            ProcParam.Add(new SqlParameter("Status", loExpertData.Status.handleDBNull()));
            ProcParam.Add(new SqlParameter("CreatedON", DateTime.Now.Date.handleDBNull()));
            if (Convert.ToBoolean(new ExpertDataContext().Database.ExecuteSqlCommand("EXEC RequestExpert @UserID,@Expertise,@Qualification,@Remarks,@Likes,@Status,@CreatedON", ProcParam.ToArray())))
                return "Successfully Registered";
            else
                return "Error Occured While Registering";
        }
        public DateTime CheckEliligibility(decimal UserID)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();
            ProcParam.Add(new SqlParameter("UserID", UserID.handleDBNull()));
            //var d = new ExamDataContext().Database.SqlQuery<DateTime>("GetUserRegDate".getSql(ProcParam), ProcParam.Cast<object>().ToArray());
            return Convert.ToDateTime(new ViewTutorialsDataContext().Database.SqlQuery<DateTime>("GetUserRegDate".getSql(ProcParam), ProcParam.Cast<object>().ToArray()).FirstOrDefault());
        }
    }
}