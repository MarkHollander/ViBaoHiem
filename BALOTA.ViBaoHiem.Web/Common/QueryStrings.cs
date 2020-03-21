using BALOTA.ViBaoHiem.Entity;
using System;
using System.Web;
using VB.Common.Converter;

namespace BALOTA.ViBaoHiem.CMS.Common
{
    public class QueryStrings
    {
        public const string PageIndexQueryName = "PageIndex";

        public static int PageIndex
        {
            get
            {
                return Functions.GetInt(HttpContext.Current.Request.QueryString[PageIndexQueryName]) <= 0
                           ? 1
                           : Functions.GetInt(HttpContext.Current.Request.QueryString[PageIndexQueryName]);
            }
        }
        public static string Keyword { get { return Functions.GetString(HttpContext.Current.Request.QueryString["Keyword"]); } }
        public static DateTime FromDate
        {
            get
            {
                return Functions.GetDateTime(HttpContext.Current.Request.QueryString["fromDate"], "yyyy-MM-dd");
            }
        }
        public static DateTime ToDate
        {
            get
            {
                var toDate = Functions.GetDateTime(HttpContext.Current.Request.QueryString["toDate"], "yyyy-MM-dd");
                if (toDate != DateTime.MinValue)
                    toDate = new DateTime(toDate.Year, toDate.Month, toDate.Day, 23, 59, 59);
                return toDate;
            }
        }

        public static string Username { get { return Functions.GetString(HttpContext.Current.Request.QueryString["Username"]); } }

        public static string GetPagingUrlFormat(int currentPageIndex)
        {

            var currentUrl = HttpContext.Current.Request.RawUrl;
            if (currentUrl.IndexOf(PageIndexQueryName, StringComparison.Ordinal) >= 0)
            {
                currentUrl =
                    currentUrl.Replace(
                        PageIndexQueryName + "=" + currentPageIndex,
                        PageIndexQueryName + "={0}");
            }
            else
            {
                if (currentUrl.IndexOf("?", StringComparison.Ordinal) < 0)
                {
                    currentUrl += "?";
                }
                else
                {
                    currentUrl += "&";
                }
                currentUrl += PageIndexQueryName + "={0}";
            }
            return currentUrl;
        }
    }
}