using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineEducation.Models
{
    public class UploadDataContext : DbContext
    {
        public UploadDataContext()
            : base("name=ConString")
        { }
        public string Upload(object UserID,string FileName,string path,string Subject,string Category,string Description)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();
            UploadDataContext sqldb = new UploadDataContext();

            ProcParam.Add(new SqlParameter("UserID",UserID=1));
            ProcParam.Add(new SqlParameter("FileName",FileName.handleDBNull()));
            ProcParam.Add(new SqlParameter("path",path.handleDBNull()));
            ProcParam.Add(new SqlParameter("Subject",Subject.handleDBNull()));
            ProcParam.Add(new SqlParameter("Category",Category.handleDBNull()));
            ProcParam.Add(new SqlParameter("Description",Description.handleDBNull()));
            ProcParam.Add(new SqlParameter("UploadDate", DateTime.Now.Date));

            new UploadDataContext().Database.ExecuteSqlCommand("EXEC InsertTutorials @UserID,@FileName,@path,@Subject,@Category,@Description,@UploadDate", ProcParam.ToArray());
            //new UploadDataContext().Database.SqlQuery<string>("InsertTutorials".getSql(ProcParam),ProcParam.ToArray()).FirstOrDefault();
            return null;                                                              
        }                                                                             
    }                                                                                 
}                                                                                     