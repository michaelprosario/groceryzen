using App.Core.Entities;
using App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace App.Core.Requests
{
    [DataContract]
    public class CreateShoppingListRequest 
    {
        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        public string UserId { get; set; }
    }

    [DataContract]
    public class CreateShoppingListResponse : Response
    {
        [DataMember]
        public string Id { get; set; }
    }

    [DataContract]
    public class GetShoppingListRequest 
    {
        [DataMember]
        [Required]
        public string Id { get; set; }

        [DataMember]
        public string UserId { get; set; }
    }

    [DataContract]
    public class GetShoppingListResponse : Response
    {
        [DataMember]
        public ShoppingList ShoppingList { get; set; }
    }

    [DataContract]
    public class DeleteShoppingListRequest 
    {
        [DataMember]
        [Required]
        public string Id { get; set; }

        [DataMember]
        public string UserId { get; set; }
    }

    [DataContract]
    public class ArchiveShoppingListRequest 
    {
        [Required]
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string UserId { get; set; }
    }

    [DataContract]
    public class ListShoppingListRequest 
    {
        [DataMember]
        public string UserId { get; set; }
    }

    [DataContract]
    public class ListShoppingListResponse : Response
    {
        [DataMember]
        public IList<ShoppingList> Records { get; set; }
    }
}
