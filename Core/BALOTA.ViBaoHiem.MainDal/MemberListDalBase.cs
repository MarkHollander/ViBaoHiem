using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BALOTA.ViBaoHiem.MainDal.Databases;
using BALOTA.ViBaoHiem.Entity;

namespace BALOTA.ViBaoHiem.MainDal
{
    public abstract class MemberListDalBase
    {
        #region Core members

        private readonly CmsMainDb _db;

        protected MemberListDalBase(CmsMainDb db)
        {
            _db = db;
        }

        protected CmsMainDb Database
        {
            get { return _db; }
        }

        #endregion

        #region Get methods

        //lay toan bo danh sach Member + so goi dang quan ly
        public List<MemberListEntity> MemberList_GetAllAgency(int isLocked)
        {
            const string commandText = "VBH_MemberList_GetAllAgency";
            try
            {                
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "IsLocked", isLocked);
                List<MemberListEntity> data = _db.GetList<MemberListEntity>(cmd);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }
        }

        public List<MemberListEntity> MemberList_GetAllAgency(long parentMemberId, int isLocked)
        {
            const string commandText = "VBH_MemberList_GetAllAgencyByParentMemberId";
            try
            {
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "ParentMemberId", parentMemberId);
                _db.AddParameter(cmd, "IsLocked", isLocked);
                List<MemberListEntity> data = _db.GetList<MemberListEntity>(cmd);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }
        }

        public MemberListEntity MemberList_GetAgencyByMemberId(long memberId)
        {
            const string commandText = "VBH_MemberList_GetAgencyByMemberId";
            try
            {
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "MemberId", memberId);
                
                MemberListEntity data = _db.Get<MemberListEntity>(cmd);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }
        }

        public List<MemberListEntity> MemberList_GetAllCollaborator(long parentMemberId, int isLocked)
        {
            const string commandText = "VBH_MemberList_GetAllCollaboratorByParentMemberId";
            try
            {
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "ParentMemberId", parentMemberId);
                _db.AddParameter(cmd, "IsLocked", isLocked);
                List<MemberListEntity> data = _db.GetList<MemberListEntity>(cmd);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }
        }

        #endregion
    }
}
