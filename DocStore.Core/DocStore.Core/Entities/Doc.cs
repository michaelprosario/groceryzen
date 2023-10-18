using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using DocumentStore.Interfaces;

namespace DocStore.Core.Entities
{
    [DataContract]
    public class Doc : IEntity
    {
        [DataMember] public string CollectionName { get; set; } = "";
        [DataMember] public string JsonData { get; set; }
        [DataMember] public string Name { get; set; } = "";

        [DataMember] public string Tags { get; set; } = "";
        [DataMember] public string ParentId { get; set; } = "";
        [DataMember] public List<string> Children { get; set; } = new();
        [DataMember] public DateTime CreatedAt { get; set; }
        [DataMember] public string CreatedBy { get; set; } = "";
        [DataMember] public DateTime? DeletedAt { get; set; }
        [DataMember] public string DeletedBy { get; set; } = "";

        [Key] [DataMember] public string Id { get; set; } = "";

        [DataMember] public bool IsDeleted { get; set; }
        [DataMember] public DateTime? UpdatedAt { get; set; }
        [DataMember] public string UpdatedBy { get; set; } = "";
    }
}