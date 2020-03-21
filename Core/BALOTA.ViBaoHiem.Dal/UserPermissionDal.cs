using BALOTA.ViBaoHiem.Entity;
using BALOTA.ViBaoHiem.MainDal.Databases;
using System.Collections.Generic;

namespace BALOTA.ViBaoHiem.Dal
{
    public class UserPermissionDal
    {
        public static List<UserPermissionEntity> GetAll()
        {
            List<UserPermissionEntity> returnValue = new List<UserPermissionEntity>();
            using (var db = new CmsMainDb())
            {
                returnValue = db.UserPermissionMainDal.GetAll();
            }
            return returnValue;
        }
    }
}
