using System.Runtime.Serialization;
using VB.Common.Entity;

namespace BALOTA.ViBaoHiem.Entity
{
    [DataContract]
    public enum EnumUserPermission : int
    {
        /// <summary>
        /// Quản lý hệ thống
        /// </summary>
        [EnumMember]
        SystemManager = 1,
        /// <summary>
        /// Quản lý đại lý và cộng tác viên
        /// </summary>
        [EnumMember]
        ManageMember = 2,
        /// <summary>
        /// Kế toán (xử lý nạp/rút tiền đại lý)
        /// </summary>
        [EnumMember]
        Accountant = 3
    }
    [DataContract]
    public class UserPermissionEntity : EntityBase
    {
        [DataMember]
        public int UserPermissionId { get; set; }
        [DataMember]
        public string PermissionName { get; set; }
        [DataMember]
        public int Status { get; set; }
    }
}
