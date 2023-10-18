using System.Runtime.Serialization;
using DocumentStore.Requests;

namespace DocStore.Core.Requests
{
    [DataContract]
    public class GetPostQuery : Request
    {
        [DataMember] public string PermaLink { get; set; } = "";
    }
}