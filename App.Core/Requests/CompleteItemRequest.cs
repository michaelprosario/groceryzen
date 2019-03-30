using MediatR;
using App.Core;
using App.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using App.Core.Requests;
using App.Core.Entities;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace App.Core.Requests
{
    [DataContract]
    public class CompleteShoppingListItemRequest : IRequest<VoidResponse>, IUserRequest
    {
        [Required]
        [DataMember]
        public System.String ShoppingListItemId { get; set; }

        [DataMember]
        public System.String UserId { get; set; }
    }

    [DataContract]
    public class CompleteShoppingListItemResponse : Response
    {
        [DataMember]
        public string Id { get; set; }
    }
}