using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BALOTA.ViBaoHiem.Bo;
using BALOTA.ViBaoHiem.CMS.Common;
using BALOTA.ViBaoHiem.Entity;

namespace BALOTA.ViBaoHiem.Web.User.MemberManagement
{
    public partial class MemberManagement : System.Web.UI.MasterPage
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserEntity CurrentUserEntity = (UserEntity)HttpContext.Current.Session["CurrentUserEntity"];
                CurrentUserName.InnerText = CurrentUserEntity.Username;
            }
        }
    }
}