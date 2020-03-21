using BALOTA.ViBaoHiem.Dal;
using BALOTA.ViBaoHiem.Entity;
using BALOTA.ViBaoHiem.Entity.ErrorCode;
using System.Collections.Generic;
using VB.Common.Converter;
using System.Linq;

namespace BALOTA.ViBaoHiem.Bo
{
    public class UserBo
    {
        public static List<MemberListEntity> MemberList_GetAllAgency(int isLocked)
        {
            List<MemberListEntity> result = MemberListDal.MemberList_GetAllAgency(isLocked); 
            return result;
        }
        public static List<MemberListEntity> MemberList_GetAllAgency(long parentMemberId, int isLocked)
        {
            List<MemberListEntity> result = MemberListDal.MemberList_GetAllAgency(parentMemberId, isLocked);
            return result;
        }

        public static MemberListEntity MemberList_GetAgencyByMemberId(long memberId)
        {            
            return MemberListDal.MemberList_GetAgencyByMemberId(memberId);
        }

        public static MemberEntity Member_GetMemberByUsername(string username, bool getActivedUserOnly = true)
        {
            return MemberDal.GetByUsername(username, getActivedUserOnly);
        }

        public static MemberEntity Member_GetMemberByMemberId(long memberId)
        {
            return MemberDal.GetByMemberId(memberId);
        }

        public static MemberEntity Member_GetMemberByEmail(string email, bool getActivedUserOnly = true)
        {
            return MemberDal.GetByEmail(email, getActivedUserOnly);
        }

        public static bool LockMember(long memberId)
        {
            return MemberDal.LockMember(memberId);
        }
        public static UserEntity GetUserByUsername(string username, bool getActivedUserOnly = true)
        {
            return UserDal.GetByUsername(username, getActivedUserOnly); ;
        }
        public static UserEntity GetUserByUserId(long userId, bool getActivedUserOnly = true)
        {
            return UserDal.GetUserByUserId(userId, getActivedUserOnly); ;
        }
        public static UserEntity GetUserByEmail(string email, bool getActivedUserOnly = true)
        {
            return UserDal.GetUserByEmail(email, getActivedUserOnly); ;
        }
        public static List<UserEntity> SearchUser(string keyword, int isLocked, int isSupperAdmin, int pageIndex, int pageSize, ref int totalRow)
        {
            return UserDal.SearchUser(keyword, isLocked, isSupperAdmin, pageIndex, pageSize, ref totalRow); ;
        }
        public static List<UserEntity> GetAllUser(string keyword, int isLocked)
        {
            return UserDal.GetAllUser(keyword, isLocked); ;
        }

        public static ErrorMapping.ErrorCodes UpdateUserSecretKey(long userId, string secretKey)
        {
            if (userId <= 0) return ErrorMapping.ErrorCodes.UpdateUserInvalidUser;
            var existsUser = GetUserByUserId(userId);
            if (null == existsUser) return ErrorMapping.ErrorCodes.UpdateUserInvalidUser;

            if (string.IsNullOrEmpty(existsUser.SecretKey))
            {
                return UserDal.UpdateSecretKey(userId, secretKey) ? ErrorMapping.ErrorCodes.Success : ErrorMapping.ErrorCodes.BusinessError;
            }
            else
            {
                return ErrorMapping.ErrorCodes.Success;
            }
        }
        public static ErrorMapping.ErrorCodes CreateUser(UserEntity user, ref long userId)
        {
            if (null == user) return ErrorMapping.ErrorCodes.UpdateUserInvalidUser;
            if (string.IsNullOrEmpty(user.Username)) return ErrorMapping.ErrorCodes.UpdateUserInvalidUsername;
            if (string.IsNullOrEmpty(user.Password)) return ErrorMapping.ErrorCodes.UpdateUserInvalidPassword;
            if (!Functions.IsValidEmail(user.Email)) return ErrorMapping.ErrorCodes.UpdateUserInvalidEmail;

            var existsUser = GetUserByUsername(user.Username, false);
            if (null != existsUser) return ErrorMapping.ErrorCodes.UpdateUserDuplicateUsername;

            existsUser = GetUserByEmail(user.Email);
            if (null != existsUser) return ErrorMapping.ErrorCodes.UpdateUserDuplicateEmail;

            user.Password = Functions.CreateMd5Enrypt(user.Password);
            user.Status = 1;

            return UserDal.Create(user, ref userId) ? ErrorMapping.ErrorCodes.Success : ErrorMapping.ErrorCodes.BusinessError;
        }
        public static ErrorMapping.ErrorCodes UpdateUser(UserEntity user)
        {
            if (null == user) return ErrorMapping.ErrorCodes.UpdateUserInvalidUser;
            if (!Functions.IsValidEmail(user.Email)) return ErrorMapping.ErrorCodes.UpdateUserInvalidEmail;

            var existsUser = GetUserByUserId(user.UserId, false);
            if (null == existsUser) return ErrorMapping.ErrorCodes.UpdateUserInvalidUser;

            var existsUserHasEmail = GetUserByEmail(user.Email);
            if (null != existsUserHasEmail && existsUserHasEmail.UserId != user.UserId) return ErrorMapping.ErrorCodes.UpdateUserDuplicateEmail;

            if (!string.IsNullOrEmpty(user.Password)) user.Password = Functions.CreateMd5Enrypt(user.Password);

            existsUser.Password = user.Password;
            existsUser.FullName = user.FullName;
            existsUser.Avatar = user.Avatar;
            existsUser.Email = user.Email;
            existsUser.Mobile = user.Mobile;
            existsUser.IsLocked = user.IsLocked;

            return UserDal.Update(existsUser) ? ErrorMapping.ErrorCodes.Success : ErrorMapping.ErrorCodes.BusinessError;
        }
        public static ErrorMapping.ErrorCodes DeleteUser(long userId)
        {
            if (userId <= 0) return ErrorMapping.ErrorCodes.UpdateUserInvalidUser;
            var existsUser = GetUserByUserId(userId, false);
            if (null == existsUser) return ErrorMapping.ErrorCodes.UpdateUserInvalidUser;

            return UserDal.Delete(userId) ? ErrorMapping.ErrorCodes.Success : ErrorMapping.ErrorCodes.BusinessError;
        }

        public static ErrorMapping.ErrorCodes CreateAgency(MemberEntity member, ref long memberId)
        {
            if (null == member) return ErrorMapping.ErrorCodes.UpdateUserInvalidUser;
            if (string.IsNullOrEmpty(member.Username)) return ErrorMapping.ErrorCodes.UpdateUserInvalidUsername;
            if (string.IsNullOrEmpty(member.Password)) return ErrorMapping.ErrorCodes.UpdateUserInvalidPassword;
            if (!Functions.IsValidEmail(member.Email)) return ErrorMapping.ErrorCodes.UpdateUserInvalidEmail;

            var existsAgency = Member_GetMemberByUsername(member.Username, false);
            if (null != existsAgency) return ErrorMapping.ErrorCodes.UpdateUserDuplicateUsername;

            existsAgency = Member_GetMemberByEmail(member.Email);
            if (null != existsAgency) return ErrorMapping.ErrorCodes.UpdateUserDuplicateEmail;
            member.IsLocked = false;
            member.Status = 1;
            member.Password = Functions.CreateMd5Enrypt(member.Password);
            member.Status = 1;

            return MemberDal.CreateAgency(member, ref memberId) ? ErrorMapping.ErrorCodes.Success : ErrorMapping.ErrorCodes.BusinessError;
        }

        public static ErrorMapping.ErrorCodes UpdateAgency(MemberEntity member)
        {
            if (null == member) return ErrorMapping.ErrorCodes.UpdateUserInvalidUser; 
            var existsAgency = Member_GetMemberByEmail(member.Email);
            if (member.MemberId != existsAgency.MemberId) return ErrorMapping.ErrorCodes.UpdateUserDuplicateEmail;
            return MemberDal.UpdateAgency(member) ? ErrorMapping.ErrorCodes.Success : ErrorMapping.ErrorCodes.BusinessError;
        }
    }
}
