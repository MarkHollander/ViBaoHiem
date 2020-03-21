using BALOTA.ViBaoHiem.Entity;
using BALOTA.ViBaoHiem.MainDal.Databases;
using System;
using System.Collections.Generic;

namespace BALOTA.ViBaoHiem.MainDal
{
    public abstract class UserPermissionDalBase
    {
        #region Get methods
        public List<UserPermissionEntity> GetAll()
        {
            const string commandText = "VBH_UserPermission_GetAll";
            try
            {
                List<UserPermissionEntity> data = new List<UserPermissionEntity>();
                var cmd = _db.CreateCommand(commandText, true);

                data = _db.GetList<UserPermissionEntity>(cmd);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }

        }
        #endregion

        #region Set methods
        #endregion

        #region Core members

        private readonly CmsMainDb _db;

        protected UserPermissionDalBase(CmsMainDb db)
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
