using BALOTA.ViBaoHiem.Entity;
using BALOTA.ViBaoHiem.MainDal.Databases;
using System.Collections.Generic;

namespace BALOTA.ViBaoHiem.Dal
{
    public class UserDal
    {
        public static UserEntity GetByUsername(string username, bool getActivedUserOnly = true)
        {
            UserEntity returnValue = null;
            using (var db = new CmsMainDb())
            {
                returnValue = db.UserMainDal.GetByUsername(username, getActivedUserOnly);
            }
            return returnValue;
        }
        public static UserEntity GetUserByUserId(long userId, bool getActivedUserOnly = true)
        {
            UserEntity returnValue = null;
            using (var db = new CmsMainDb())
            {
                returnValue = db.UserMainDal.GetUserByUserId(userId, getActivedUserOnly);
            }
            return returnValue;
        }
        public static UserEntity GetUserByEmail(string email, bool getActivedUserOnly = true)
        {
            UserEntity returnValue = null;
            using (var db = new CmsMainDb())
            {
                returnValue = db.UserMainDal.GetUserByEmail(email, getActivedUserOnly);
            }
            return returnValue;
        }
        public static List<UserEntity> SearchUser(string keyword, int isLocked, int isSupperAdmin, int pageIndex, int pageSize, ref int totalRow)
        {
            List<UserEntity> returnValue = new List<UserEntity>();
            using (var db = new CmsMainDb())
            {
                returnValue = db.UserMainDal.SearchUser(keyword, isLocked, isSupperAdmin, pageIndex, pageSize, ref totalRow);
            }
            return returnValue;
        }
        public static List<UserEntity> GetAllUser(string keyword, int isLocked)
        {
            List<UserEntity> returnValue = new List<UserEntity>();
            using (var db = new CmsMainDb())
            {
                returnValue = db.UserMainDal.GetAllUser(keyword, isLocked);
            }
            return returnValue;
        }
        public static bool UpdateSecretKey(long userId, string secretKey)
        {
            bool returnValue = false;
            using (var db = new CmsMainDb())
            {
                returnValue = db.UserMainDal.UpdateSecretKey(userId, secretKey);
            }
            return returnValue;
        }
        public static bool Create(UserEntity user, ref long userId)
        {
            bool returnValue = false;
            using (var db = new CmsMainDb())
            {
                returnValue = db.UserMainDal.Create(user, ref userId);
            }
            return returnValue;
        }
        public static bool Update(UserEntity user)
        {
            bool returnValue = false;
            using (var db = new CmsMainDb())
            {
                returnValue = db.UserMainDal.Update(user);
            }
            return returnValue;
        }
        public static bool Delete(long userId)
        {
            bool returnValue = false;
            using (var db = new CmsMainDb())
            {
                returnValue = db.UserMainDal.Delete(userId);
            }
            return returnValue;
        }
        public static bool LoggedIn(long userId, string lastIp)
        {
            bool returnValue = false;
            using (var db = new CmsMainDb())
            {
                returnValue = db.UserMainDal.LoggedIn(userId, lastIp);
            }
            return returnValue;
        }
    }
}
