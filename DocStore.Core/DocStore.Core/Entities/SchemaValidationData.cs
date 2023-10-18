using System;
using System.Runtime.Serialization;
using DocumentStore.Entities;

namespace DocStore.Core.Entities
{
    [DataContract]
    public class SchemaValidationData : BaseEntity
    {
        [DataMember] public DateTime? CreatedAt { get; set; }
        [DataMember] public string CreatedBy { get; set; } = "";
        [DataMember] public DateTime? DeletedAt { get; set; }
        [DataMember] public string DeletedBy { get; set; } = "";


        [DataMember] public bool IsDeleted { get; set; }

        [DataMember] public string CollectionName { get; set; } = "";
        [DataMember] public string Schema { get; set; } = "";
    }
}