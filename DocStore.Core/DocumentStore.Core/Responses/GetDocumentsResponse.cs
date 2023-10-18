using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DocumentStore.Responses
{
    [DataContract]
    public class GetDocumentsResponse<T> : AppResponse
    {
        [DataMember] public List<T> Documents { get; set; }

        [DataMember] public long TotalItemCount { get; set; }

        [DataMember] public long PageCount { get; set; }

        [DataMember] public bool IsFirstPage { get; set; }

        [DataMember] public bool IsLastPage { get; set; }

        [DataMember] public bool HasNextPage { get; set; }

        [DataMember] public bool HasPreviousPage { get; set; }

        [DataMember] public long FirstItemOnPage { get; set; }

        [DataMember] public long LastItemOnPage { get; set; }
    }
}