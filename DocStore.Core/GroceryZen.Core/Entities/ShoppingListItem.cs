using System;
using System.Runtime.Serialization;
using App.Core.SharedKernel;
 namespace App.Core.Entities
{
    [DataContract]
    public class ShoppingListItem : BaseEntity
    {
        [DataMember]
        public string Id => base.Id;

        [DataMember]
        public string ShoppingListId { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public string ProductCategory { get; set; }

        [DataMember]
        public float UnitPrice { get; set; }

        [DataMember]
        public float Qty { get; set; }

        [DataMember]
        public float Price { get; set; }

        [DataMember]
        public bool Completed { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public string UpdatedBy { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public DateTime UpdatedAt { get; set; }
    }
} 
