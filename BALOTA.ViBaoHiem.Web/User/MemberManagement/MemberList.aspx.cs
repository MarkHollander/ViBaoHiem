using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BALOTA.ViBaoHiem.Bo;
using BALOTA.ViBaoHiem.Entity;
using Newtonsoft.Json;

namespace BALOTA.ViBaoHiem.Web.User.MemberManagement
{
    public partial class MemberList : System.Web.UI.Page
    {
        private UserEntity currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //public string MemberListLoadData()
        //{
        //    currentUser = (UserEntity)HttpContext.Current.Session["CurrentUserEntity"];
        //    List<MemberListEntity> listOfMember = UserBo.MemberList_GetAll(0);
        //    return JsonConvert.SerializeObject(listOfMember);
        //}
    }
}