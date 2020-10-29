using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineEducation.Models
{
    public class ExpertModel
    {
        public decimal UserID { get; set; }
        public string Expertise { get; set; }
        public string Qualification { get; set; }
        public string Remarks { get; set; }
        public int Likes { get; set; }
        public string Status { get; set; }
        public DateTime CreatedON { get; set; }
    }
}