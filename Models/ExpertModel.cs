using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineEducation.Models
{
    public class ExpertModel
    {
        public decimal UserID { get; set; }
        [Required(ErrorMessage = "Please add Expertise")]
        public string Expertise { get; set; }
        [Required(ErrorMessage ="Please add Qualificaton")]
        public string Qualification { get; set; }        
        public string Remarks { get; set; }
        public int Likes { get; set; }
        [Required(ErrorMessage ="Please Add your Status")]
        public string Status { get; set; }
        public DateTime CreatedON { get; set; }
    }
}