using System.Runtime.Serialization;
using VB.Common.Entity;

namespace BALOTA.ViBaoHiem.Entity
{
    [DataContract]
    public class UserHasPermissionEntity : EntityBase
    {
        [DataMember]
        public int UserPermissionId { get; set; }
        [DataMember]
        public int UserId { get; set; }
    }
}
