using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineEducation.Models
{
    public class ResultModel
    {
        public decimal ResultID { get; set; }
        public decimal UserID { get; set; }
        public decimal ExamTypeID { get; set; }
        public string Result { get; set; }        
        public string TimeTaken { get; set; }     
        public decimal ObtainedMarks { get; set; }
        public string Grade { get; set; }         
        public decimal Rank { get; set; }          
        public DateTime CreatedOn { get; set; }     
        public string Subject { get; set; }
        public decimal GlobalRank { get; set; }
        public string GlobalGrade { get; set; }
    }
}