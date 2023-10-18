using System;
using System.Runtime.Serialization;
using DocumentStore.Interfaces;

namespace DocStore.Core.Entities
{
    [DataContract]
    public class User : IEntity
    {
        [DataMember] public string FirstName { get; set; }
        [DataMember] public string LastName { get; set; }
        [DataMember] public string UserName { get; set; }
        [DataMember] public byte[] PasswordHash { get; set; }
        [DataMember] public byte[] PasswordSalt { get; set; }
        [DataMember] public string CreatedBy { get; set; }
        [DataMember] public DateTime? DeletedAt { get; set; }
        [DataMember] public string DeletedBy { get; set; }
        [DataMember] public string Id { get; set; }
        [DataMember] public bool IsDeleted { get; set; }
        [DataMember] public DateTime? UpdatedAt { get; set; }
        [DataMember] public string UpdatedBy { get; set; }
        [DataMember] public DateTime CreatedAt { get; set; }
    }
}