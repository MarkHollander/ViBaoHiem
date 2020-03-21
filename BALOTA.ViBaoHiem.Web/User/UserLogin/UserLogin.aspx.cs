using BALOTA.ViBaoHiem.Bo;
using BALOTA.ViBaoHiem.CMS.Common;
using BALOTA.ViBaoHiem.Entity;
using BALOTA.ViBaoHiem.Entity.ErrorCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using VB.Common.WebBase;

namespace BALOTA.ViBaoHiem.Web
{
    public partial class UserLogin : CmsPageBase
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CurrentUser.IsLogin) Response.Redirect("/");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;
            UserEntity userInfo = null;

            var errorCode = SecurityBo.Login(username, password, ref userInfo);
            if (errorCode == Entity.ErrorCode.ErrorMapping.ErrorCodes.Success && userInfo != null)
            {
                FormsAuthentication.Initialize();
                FormsAuthentication.SetAuthCookie(userInfo.Username, false, "/User/User_HomePage.aspx");
                HttpContext.Current.Session["CurrentUserEntity"] = userInfo;
                Response.Redirect("/User/User_HomePage.aspx");
            }
            else
            {
                ltrMessage.Text = CmsMessage.ShowMessage(CmsMessage.MessageType.Danger, ErrorMapping.Current[errorCode]);
            }
        }
    }
}