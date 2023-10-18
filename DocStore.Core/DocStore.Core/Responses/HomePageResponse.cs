using System.Collections.Generic;
using System.Runtime.Serialization;
using DocStore.Core.Entities;
using DocumentStore.Responses;

namespace DocStore.Core.Responses
{
    [DataContract]
    public class HomePageResponse : AppResponse
    {
        [DataMember] public List<Post> Posts { get; set; }

        [DataMember] public List<Page> Pages { get; set; }

        [DataMember] public List<DropDownItem> DropDownDataItems { get; set; }
    }
}