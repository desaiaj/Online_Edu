using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineEducation.Models
{
    public class UserProfileModel
    {
        public decimal UserID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string UserType { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public HttpPostedFileBase ProfImg { get; set; }
        public string ProfileImg { get; set; }
        public DateTime? RegDate { get; set; }
        public decimal? LearnedTime { get; set; }
        public decimal? QueryID { get; set; }
        public string Query { get; set; }
        public string Desc { get; set; }
        public string stQueryTime { get; set; }
        public DateTime? QueryTime { get; set; }
        public decimal? QRaises { get; set; }
        public decimal? ARaises { get; set; }
        public string Answer { get; set; }
        public string AnsTime { get; set; }
        public DateTime? dtAnsTime { get; set; }
        public decimal? ExamTypeID { get; set; }
        public decimal? ResultID { get; set; }
        public string Result { get; set; }
        public string TimeTaken { get; set; }
        public decimal? ObtainedMarks { get; set; }
        public string Grade { get; set; }
        public decimal Rank { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Subject { get; set; }
        public decimal? GlobalRank { get; set; }
        public string GlobalGrade { get; set; }
        public int Tutorials { get; set; }
        public int AnswersGiven { get; set; }
        public int TotalExams { get; set; }
    }
}
