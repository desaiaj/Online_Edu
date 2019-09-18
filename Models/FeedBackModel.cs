using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineEducation.Models
{
    public class FeedBackModel
    {
        public decimal FeedBackID { get; set; }
        public decimal ComplaintID { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string EmailID { get; set; }
        public string FeedBackDate { get; set; }
        public string Subjet { get; set; }
        public string Solution { get; set; }
        public string ComplaintDate { get; set; } 
        public string SolutionDate { get; set; }
        public int TotalComplaints { get; set; }
        public int TotalFeedBacks { get; set; }
        public int SolvedComplaints { get; set; }
        public List<FeedBackModel> loComplaints = new List<FeedBackModel>();
        public List<UserProfileModel> loUserModel = new List<UserProfileModel>();
    }
}