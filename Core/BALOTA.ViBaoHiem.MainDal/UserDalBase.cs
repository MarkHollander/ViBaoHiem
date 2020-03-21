using BALOTA.ViBaoHiem.Entity;
using BALOTA.ViBaoHiem.MainDal.Databases;
using System;
using System.Collections.Generic;
using System.Data;
using VB.Common.Converter;

namespace BALOTA.ViBaoHiem.MainDal
{
    public abstract class UserDalBase
    {
        #region Get methods
        public UserEntity GetByUsername(string username, bool getActivedUserOnly)
        {
            const string commandText = "VBH_User_GetByUsername";
            try
            {
                UserEntity data = null;
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "Username", username);
                _db.AddParameter(cmd, "GetActivedUserOnly", getActivedUserOnly);
                data = _db.Get<UserEntity>(cmd);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }

        }
        public UserEntity GetUserByUserId(long userId, bool getActivedUserOnly = true)
        {
            const string commandText = "VBH_User_GetByUserId";
            try
            {
                UserEntity data = null;
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "UserId", userId);
                _db.AddParameter(cmd, "GetActivedUserOnly", getActivedUserOnly);
                data = _db.Get<UserEntity>(cmd);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }

        }
        public UserEntity GetUserByEmail(string email, bool getActivedUserOnly = true)
        {
            const string commandText = "VBH_User_GetByEmail";
            try
            {
                UserEntity data = null;
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "Email", email);
                _db.AddParameter(cmd, "GetActivedUserOnly", getActivedUserOnly);
                data = _db.Get<UserEntity>(cmd);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }

        }
        public List<UserEntity> SearchUser(string keyword, int isLocked, int isSupperAdmin, int pageIndex, int pageSize, ref int totalRow)
        {
            const string commandText = "VBH_User_SearchUser";
            try
            {
                List<UserEntity> data = new List<UserEntity>();
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "TotalRow", totalRow, ParameterDirection.Output);
                _db.AddParameter(cmd, "Keyword", keyword);
                _db.AddParameter(cmd, "IsLocked", isLocked);
                _db.AddParameter(cmd, "IsSupperAdmin", isSupperAdmin);
                _db.AddParameter(cmd, "PageIndex", pageIndex);
                _db.AddParameter(cmd, "PageSize", pageSize);

                data = _db.GetList<UserEntity>(cmd);

                totalRow = Functions.GetInt(_db.GetParameterValueFromCommand(cmd, 0));

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }

        }
        public List<UserEntity> GetAllUser(string keyword, int isLocked)
        {
            const string commandText = "VBH_User_GetAllUser";
            try
            {
                List<UserEntity> data = new List<UserEntity>();
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "Keyword", keyword);
                _db.AddParameter(cmd, "IsLocked", isLocked);

                data = _db.GetList<UserEntity>(cmd);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }

        }
        #endregion

        #region Set methods
        public bool UpdateSecretKey(long userId, string secretKey)
        {
            const string commandText = "VBH_User_UpdateSecretKey";
            try
            {
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "UserId", userId);
                _db.AddParameter(cmd, "SecretKey", secretKey);

                var numberOfRow = cmd.ExecuteNonQuery();

                return numberOfRow > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }
        }
        public bool Create(UserEntity user, ref long userId)
        {
            const string commandText = "VBH_User_Create";
            try
            {
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "UserId", user.UserId, ParameterDirection.Output);
                _db.AddParameter(cmd, "Username", user.Username);
                _db.AddParameter(cmd, "Password", user.Password);
                _db.AddParameter(cmd, "FullName", user.FullName);
                _db.AddParameter(cmd, "Avatar", user.Avatar);
                _db.AddParameter(cmd, "Email", user.Email);
                _db.AddParameter(cmd, "Mobile", user.Mobile);
                _db.AddParameter(cmd, "IsLocked", user.IsLocked);
                _db.AddParameter(cmd, "IsSupperAdmin", user.IsSupperAdmin);
                _db.AddParameter(cmd, "CreatedBy", user.CreatedBy);
                _db.AddParameter(cmd, "Status", user.Status);

                var numberOfRow = cmd.ExecuteNonQuery();

                userId = Functions.GetInt(_db.GetParameterValueFromCommand(cmd, 0));

                return numberOfRow > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }
        }
        public bool Update(UserEntity user)
        {
            const string commandText = "VBH_User_Update";
            try
            {
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "Password", user.Password);
                _db.AddParameter(cmd, "FullName", user.FullName);
                _db.AddParameter(cmd, "Avatar", user.Avatar);
                _db.AddParameter(cmd, "Email", user.Email);
                _db.AddParameter(cmd, "Mobile", user.Mobile);
                _db.AddParameter(cmd, "IsLocked", user.IsLocked);
                _db.AddParameter(cmd, "IsSupperAdmin", user.IsSupperAdmin);
                _db.AddParameter(cmd, "Status", user.Status);
                _db.AddParameter(cmd, "UserId", user.UserId);

                var numberOfRow = cmd.ExecuteNonQuery();

                return numberOfRow > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }
        }
        public bool Delete(long userId)
        {
            const string commandText = "VBH_User_Delete";
            try
            {
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "UserId", userId);

                var numberOfRow = cmd.ExecuteNonQuery();

                return numberOfRow > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }
        }
        public bool LoggedIn(long userId, string lastIp)
        {
            const string commandText = "VBH_User_LoggedIn";
            try
            {
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "UserId", userId);
                _db.AddParameter(cmd, "LastIp", lastIp);

                var numberOfRow = cmd.ExecuteNonQuery();

                return numberOfRow > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }
        }
        #endregion

        #region Core members

        private readonly CmsMainDb _db;

        protected UserDalBase(CmsMainDb db)
        {
            _db = db;
        }

        protected CmsMainDb Database
        {
            get { return _db; }
        }

        #endregion
    }
}
