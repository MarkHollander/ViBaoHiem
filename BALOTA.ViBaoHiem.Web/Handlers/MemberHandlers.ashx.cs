using BALOTA.ViBaoHiem.Bo;
using BALOTA.ViBaoHiem.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BALOTA.ViBaoHiem.Web.Handlers
{
    /// <summary>
    /// Summary description for MemberHandlers
    /// </summary>
    public class MemberHandlers : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var functionName = context.Request.QueryString["fn"];

            var response = new AjaxResponseData();
            if (functionName == "get-list-member")
            {
                response = GetListMember(context);
            }

            context.Response.Write(VB.Common.Converter.NewtonJson.Serialize(response));
            context.Response.Flush();
            context.Response.End();
        }

        public static AjaxResponseData GetListMember(HttpContext context)
        {
            var response = new AjaxResponseData();

            var keyword = context.Request.Form["keyword"];
            var listMember = UserBo.GetAllUser(keyword, -1);
            response.Data = listMember;

            return response;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}