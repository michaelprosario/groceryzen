using System.Runtime.Serialization;
using DocumentStore.Responses;

namespace DocStore.Core.Responses
{
    [DataContract]
    public class MarkDownServiceResponse : AppResponse
    {
        [DataMember] public string HtmlContent { get; set; }
    }
}