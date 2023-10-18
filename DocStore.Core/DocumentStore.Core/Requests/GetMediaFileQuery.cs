using System.Runtime.Serialization;

namespace DocumentStore.Requests
{
    [DataContract]
    public class GetMediaFileQuery : Request
    {
        [DataMember] public string FileName { get; set; } = "";
        [DataMember] public string Id { get; set; } = "";
    }
}