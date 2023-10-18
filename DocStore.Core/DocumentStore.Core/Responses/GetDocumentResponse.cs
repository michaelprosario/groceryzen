using System.Runtime.Serialization;

namespace DocumentStore.Responses
{
    [DataContract]
    public class GetDocumentResponse<T> : AppResponse
    {
        [DataMember] public T Document { get; set; }
    }
}