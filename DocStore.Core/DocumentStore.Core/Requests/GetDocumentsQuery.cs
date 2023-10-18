using System.Runtime.Serialization;

namespace DocumentStore.Requests
{
    [DataContract]
    public class GetDocumentsQuery : Request
    {
        [DataMember] public int First { get; set; }
        [DataMember] public int Rows { get; set; } = 40;
        [DataMember] public int Page { get; set; } = 1;
        [DataMember] public string SortField { get; set; }
        [DataMember] public int? SortOrder { get; set; }
        [DataMember] public string Keyword { get; set; } = "";
        [DataMember] public string Tag { get; set; } = "";
    }
}