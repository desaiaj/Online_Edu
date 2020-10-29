using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineEducation.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please Enter User ID")]
        public string LoginID { get; set; } = null;
        public Decimal UserID { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Please enter minimum 8 characters Password")]
        public string UPassword { get; set; } = null;
        public Decimal MobileNo { get; set; }
        public string Email { get; set; }
        public string MAC { get; set; }
        public string ISActive { get; set; }
        public decimal BlockID { get; set; }
        public string ErrorMessage { get; set; }
        public string FullName { get; set; }
    }
}