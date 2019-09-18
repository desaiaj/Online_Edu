using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Globalization;
using System.Net;
using System.Text;

namespace OnlineEducation.Models
{
    public static class Helper
    {
        /// <summary>
        /// Handle the Database NULL Value for the Sql Value
        /// </summary>
        /// <param name="foValue">object which may have DBNUll</param>  
        public static object handleDBNull(this object foValue)
        {
            if (foValue == null)
            {
                return DBNull.Value;
            }
            return foValue;
        }

        /// <summary>
        /// Generate SQL Statement from all it's parameter and procedure name
        /// </summary>
        /// <param name="foStoreProcedureName">Database procedure name</param> 
        /// <param name="foParameters">List of Sql Parameters</param> 
        public static string getSql(this string foStoreProcedureName, List<SqlParameter> foParameters = null)
        {
            string lsSPParameter = string.Empty;
            List<ErrorTrackingModel> laErrorTrackingModels = new List<ErrorTrackingModel>();
            ErrorTrackingModel laErrorTrackingModel = new ErrorTrackingModel();

            laErrorTrackingModel.stStoredProcedureName = foStoreProcedureName;

            if (foParameters != null)
            {
                for (int liIndex = 0; liIndex < foParameters.Count; liIndex++)
                {

                    laErrorTrackingModel.gaParameterNameValuePair.Add(foParameters[liIndex].ParameterName.ToString(), foParameters[liIndex].Value == null ? "" : Convert.ToString(foParameters[liIndex].Value));

                    if (liIndex > 0)
                    {
                        lsSPParameter += ", @" + foParameters[liIndex].ParameterName; ;
                    }
                    else
                    {
                        lsSPParameter += " @" + foParameters[liIndex].ParameterName;
                    }
                    if (foParameters[liIndex].Direction == System.Data.ParameterDirection.Output)
                    {
                        lsSPParameter += " OUT ";
                    }
                }
            }

            //if (HttpContext.Current.Session["errorTracking"] != null)
            //{
            //    laErrorTrackingModels = (List<ErrorTrackingModel>)HttpContext.Current.Session["errorTracking"];
            //    laErrorTrackingModels.Add(laErrorTrackingModel);
            //    HttpContext.Current.Session["errorTracking"] = laErrorTrackingModels;
            //}
            //else
            //{
            //    laErrorTrackingModels.Add(laErrorTrackingModel);
            //    HttpContext.Current.Session["errorTracking"] = laErrorTrackingModels;
            //}

            return "EXEC [" + foStoreProcedureName + "]" + lsSPParameter;
        }

        /// <summary>
        /// Replacement for Convert.ToInt32 with Null & Empty As 0
        /// </summary>
        /// <param name="fsValue">Source string (can be Null or Empty).</param> 
        public static int toInt(this string fsValue)
        {
            if (string.IsNullOrEmpty(fsValue))
            {
                fsValue = "0";
            }
            return Convert.ToInt32(fsValue);
        }

        /// <summary>
        /// Replacement for Convert.ToString 
        /// </summary>
        /// <param name="fsValue">Source string (can be Null or Empty).</param> 
        public static string toSafeString(this string fsValue)
        {
            if (string.IsNullOrEmpty(fsValue))
            {
                fsValue = "";
            }
            return Convert.ToString(fsValue);
        }

        /// <summary>
        /// Replacement for Convert.ToString 
        /// </summary>
        /// <param name="fsValue">Source string (can be Null or Empty).</param> 
        public static string toSafeTrim(this string fsValue)
        {
            if (!string.IsNullOrEmpty(fsValue))
                return fsValue.ToString().Trim();
            else
                return string.Empty;
        }


        /// <summary>
        /// Replacement for String.Split with null handling
        /// </summary>
        /// <param name="fsValue">Source string (can be Null or Empty).</param> 
        /// <param name="foSeparator">An array of Unicode characters that delimit the substrings in this instance.</param> 
        public static string[] splitNullSafe(this string fsValues, params char[] foSeparator)
        {
            if (fsValues == null)
                return new string[0];

            return fsValues.Split(foSeparator);
        }

        /// <summary>
        /// Trim all the element of string array
        /// </summary> 
        /// <param name="fsValues">An array of string which need to be trimmed</param> 
        public static string[] trimAll(this string[] fsValues)
        {
            for (int i = 0; i < fsValues.Count(); i++)
            {
                fsValues[i] = fsValues[i].Trim();
            }
            return fsValues;
        }

        /// <summary>
        /// Skip null or empty Element from string array
        /// </summary> 
        /// <param name="fsValues">An array of string which need to be skipped for Null Or Empty</param> 
        public static string[] skipNullOrEmpty(this string[] fsValues)
        {
            List<string> loList = fsValues.ToList();
            loList.RemoveAll(str => String.IsNullOrEmpty(str));
            return loList.ToArray();
        }

        ///// <summary>
        ///// Split with trimmed string array without null or empty element 
        ///// </summary> 
        ///// <param name="fsValues">An array of string which need to be skipped for Null Or Empty</param> 
        public static string[] splitToTrimmedNonEmptyStringList(this string str, params char[] separators)
        {
            return str.splitNullSafe(separators).trimAll().skipNullOrEmpty();
        }

        ///// <summary>
        ///// Split with trimmed string array without null or empty element 
        ///// </summary> 
        ///// <param name="fsValue">Source string (can be Null or Empty).</param> 
        ///// <param name="foSeparator">An array of Unicode characters that delimit the substrings in this instance.</param> 
        public static IList<int> splitToInts(this string fsValue, params char[] foSeparator)
        {
            return (from x in fsValue.splitToTrimmedNonEmptyStringList(foSeparator)
                    let id = x.toInt()
                    select id).ToList();
        }

        /// <summary>
        /// Convert to Json Serialized data
        /// </summary> 
        /// <param name="fsValue">Source object.</param> 
        public static string toJSON(this object foValue)
        {
            JavaScriptSerializer loJavaScriptSerializer = new JavaScriptSerializer();
            return loJavaScriptSerializer.Serialize(foValue);
        }

        /// <summary>
        /// Convert to Json Serialized data with Recursion Limit
        /// </summary> 
        /// <param name="fsValue">Source object.</param> 
        /// <param name="fiRecursionLimit">Recursion Limit</param> 
        public static string toJSON(this object foValue, int fiRecursionLimit = 0)
        {
            JavaScriptSerializer loJavaScriptSerializer = new JavaScriptSerializer();
            loJavaScriptSerializer.RecursionLimit = fiRecursionLimit;
            return loJavaScriptSerializer.Serialize(foValue);
        }

        /// <summary>
        /// Convert to Json Serialized data from List<object>
        /// </summary> 
        /// <param name="fsValue">Source List<object></param>
        public static string toJSON(List<object> foValue)
        {
            JavaScriptSerializer loJavaScriptSerializer = new JavaScriptSerializer();
            return loJavaScriptSerializer.Serialize(foValue);
        }
        
        /// <summary>
        /// Created by Nikunj Balar on 23-07-2016 for stirng to date formate
        /// </summary>
        /// <param name="fsDateTime"></param>
        /// <returns></returns>
        public static string dateToSortDateString(this DateTime fdtDateTime)
        {
            return fdtDateTime.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Created by Nitin Lakum on 30-07-2016 for stirng date to date and time formate
        /// </summary>
        /// <param name="fsDateTime"></param>
        /// <returns></returns>
        public static string StringDateAndTineToStringDate(this string fsDateTime)
        {
            if (fsDateTime.Contains("-"))
                fsDateTime = fsDateTime.Replace("-", "/");

            if (!string.IsNullOrEmpty(fsDateTime))
            {
                try
                {
                    DateTime aa = DateTime.ParseExact(fsDateTime, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
                    string lstDate = Convert.ToDateTime(aa).ToString("dd/MM/yyyy");
                    return lstDate;
                }
                catch
                {
                    DateTime aa = DateTime.ParseExact(fsDateTime, "MM/dd/yyyy hh:mm tt", CultureInfo.InvariantCulture);
                    string lstDate = Convert.ToDateTime(aa).ToString("MM/dd/yyyy");
                    return lstDate;
                }
            }
            return fsDateTime;
        }

        /// <summary>
        /// Created by Nitin Lakum on 29-08-2016 for check internet connection
        /// </summary>
        /// <returns></returns>
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static string Transliterate(string latinCharacters)
        {
            StringBuilder gujarati = new StringBuilder(latinCharacters.Length);
            for (int i = 0; i < latinCharacters.Length; i++)
            {
                switch (char.ToLower(latinCharacters[i]))
                {
                    case 'a':
                        gujarati.Append('\u0abe');
                        break;
                    case 'h':
                        gujarati.Append('\u0ab9');
                        break;
                    case 'j':
                        gujarati.Append('\u0a9c');
                        break;
                    case 'l':
                        gujarati.Append('\u0ab2');
                        break;
                    case 'm':
                        gujarati.Append('\u0aae');
                        break;
                    case 't':
                        gujarati.Append('\u0aa4');
                        break;
                }
            }
            return gujarati.ToString();
        }
    }
}