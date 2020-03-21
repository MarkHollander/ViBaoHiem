using BALOTA.ViBaoHiem.Entity;
using BALOTA.ViBaoHiem.MainDal.Databases;
using System;
using System.Collections.Generic;

namespace BALOTA.ViBaoHiem.MainDal
{
    public abstract class UserHasPermissionDalBase
    {
        #region Get methods
        public List<UserHasPermissionEntity> GetByUsername(string username)
        {
            const string commandText = "VBH_UserHasPermission_GetByUsername";
            try
            {
                List<UserHasPermissionEntity> data = new List<UserHasPermissionEntity>();
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "Username", username);
                data = _db.GetList<UserHasPermissionEntity>(cmd);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }

        }
        public List<UserHasPermissionEntity> GetByUserId(long userId)
        {
            const string commandText = "VBH_UserHasPermission_GetByUserId";
            try
            {
                List<UserHasPermissionEntity> data = new List<UserHasPermissionEntity>();
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "UserId", userId);
                data = _db.GetList<UserHasPermissionEntity>(cmd);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }

        }
        #endregion

        #region Set methods
        public bool DeleteByUserId(long userId)
        {
            const string commandText = "VBH_UserHasPermission_DeleteByUserId";
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
        public bool Insert(UserHasPermissionEntity userPermission)
        {
            const string commandText = "VBH_UserHasPermission_Insert";
            try
            {
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "UserId", userPermission.UserId);
                _db.AddParameter(cmd, "PermissionId", userPermission.UserPermissionId);

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

        protected UserHasPermissionDalBase(CmsMainDb db)
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
