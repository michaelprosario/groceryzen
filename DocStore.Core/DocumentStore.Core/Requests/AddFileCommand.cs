using System.Runtime.Serialization;

namespace DocumentStore.Requests
{
    [DataContract]
    public class AddFileCommand
    {
        [DataMember] public string FileName { get; set; }
        [DataMember] public string FileId { get; set; }
    }
}