using System;
using System.Runtime.Serialization;
using DocumentStore.Interfaces;

namespace DocumentStore.Entities
{
    [DataContract]
    public class MediaFile : IEntity
    {
        [DataMember] public long FileSize { get; set; }
        [DataMember] public long Width { get; set; }
        [DataMember] public long Height { get; set; }
        [DataMember] public string AltText { get; set; }
        [DataMember] public string Description { get; set; }
        [DataMember] public string FileName { get; set; }
        [DataMember] public string Tags { get; set; }
        [DataMember] public string FileType { get; set; }
        [DataMember] public string Title { get; set; }
        [DataMember] public bool IsDeleted { get; set; }
        [DataMember] public DateTime CreatedAt { get; set; }
        [DataMember] public DateTime? DeletedAt { get; set; }
        [DataMember] public DateTime? UpdatedAt { get; set; }
        [DataMember] public string CreatedBy { get; set; }
        [DataMember] public string DeletedBy { get; set; }
        [DataMember] public string Id { get; set; }
        [DataMember] public string UpdatedBy { get; set; }
    }
}