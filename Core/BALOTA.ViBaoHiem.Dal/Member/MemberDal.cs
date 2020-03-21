using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BALOTA.ViBaoHiem.Entity;
using BALOTA.ViBaoHiem.MainDal.Databases;

namespace BALOTA.ViBaoHiem.Dal
{
    public class MemberDal
    {
        public static MemberEntity GetByMemberId(long memberId, bool getActivedUserOnly = true)
        {
            MemberEntity returnValue = null;
            using (var db = new CmsMainDb())
            {
                returnValue = db.MemberMainDal.GetByMemberId(memberId, getActivedUserOnly);
            }
            return returnValue;
        }

        public static MemberEntity GetByUsername(string username, bool getActivedUserOnly = true)
        {
            MemberEntity returnValue = null;
            using (var db = new CmsMainDb())
            {
                returnValue = db.MemberMainDal.GetByUsername(username, getActivedUserOnly);
            }
            return returnValue;
        }

        public static MemberEntity GetByEmail(string email, bool getActivedUserOnly = true)
        {
            MemberEntity returnValue = null;
            using (var db = new CmsMainDb())
            {
                returnValue = db.MemberMainDal.GetByEmail(email, getActivedUserOnly);
            }
            return returnValue;
        }

        public static bool LockMember(long memberId)
        {
            bool returnValue = false;
            using (var db = new CmsMainDb())
            {
                returnValue = db.MemberMainDal.LockMember(memberId);
            }
            return returnValue;
        }

        public static bool CreateAgency(MemberEntity user, ref long memberId)
        {
            bool returnValue = false;
            bool addPermission = false;
            using (var db = new CmsMainDb())
            {
                //tao member moi
                returnValue = db.MemberMainDal.Create(user, ref memberId);
                //tao permission cho member moi
                if (returnValue && (memberId > 0)) addPermission = db.MemberMainDal.AddMemberHasPermission(memberId, 1);
                // neu ko tao dc permission thi delete member vua tao
                if(!addPermission) db.MemberMainDal.Delete(memberId);
            }
            return (returnValue && addPermission);
        }

        public static bool UpdateAgency(MemberEntity user)
        {
            bool returnValue = false;            
            using (var db = new CmsMainDb())
            {                
                returnValue = db.MemberMainDal.Update(user);                
            }
            return returnValue;
        }
    }
}
