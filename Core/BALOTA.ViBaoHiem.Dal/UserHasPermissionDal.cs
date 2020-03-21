using BALOTA.ViBaoHiem.Entity;
using BALOTA.ViBaoHiem.MainDal.Databases;
using System.Collections.Generic;

namespace BALOTA.ViBaoHiem.Dal
{
    public class UserHasPermissionDal
    {
        public static List<UserHasPermissionEntity> GetByUsername(string username)
        {
            List<UserHasPermissionEntity> returnValue = new List<UserHasPermissionEntity>();
            using (var db = new CmsMainDb())
            {
                returnValue = db.UserHasPermissionMainDal.GetByUsername(username);
            }
            return returnValue;
        }
        public static List<UserHasPermissionEntity> GetByUserId(long userId)
        {
            List<UserHasPermissionEntity> returnValue = new List<UserHasPermissionEntity>();
            using (var db = new CmsMainDb())
            {
                returnValue = db.UserHasPermissionMainDal.GetByUserId(userId);
            }
            return returnValue;
        }
        public static bool DeleteByUserId(long userId)
        {
            bool returnValue = false;
            using (var db = new CmsMainDb())
            {
                returnValue = db.UserHasPermissionMainDal.DeleteByUserId(userId);
            }
            return returnValue;
        }
        public static bool Insert(UserHasPermissionEntity userPermission)
        {
            bool returnValue = false;
            using (var db = new CmsMainDb())
            {
                returnValue = db.UserHasPermissionMainDal.Insert(userPermission);
            }
            return returnValue;
        }
    }
}
