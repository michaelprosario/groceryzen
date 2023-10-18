using System;
using System.Runtime.Serialization;
using DocumentStore.Interfaces;

namespace DocStore.Core.Entities
{
    [DataContract]
    public class DropDownItem : IEntity
    {
        [DataMember] public string DropDown { get; set; }

        [DataMember] public string Key { get; set; }

        [DataMember] public string Value { get; set; }

        [DataMember] public DateTime CreatedAt { get; set; }
        [DataMember] public string CreatedBy { get; set; }

        [DataMember] public DateTime? DeletedAt { get; set; }
        [DataMember] public string DeletedBy { get; set; }
        [DataMember] public bool IsDeleted { get; set; }

        public string Id { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}