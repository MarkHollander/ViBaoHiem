using BALOTA.ViBaoHiem.Bo;
using BALOTA.ViBaoHiem.Entity;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using VB.Common.Log;

namespace BALOTA.ViBaoHiem.CMS.Common
{
    public class CurrentUser
    {
        public static string Username
        {
            get
            {
                try
                {
                    return HttpContext.Current.User.Identity.Name;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(Logger.LogType.Error, ex.ToString());
                    return string.Empty;
                }
            }
        }

        
        public static bool IsLogin
        {
            get
            {
                return HttpContext.Current.Request.IsAuthenticated &&
                   !string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name);
            }
        }
        public static void Logout()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            FormsAuthentication.SignOut();
        }
        public static bool IsSupperAdmin
        {
            get
            {
                var user = UserBo.GetUserByUsername(Username);
                if (user != null)
                {
                    return user.IsSupperAdmin;
                }
                return false;
            }
        }
        public static List<UserHasPermissionEntity> UserPermissions
        {
            get
            {
                return SecurityBo.GetUserHasPermissionByUsername(Username);
            }
        }
        public static bool HasPermission(EnumUserPermission permission)
        {
            return SecurityBo.HasPermission(Username, permission);
        }
        public static bool HasPermission(EnumUserPermission permission, int zoneId)
        {
            return SecurityBo.HasPermission(Username, permission, zoneId);
        }
        public static bool HasPermission(EnumUserPermission permission, string listZoneId)
        {
            return SecurityBo.HasPermission(Username, permission, listZoneId);
        }
    }
}