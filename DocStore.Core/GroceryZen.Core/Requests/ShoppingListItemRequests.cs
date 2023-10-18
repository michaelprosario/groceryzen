using App.Core;
using App.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using App.Core.Requests;
using App.Core.Entities;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace App.Core
{
    [DataContract]
    public class CreateShoppingListItemRequest 
    {
        [Required]
        [DataMember]
        public System.String ShoppingListId { get; set; }

        
        [Required]
        [DataMember]
        public System.String ProductName { get; set; }

        [Required]
        [DataMember]
        public System.String ProductCategory { get; set; }

        [Required]
        [DataMember]
        public System.Single UnitPrice { get; set; }

        [Required]
        [DataMember]
        public System.Single Qty { get; set; }

        [Required]
        [DataMember]
        public System.Single Price { get; set; }

        [DataMember]
        public System.Boolean Completed { get; set; }

        [DataMember]
        public System.String CreatedBy { get; set; }

        [DataMember]
        public System.String UpdatedBy { get; set; }

        [DataMember]
        public System.DateTime CreatedAt { get; set; }

        [DataMember]
        public System.DateTime UpdatedAt { get; set; }

        [DataMember]
        public string UserId { get; set; }
    }

    [DataContract]
    public class CreateShoppingListItemResponse : Response
    {
        [DataMember]
        public string Id { get; set; }
    }

    [DataContract]
    public class GetShoppingListItemRequest : IRequest<GetShoppingListItemResponse>, IUserRequest
    {
        [DataMember]
        [Required]
        public string Id { get; set; }

        [DataMember]
        public string UserId { get; set; }
    }

    [DataContract]
    public class GetShoppingListItemResponse : Response
    {
        [DataMember]
        public ShoppingListItem ShoppingListItem { get; set; }
    }

    [DataContract]
    public class ListShoppingListItemRequest : IRequest<ListShoppingListItemResponse>, IUserRequest
    {
        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public string ShoppingListId { get; set; }
    }

    [DataContract]
    public class ListShoppingListItemResponse : Response
    {
        [DataMember]
        public IList<ShoppingListItem> Records { get; set; }
    }

    [DataContract]
    public class DeleteShoppingListItemRequest : IRequest<VoidResponse>, IUserRequest
    {
        [Required]
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string UserId { get; set; }
    }
}