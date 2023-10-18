using System;
using System.Runtime.Serialization;
using App.Core.Interfaces;
using App.Core.SharedKernel;
 namespace App.Core.Entities
{
    [DataContract]
    public class ShoppingList : BaseEntity, ITimeStampedEntity
    {
        [DataMember]
        public string Id => base.Id;

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public string UpdatedBy { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public DateTime UpdatedAt { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
} 
