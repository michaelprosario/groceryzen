using System.Runtime.Serialization;
using DocumentStore.Interfaces;

namespace DocumentStore.Requests
{
    [DataContract]
    public class StoreDocumentCommand<T> : Request where T : IEntity
    {
        [DataMember] public T Document { get; set; }
    }
}