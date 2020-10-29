using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineEducation.Models
{
    public class TutorialsModel
    {
        public decimal TutorialsID { get; set; }
        public decimal UserID { get; set; }

        [Required(ErrorMessage = "Select Document")]
        public HttpPostedFileBase Doc { get; set; } = null;
        public string DocName { get; set; }
        [Required(ErrorMessage = "Subject Required")]
        public string Subject { get; set; } = null;
        [Required(ErrorMessage = "Category Required")]
        public string Category { get; set; } = null;
        public string Description { get; set; }
        public DateTime UploadDate { get; set; }
        public int Likes { get; set; }
        public int TotalViews { get; set; }
        public int TotalViewed { get; set; }
        public decimal FavTutorialsID { get; set; }
        public string Favourite { get; set; }
        public string FavouriteDoc { get; set; }
        public string FavSubject { get; set; } = null;
        public string FavCategory { get; set; } = null;
        public string FavDescription { get; set; }
        public DateTime FavUploadDate { get; set; }
        public int FavLikes { get; set; }
        public int FavTotalViews { get; set; }
        public List<TutorialsModel> loTutorialsData = new List<TutorialsModel>();    
    }
}