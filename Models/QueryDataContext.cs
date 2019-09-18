using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineEducation.Models
{
    public class QueryDataContext:DbContext
    {
        public QueryDataContext()
            :base("name=ConString")
        { }
        public int Query(QueryModel loQuery)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();
            ProcParam.Add(new SqlParameter("UserID", loQuery.UserID.handleDBNull()));
            ProcParam.Add(new SqlParameter("Query", loQuery.Query.handleDBNull()));
            ProcParam.Add(new SqlParameter("Desc", loQuery.Desc.handleDBNull()));
            ProcParam.Add(new SqlParameter("QueryTime", DateTime.Now.Date));
            ProcParam.Add(new SqlParameter("Raise", 1));
            return new EducationDataContext().Database.ExecuteSqlCommand("EXEC Query @UserID,@Query,@Desc,@QueryTime,@Raise", ProcParam.ToArray());
        }
        public int Answer(QueryModel loAnswer)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();
            ProcParam.Add(new SqlParameter("QueryID", loAnswer.QueryID.handleDBNull()));
            ProcParam.Add(new SqlParameter("Answer", loAnswer.Answer.handleDBNull()));
            ProcParam.Add(new SqlParameter("UserID", loAnswer.UserID.handleDBNull()));            
            ProcParam.Add(new SqlParameter("AnswerTime", DateTime.Now.Date));
            ProcParam.Add(new SqlParameter("Raise", 1));
            return new EducationDataContext().Database.ExecuteSqlCommand("EXEC Answer @QueryID,@Answer,@UserID,@AnswerTime,@Raise", ProcParam.ToArray());
        }

        public List<QueryModel> GetQueries(decimal QueryID=0)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();
            ProcParam.Add(new SqlParameter("QueryID", QueryID.handleDBNull()));
            return new QueryDataContext().Database.SqlQuery<QueryModel>("EXEC GetQuery @QueryID",ProcParam.ToArray()).ToList();
        }
    }
}