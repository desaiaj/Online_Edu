using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineEducation.Models
{
    public class ErrorTrackingModel
    {
        public ErrorTrackingModel()
        {
            gaParameterNameValuePair = new Dictionary<string, string>();
        }

        public string stStoredProcedureName { get; set; }
        public Dictionary<string, string> gaParameterNameValuePair { get; set; }
    }
}