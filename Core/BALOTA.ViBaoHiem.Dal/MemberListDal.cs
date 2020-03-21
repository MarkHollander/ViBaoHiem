using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BALOTA.ViBaoHiem.Entity;
using BALOTA.ViBaoHiem.MainDal.Databases;

namespace BALOTA.ViBaoHiem.Dal
{
    public class MemberListDal
    {
        public static List<MemberListEntity> MemberList_GetAllAgency(int isLocked)
        {
            List<MemberListEntity> returnValue = new List<MemberListEntity>();
            using (var db = new CmsMainDb())
            {
                returnValue = db.MemberListMainDal.MemberList_GetAllAgency(isLocked);
            }
            return returnValue;
        }

        public static List<MemberListEntity> MemberList_GetAllAgency(long parentMemberId, int isLocked)
        {
            List<MemberListEntity> returnValue = new List<MemberListEntity>();
            using (var db = new CmsMainDb())
            {
                returnValue = db.MemberListMainDal.MemberList_GetAllAgency(parentMemberId, isLocked);
            }
            return returnValue;
        }

        public static MemberListEntity MemberList_GetAgencyByMemberId(long memberId)
        {
            MemberListEntity returnValue = new MemberListEntity();
            using (var db = new CmsMainDb())
            {
                returnValue = db.MemberListMainDal.MemberList_GetAgencyByMemberId(memberId);
            }
            return returnValue;
        }

        public static List<MemberListEntity> MemberList_GetAllCollaborator(long parentMemberId, int isLocked)
        {
            List<MemberListEntity> returnValue = new List<MemberListEntity>();
            using (var db = new CmsMainDb())
            {
                returnValue = db.MemberListMainDal.MemberList_GetAllCollaborator(parentMemberId ,isLocked);
            }
            return returnValue;
        }
    }
}
