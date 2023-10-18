using System.Runtime.Serialization;

namespace DocumentStore.Requests
{
    [DataContract]
    public class Request
    {
        [DataMember] public string UserId { get; set; }
    }
}