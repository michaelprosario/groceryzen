using System.Runtime.Serialization;

namespace DocumentStore.Requests
{
    [DataContract]
    public class GetMediaFilesQuery : Request
    {
        [DataMember] public string FileName { get; set; } = "";
        [DataMember] public string FileType { get; set; } = "";
        [DataMember] public int Page { get; set; }
        [DataMember] public int Rows { get; set; }
    }
}