using OnlineEducation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;


namespace OnlineEducation.Models
{  
    public class EducationDataContext : DbContext
    {       
        public EducationDataContext()
            : base("name=ConString")
        { }   
        public string UserInsert(UserModel loRegistration)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();
            EducationDataContext sqldb = new EducationDataContext();

            ProcParam.Add(new SqlParameter("FName", loRegistration.FName.handleDBNull()));
            ProcParam.Add(new SqlParameter("LName", loRegistration.LName.handleDBNull()));
            ProcParam.Add(new SqlParameter("MobileNo", loRegistration.MobileNo.handleDBNull()));
            ProcParam.Add(new SqlParameter("Email", loRegistration.Email.handleDBNull()));
            ProcParam.Add(new SqlParameter("Gender", loRegistration.Gender.handleDBNull()));

            ProcParam.Add(new SqlParameter("UserType", "user"));
            ProcParam.Add(new SqlParameter("ProfImg",System.Configuration.ConfigurationManager.AppSettings["Default_Profile"].handleDBNull()));
            ProcParam.Add(new SqlParameter("RegDate", DateTime.Now.Date.ToString()));
            ProcParam.Add(new SqlParameter("ISActive", "InActive"));

            ProcParam.Add(new SqlParameter("UPassword", loRegistration.UPassword.handleDBNull()));
            ProcParam.Add(new SqlParameter("SecQue","security question" ));

            //ProcParam.Add(new SqlParameter("SecQue", loRegistration.SecQue));
            ProcParam.Add(new SqlParameter("SecAns", loRegistration.SecAns.handleDBNull()));

            ProcParam.Add(new SqlParameter("LearnedTime", 1));

            //procparam.add(new SqlParameter("dob", loRegistration.dob));
            //procparam.add(new SqlParameter("cityid", loRegistration.cityid));

            //if (Convert.ToBoolean(ins.Database.SqlQuery<Reg>("Rginsert".getSql(ProcParam.ToList()))))
            // if (Convert.ToBoolean(ins.Database.ExecuteSqlCommand("Rginsert".getSql(ProcParam.ToList()))))
            if (Convert.ToBoolean(sqldb.Database.ExecuteSqlCommand("exec Registration @FName,@LName,@MobileNo,@Email,@Gender,@UserType,@ProfImg,@RegDate,@ISActive,@UPassword,@SecQue,@SecAns,@LearnedTime", ProcParam.ToArray())))
                return "Successfully Registered";
            else
                return "Error Occured While Registering";
        }       

        public LoginModel CheckLogin(string loCheckCredentials)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();            
            ProcParam.Add(new SqlParameter("UserLoginID", loCheckCredentials.handleDBNull()));
            //ProcParam.Add(new SqlParameter("Password", loCheckCredentials.UPassword));           
            return new EducationDataContext().Database.SqlQuery<LoginModel>("login".getSql(ProcParam),ProcParam.Cast<object>().ToArray()).FirstOrDefault();
            //return new EducationDataContext().Database.ExecuteSqlCommand("login",ProcParam.ToList());
        }
        
        public void InsertMACAddress(string MacAddress,object UserID)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();

            ProcParam.Add(new SqlParameter("MACID", MacAddress.handleDBNull()));
            ProcParam.Add(new SqlParameter("UserID", UserID.handleDBNull()));
            //return new EducationDataContext().Database.SqlQuery<string>("insertMAC".getSql(ProcParam.ToList())).ToString();
            new EducationDataContext().Database.ExecuteSqlCommand("EXEC InsertUpdateMAC @MACID,@UserID", ProcParam.ToArray());
        }

        public string GetMacAddress(object UserID)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();
            ProcParam.Add(new SqlParameter("UserID", UserID.handleDBNull()));

            return new EducationDataContext().Database.SqlQuery<string>("GetMAC".getSql(ProcParam), ProcParam.Cast<object>().ToArray()).FirstOrDefault();
            //return new EducationDataContext().Database.SqlQuery<Login>("GetMAC".getSql(ProcParam.ToList()));
        }

        public string UpdateStatus(string Email)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();

            ProcParam.Add(new SqlParameter("Email", Email.handleDBNull()));

            if (Convert.ToBoolean(new EducationDataContext().Database.ExecuteSqlCommand("exec UpdateStatus @Email", ProcParam.ToArray())))
                return "Successfully Registered";
            else
                return "Error Occured While Registering";
        }

        public string EditProfile(UserModel loEdit)
        {
            EducationDataContext sqldb = new EducationDataContext();
            List<SqlParameter> ProcParam = new List<SqlParameter>();
            //string FileName;
            //if (loEdit.ProfileImg==null)
            //{
            //    FileName = System.Configuration.ConfigurationManager.AppSettings["Default_Profile"];
            //}
            //else
            //{
            //    FileName = loEdit.ProfileImg.FileName;
            //}

            string FileName = loEdit.ProfImg;
            if (loEdit.ProfileImg != null)
            {
                FileName = loEdit.FName + " " + loEdit.LName + loEdit.UserID + Path.GetExtension(loEdit.ProfileImg.FileName);
            }
            else
            {
                FileName = System.Configuration.ConfigurationManager.AppSettings["Default_Profile"];
            }
      
            ProcParam.Add(new SqlParameter("UserID", loEdit.UserID.handleDBNull()));
            ProcParam.Add(new SqlParameter("FName", loEdit.FName.handleDBNull()));
            ProcParam.Add(new SqlParameter("LName", loEdit.LName.handleDBNull()));
            ProcParam.Add(new SqlParameter("MobileNo", loEdit.MobileNo.handleDBNull()));
            ProcParam.Add(new SqlParameter("Email", loEdit.Email.handleDBNull()));
            ProcParam.Add(new SqlParameter("DoB", loEdit.DoB.handleDBNull()));
            ProcParam.Add(new SqlParameter("City", loEdit.City.handleDBNull()));
            ProcParam.Add(new SqlParameter("profileImg", FileName.handleDBNull()));
            ProcParam.Add(new SqlParameter("UPassword", loEdit.UPassword.handleDBNull()));

            if (Convert.ToBoolean(sqldb.Database.ExecuteSqlCommand("exec UpdateProfile @UserID,@FName,@LName,@MobileNo,@Email,@DoB,@City,@profileImg,@UPassword", ProcParam.ToArray())))
                return "Successfully Registered";
            else
                return "Error Occured While Registering";
        }
        public void FeedBack(FeedBackModel loFeedBack, string c = null)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();
            ProcParam.Add(new SqlParameter("EmailID", loFeedBack.EmailID.handleDBNull()));
            ProcParam.Add(new SqlParameter("Name", loFeedBack.UserName.handleDBNull()));
            ProcParam.Add(new SqlParameter("Subjet", loFeedBack.Subjet.handleDBNull()));
            ProcParam.Add(new SqlParameter("Description", loFeedBack.Description.handleDBNull()));
            ProcParam.Add(new SqlParameter("Date", DateTime.Now.Date));
            ProcParam.Add(new SqlParameter("check", c));
            new EducationDataContext().Database.ExecuteSqlCommand("EXEC FeedBackandComplaints @EmailID,@Name,@Subjet,@Description,@Date,@check", ProcParam.ToArray());
        }

        public UserModel UserData(object UserID)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();
            EducationDataContext sqldb = new EducationDataContext();

            ProcParam.Add(new SqlParameter("UserID", UserID.handleDBNull()));
            return new EducationDataContext().Database.SqlQuery<UserModel>("GetUserData".getSql(ProcParam), ProcParam.Cast<object>().ToArray()).FirstOrDefault();
        }

        //public string UploadDB()
        //{
        //    SqlConnection con = new SqlConnection();
        //    return null;
        //}

        public void LogOut(object UserID=null,string Email=null,string pass=null)
        {
            EducationDataContext sqldb = new EducationDataContext();
            List<SqlParameter> ProcParam = new List<SqlParameter>();

            ProcParam.Add(new SqlParameter("UserID", UserID.handleDBNull()));
            ProcParam.Add(new SqlParameter("Email", Email.handleDBNull()));
            ProcParam.Add(new SqlParameter("pass", pass.handleDBNull()));
            new EducationDataContext().Database.ExecuteSqlCommand("EXEC LogOutUser @UserID,@Email,@pass", ProcParam.ToArray());
        }

        public Boolean GetEmail(string lsEmailID)
        {
            EducationDataContext sqldb = new EducationDataContext();
            List<SqlParameter> ProcParam = new List<SqlParameter>();

            ProcParam.Add(new SqlParameter("EmailID", lsEmailID.handleDBNull()));

            var e = new EducationDataContext().Database.SqlQuery<string>("EXEC GetEmailForValidation @EmailID", ProcParam.ToArray()).FirstOrDefault();
            if (e == null)
                return false;
            else
                return true;
        }

        public Boolean GetMobile(string lsMobile)
        {
            EducationDataContext sqldb = new EducationDataContext();
            List<SqlParameter> ProcParam = new List<SqlParameter>();

            
            ProcParam.Add(new SqlParameter("Mobile", lsMobile.handleDBNull()));

            var e = new EducationDataContext().Database.SqlQuery<Decimal>("GetMobileForValidation".getSql(ProcParam), ProcParam.Cast<object>().ToArray()).FirstOrDefault();
            if (e<1)
                return false;
            else
                return true;
        }

        public Boolean GetUserName(string lsUserName)
        {
            EducationDataContext sqldb = new EducationDataContext();
            List<SqlParameter> ProcParam = new List<SqlParameter>();

            ProcParam.Add(new SqlParameter("UserName", lsUserName.handleDBNull()));

            var u = new EducationDataContext().Database.SqlQuery<string>("EXEC GetUserNameForValidation @UserName", ProcParam.ToArray()).FirstOrDefault();
            if (u == null)
                return true;
            else
                return false;
        }

        public int BlockUnblock(decimal UserID,decimal Flag)
        {
            List<SqlParameter> ProcParam = new List<SqlParameter>();

            ProcParam.Add(new SqlParameter("UserID", UserID.handleDBNull()));
            ProcParam.Add(new SqlParameter("Flag", Flag.handleDBNull()));
            ProcParam.Add(new SqlParameter("BlockedDate", DateTime.Now.Date));
            ProcParam.Add(new SqlParameter("tillDate", DateTime.Now.Date.AddDays(5)));
            ProcParam.Add(new SqlParameter("Details", "Blocked"));

            return new EducationDataContext().Database.ExecuteSqlCommand("EXEC BlockUser @UserID,@Flag,@BlockedDate,@tillDate,@Details", ProcParam.ToArray()); ;
        }
        //public Boolean IsValidPassword(string lsUserName, string lsPassword)
        //{
        //    EducationDataContext sqldb = new EducationDataContext();
        //    List<SqlParameter> ProcParam = new List<SqlParameter>();

        //    ProcParam.Add(new SqlParameter("UserName", lsUserName));
        //    ProcParam.Add(new SqlParameter("Password", lsPassword));

        //    var u = new EducationDataContext().Database.SqlQuery<string>("EXEC GetForValidation @UserName @Password", ProcParam.ToArray()).FirstOrDefault();
        //    if (u == null)
        //        return false;
        //    else
        //        return true;
        //}
        public List<UserProfileModel> UserProfile(decimal UserID)
        {             
            List<SqlParameter> ProcParam = new List<SqlParameter>();
            ProcParam.Add(new SqlParameter("UserID", UserID.handleDBNull()));
            return new EducationDataContext().Database.SqlQuery<UserProfileModel>("Profile".getSql(ProcParam), ProcParam.Cast<object>().ToArray()).ToList();
        }

        public List<UserProfileModel> UserDataForIndex()
        {
            return new EducationDataContext().Database.SqlQuery<UserProfileModel>("Exec GetUsersForIndex").ToList();
        }
    }
}