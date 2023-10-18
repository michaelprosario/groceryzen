using System.Runtime.Serialization;

namespace DocumentStore.Responses
{
    [DataContract]
    public class DataResponse<T> : AppResponse
    {
        [DataMember] public T Data { get; set; }
    }
}