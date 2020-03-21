using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BALOTA.ViBaoHiem.Entity;
using BALOTA.ViBaoHiem.MainDal.Databases;
using VB.Common.Converter;

namespace BALOTA.ViBaoHiem.MainDal
{
    public class MemberDalBase
    {
        #region Core members
        
        private readonly CmsMainDb _db;

        protected MemberDalBase(CmsMainDb db)
        {
            _db = db;
        }

        protected CmsMainDb Database
        {
            get { return _db; }
        }

        #endregion

        #region Get methods

        public MemberEntity GetByMemberId(long memberId, bool getActivedUserOnly = true)
        {
            const string commandText = "VBH_Member_GetByMemberId";
            try
            {
                MemberEntity data = null;
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "MemberId", memberId);
                _db.AddParameter(cmd, "GetActivedUserOnly", getActivedUserOnly);
                data = _db.Get<MemberEntity>(cmd);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }

        }

        public MemberEntity GetByUsername(string username, bool getActivedUserOnly = true)
        {
            const string commandText = "VBH_Member_GetByUsername";
            try
            {
                MemberEntity data = null;
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "Username", username);
                _db.AddParameter(cmd, "GetActivedUserOnly", getActivedUserOnly);
                data = _db.Get<MemberEntity>(cmd);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }
        }

        public MemberEntity GetByEmail(string email, bool getActivedUserOnly = true)
        {
            const string commandText = "VBH_Member_GetByEmail";
            try
            {
                MemberEntity data = null;
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "Email", email);
                _db.AddParameter(cmd, "GetActivedUserOnly", getActivedUserOnly);
                data = _db.Get<MemberEntity>(cmd);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }
        }

        public bool LockMember(long memberId)
        {
            const string commandText = "VBH_Member_LockMember";
            try
            {
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "MemberId", memberId);              

                var numberOfRow = cmd.ExecuteNonQuery();

                return numberOfRow > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }
        }

        public bool Create(MemberEntity member, ref long memberId)
        {
            const string commandText = "VBH_Member_Create";
            try
            {
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "MemberId", member.MemberId, ParameterDirection.Output);
                _db.AddParameter(cmd, "ParentMemberId", member.ParentMemberId);
                _db.AddParameter(cmd, "Username", member.Username);
                _db.AddParameter(cmd, "Password", member.Password);
                _db.AddParameter(cmd, "FullName", member.FullName);
                
                _db.AddParameter(cmd, "Email", member.Email);
                _db.AddParameter(cmd, "Mobile", member.Mobile);
                _db.AddParameter(cmd, "IsLocked", member.IsLocked);
                            
                _db.AddParameter(cmd, "Status", member.Status);

                var numberOfRow = cmd.ExecuteNonQuery();

                memberId = Functions.GetInt(_db.GetParameterValueFromCommand(cmd, 0));

                return numberOfRow > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }
        }

        public bool Update(MemberEntity member)
        {
            const string commandText = "VBH_Member_Update";
            try
            {
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "MemberId", member.MemberId);                
                _db.AddParameter(cmd, "FullName", member.FullName);                
                _db.AddParameter(cmd, "Email", member.Email);
                _db.AddParameter(cmd, "Mobile", member.Mobile); 
                var numberOfRow = cmd.ExecuteNonQuery();

                return numberOfRow > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }
        }

        public bool Delete(long memberId)
        {
            const string commandText = "VBH_Member_Delete";
            try
            {
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "MemberId", memberId);  
                var numberOfRow = cmd.ExecuteNonQuery(); 
                return numberOfRow > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }
        }

        public bool AddMemberHasPermission(long memberId, int memberPermissionId)
        {
            const string commandText = "VBH_Member_AddMemberHasPermission";
            try
            {
                var cmd = _db.CreateCommand(commandText, true);
                _db.AddParameter(cmd, "MemberId", memberId);
                _db.AddParameter(cmd, "MemberPermissionId", memberPermissionId);
                var numberOfRow = cmd.ExecuteNonQuery();
                return numberOfRow > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1}", commandText, ex.Message));
            }
        }

        #endregion
    }
}
