using System.Runtime.Serialization;
using DocumentStore.Interfaces;

namespace DocumentStore.Requests
{
    [DataContract]
    public class UpdateDocumentCommand<T> : Request where T : IEntity
    {
        [DataMember] public T Document { get; set; }
    }
}