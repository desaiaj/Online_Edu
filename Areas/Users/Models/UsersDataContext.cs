using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineEducation.Models;
using System.Data.Entity;
using System.Data.SqlClient;

namespace OnlineEducation.Areas.Users.Models
{
    public class UsersDataContext : DbContext
    {
       public UsersDataContext()
            :base("name=ConString")
            {  }
        public List<SongsModel> GetSongs()
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();            
            return new UsersDataContext().Database.SqlQuery<SongsModel>("EXEC GetSongs").ToList();
        }
    }
}