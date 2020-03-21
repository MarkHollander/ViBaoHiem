using BALOTA.ViBaoHiem.Dal;
using BALOTA.ViBaoHiem.Entity;
using BALOTA.ViBaoHiem.Entity.ErrorCode;
using System;
using System.Collections.Generic;
using VB.Common.Converter;
using VB.Common.WebHelper;

namespace BALOTA.ViBaoHiem.Bo
{
    public class SecurityBo
    {
        public static bool HasPermission(string username, EnumUserPermission permission)
        {
            var user = UserDal.GetByUsername(username, true);
            if (user != null)
            {
                if (user.IsSupperAdmin)
                {
                    return true;
                }
                else
                {
                    var userpermission = UserHasPermissionDal.GetByUsername(username);
                    return userpermission.Exists(item => item.UserPermissionId == (int)permission);
                }
            }
            return false;
        }
        public static bool HasPermission(string username, EnumUserPermission permission, int zoneId)
        {
            var user = UserDal.GetByUsername(username, true);
            if (user != null)
            {
                if (user.IsSupperAdmin)
                {
                    return true;
                }
                else
                {
                    var userpermission = UserHasPermissionDal.GetByUsername(username);
                    return userpermission.Exists(item => item.UserPermissionId == (int)permission);
                }
            }
            return false;
        }
        public static bool HasPermission(string username, EnumUserPermission permission, string listZoneId)
        {
            var user = UserDal.GetByUsername(username, true);
            if (user != null)
            {
                if (user.IsSupperAdmin)
                {
                    return true;
                }
                else
                {
                    var userpermission = UserHasPermissionDal.GetByUsername(username);

                    if (string.IsNullOrEmpty(listZoneId))
                    {
                        return false;
                    }
                    else
                    {
                        var zoneIds = listZoneId.Split(';');

                        var hasPermission = true;
                        foreach (var zoneId in zoneIds)
                        {
                            hasPermission = hasPermission &&
                                userpermission.Exists(item => item.UserPermissionId == (int)permission);
                        }
                        return hasPermission;
                    }
                }
            }
            return false;
        }
        public static List<UserHasPermissionEntity> GetUserHasPermissionByUsername(string username)
        {
            return UserHasPermissionDal.GetByUsername(username);
        }
        public static List<UserHasPermissionEntity> GetUserHasPermissionByUserId(long userId)
        {
            return UserHasPermissionDal.GetByUserId(userId);
        }
        public static List<UserPermissionEntity> GetAllUserPermission()
        {
            return UserPermissionDal.GetAll();
        }
        public static void UpdateUserHasPermission(long userId, bool isSupperAdmin, List<UserHasPermissionEntity> userPermissions)
        {
            var user = UserDal.GetUserByUserId(userId);
            if (user != null)
            {
                user.IsSupperAdmin = isSupperAdmin;
                UserDal.Update(user);

                try
                {
                    UserHasPermissionDal.DeleteByUserId(userId);
                    if (!isSupperAdmin)
                    {
                        foreach (var userPermission in userPermissions)
                        {
                            UserHasPermissionDal.Insert(userPermission);
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        public static void UpdateUserHasPermission(long userId, List<UserHasPermissionEntity> userHasPermissions)
        {
            var user = UserDal.GetUserByUserId(userId);
            if (user != null)
            {
                try
                {
                    UserHasPermissionDal.DeleteByUserId(userId);
                    foreach (var userPermission in userHasPermissions)
                    {
                        UserHasPermissionDal.Insert(userPermission);
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public static bool IsAdmin(string username)
        {
            var user = UserBo.GetUserByUsername(username, true);
            if (user != null)
            {
                return user.IsSupperAdmin;
            }
            return false;
        }

        public static ErrorMapping.ErrorCodes Login(string username, string password, ref UserEntity userInfo)
        {
            if (string.IsNullOrEmpty(username)) return ErrorMapping.ErrorCodes.LoginInvalidUsername;
            if (string.IsNullOrEmpty(password)) return ErrorMapping.ErrorCodes.LoginInvalidPassword;

            userInfo = UserBo.GetUserByUsername(username, true);
            if (null != userInfo)
            {
                var encryptPassword = Functions.CreateMd5Enrypt(password);
                if (encryptPassword.Equals(userInfo.Password))
                {
                    if (!userInfo.IsLocked)
                    {
                        if (userInfo.Status == 1)
                        {
                            UserDal.LoggedIn(userInfo.UserId, HttpHelper.GetCurrentIdAddress());
                            return ErrorMapping.ErrorCodes.Success;
                        }
                        return ErrorMapping.ErrorCodes.LoginAccountIsNotActived;
                    }
                    return ErrorMapping.ErrorCodes.LoginAccountHasBeenLocked;
                }
                return ErrorMapping.ErrorCodes.LoginInvalidPassword;
            }
            return ErrorMapping.ErrorCodes.LoginInvalidUsername;
        }
    }
}
