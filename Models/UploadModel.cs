using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineEducation.Models
{
    public class UploadModel
    {
        [Required(ErrorMessage = "Select Document")]
        public HttpPostedFileBase Doc { get; set; } = null;
        public string FilePath { get; set; } 
        public string DocName { get; set; }
        [Required(ErrorMessage = "Subject Required")]
        public string Subject { get; set; } = null;
        [Required(ErrorMessage = "Category Required")]
        public string Category { get; set; } = null;
        public string Description { get; set; }
    }
}