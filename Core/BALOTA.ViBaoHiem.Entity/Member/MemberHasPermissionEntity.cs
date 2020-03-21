using System.Runtime.Serialization;
using VB.Common.Entity;

namespace BALOTA.ViBaoHiem.Entity
{
    [DataContract]
    public class MemberHasPermissionEntity : EntityBase
    {
        [DataMember]
        public int MemberPermissionId { get; set; }
        [DataMember]
        public int MemberId { get; set; }
    }
}
