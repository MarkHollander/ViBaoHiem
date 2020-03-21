using System;
using System.Runtime.Serialization;
using VB.Common.Entity;

namespace BALOTA.ViBaoHiem.Entity
{
    [DataContract]
    public class UserEntity : EntityBase
    {
        [DataMember]
        public long UserId { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public string Avatar { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public DateTime LastLogin { get; set; }
        [DataMember]
        public string LastIp { get; set; }
        [DataMember]
        public bool IsLocked { get; set; }
        [DataMember]
        public bool IsSupperAdmin { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public string SecretKey { get; set; }
    }
}
