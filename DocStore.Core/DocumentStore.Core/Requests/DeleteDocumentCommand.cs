using System.Runtime.Serialization;

namespace DocumentStore.Requests
{
    [DataContract]
    public class DeleteDocumentCommand : Request
    {
        [DataMember] public string Id { get; set; } = "";
    }
}