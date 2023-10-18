using System.Runtime.Serialization;

namespace DocumentStore.Requests
{
    [DataContract]
    public class GetDocumentsByCollection : Request
    {
        [DataMember] public string Collection { get; set; } = "";
    }
}