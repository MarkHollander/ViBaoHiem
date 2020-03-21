using BALOTA.ViBaoHiem.Entity;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using VB.Common.Converter;

namespace BALOTA.ViBaoHiem.CMS.Common
{
    public class Utility
    {
        public static string GetUserIp()
        {
            var context = HttpContext.Current;

            var ipList = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            return !string.IsNullOrEmpty(ipList) ? ipList.Split(',')[0] : context.Request.ServerVariables["REMOTE_ADDR"];
        }
        public static string ShowDateTime(object value)
        {
            return Functions.FormatDateTime(value, "HH:mm, dd/MM/yyyy");
        }
        public static string ShowDateTimeForDateTimePicker(object value)
        {
            return Functions.FormatDateTime(value, "dd-MM-yyyy HH:mm");
        }
    }
}