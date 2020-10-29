using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducation.Models
{
    public class UserModel
    {
        public Decimal UserID { get; set; }

        //[StringLength(10, MinimumLength = 10, ErrorMessage = "test2")]
        [RegularExpression(@"^[A-Za-z]*$", ErrorMessage = "Please Enater Only Char")]
        [Required(ErrorMessage = "Please Enter First Name")]
        public string FName { get; set; }

        [RegularExpression(@"^[A-Za-z]*$", ErrorMessage = "Please Enater Only Char")]
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LName { get; set; }

        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Please Enater 10 Digit")]
        [Required(ErrorMessage = "Please Enter Mobile Number")]
        public Decimal MobileNo { get; set; }

        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }

        public string Gender { get; set; }
        //[DataType(DataType.Date)]
        public string DoB { get; set; }
        public string UserType { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }
        public HttpPostedFileBase ProfileImg { get; set; }
        public string ProfImg { get; set; }
        public HttpPostedFileBase ImgFile { get; set; }

        public DateTime RegDate { get; set; }
        public string ISActive { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Please enter minimum 8 characters Password")]
        public string UPassword { get; set; }

        [Required(ErrorMessage = "Please Enter Repassword")]
        [System.ComponentModel.DataAnnotations.Compare("UPassword", ErrorMessage = "Password does not match")]
        public string Repassword { get; set; }
        public decimal LearnedTime { get; set; }

        public DateTime dtDoB { get; set; }

        [Required(ErrorMessage = "Please Select Sequrity Quetion")]
        public string SecQue { get; set; }

        [Required(ErrorMessage = "Please Enter Sequrity Answre")]
        public string SecAns { get; set; }
        public int ActiveUsers { get; set; }
        public decimal? BlockID { get; set; }
        public int DeactiveUsers { get; set; }
        public int TotalBlocked { get; set; }

        public List<UserModel> UserDetail = new List<UserModel>();
    }
}