using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineEducation.Models
{
    public class QueryModel
    {
        public decimal QueryID { get; set; }
        public string Query { get; set; }
        public string Desc { get; set; }
        public decimal UserID { get; set; }
        public string QueryDate { get; set; }
        public DateTime dtQueryDate { get; set; }
        public int QRaises { get; set; }
        public int ARaises { get; set; }
        public string Answer { get; set; }
        public string AnsTime { get; set; }
        public DateTime dtAnsTime { get; set; }
        public string FullName { get; set; }
        public List<QueryModel> loQueryData = new List<QueryModel>();
    }
}