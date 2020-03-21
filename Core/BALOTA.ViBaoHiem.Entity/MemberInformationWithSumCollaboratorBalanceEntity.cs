using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VB.Common.Entity;


namespace BALOTA.ViBaoHiem.Entity
{
    class MemberInformationWithSumCollaboratorBalanceEntity : EntityBase
    {
        public long MemberId { get; set; }
        public long ParentMemberId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string FullName { get; set; }
        public string OpenId { get; set; }
        public int SourceOpenId { get; set; }
        public string ActiveCode { get; set; }
        public string SecretKey { get; set; }
        public bool IsLocked { get; set; }
        public string VoucherCode { get; set; }
        public string InviteCode { get; set; }
        public decimal MemberBalance { get; set; }
        public float PrimaryCommissionRate { get; set; }
        public float SubCommissionRate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string LastLoginIp { get; set; }
        public string LastVisitDate { get; set; }
        public string LastVisitIp { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public decimal SumMemberBalance { get; set; } // so du Cong Tac Vien
        public int OwnerPackageCount { get; set; }  //số gói đang quản
    }
}
