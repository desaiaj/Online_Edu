using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineEducation.Models
{
    public class ExamModel
    {
        public decimal TutorialsID { get; set; }
        public decimal ExamTypeID { get; set; }
        public string Subject { get; set; }
        public decimal QueNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Question")]
        public string Question { get; set; }
        [Required(ErrorMessage = "Please Enter Answer")]
        public string Answer { get; set; }
        [Required(ErrorMessage = "Please Enter Option1")]
        public string option1 { get; set; }
        [Required(ErrorMessage = "Please Enter Option2")]
        public string option2 { get; set; }
        [Required(ErrorMessage = "Please Enter Option3")]
        public string option3 { get; set; }
        public List<ExamModel> loQA = new List<ExamModel>();
        public List<string> loAns = new List<string>();
    }
}