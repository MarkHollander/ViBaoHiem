using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BALOTA.ViBaoHiem.Dal;
using BALOTA.ViBaoHiem.Entity;
using BALOTA.ViBaoHiem.Entity.ErrorCode;

namespace BALOTA.ViBaoHiem.Bo
{
    public class MemberBo
    {
        public static List<MemberListEntity> MemberList_GetAllCollaborator(long parentMemberId, int isLocked)
        {
            List<MemberListEntity> result = MemberListDal.MemberList_GetAllCollaborator(parentMemberId, isLocked);            
            return result;
        }
    }
}
