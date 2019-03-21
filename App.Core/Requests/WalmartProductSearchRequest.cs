using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System;
using MediatR;
using System.Collections.Generic;
using App.Core.Entities;

namespace App.Core.Requests
{
    [DataContract]
    public class WalmartProductSearchRequest : IRequest<WalmartProductSearchResponse>
    {
        [Required]
        [DataMember]
        public string Query { get; set; }        
    }

    [DataContract]
    public class WalmartProductSearchResponse : Response
    {
        [DataMember]
        public IList<WalmartProductSearchItem> Records { get; set; }
    }
}