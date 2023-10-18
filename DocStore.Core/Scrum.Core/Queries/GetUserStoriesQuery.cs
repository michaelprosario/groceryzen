using System.Runtime.Serialization;
using DocumentStore.Requests;

namespace Scrum.Core.Entities
{
    [DataContract]
    public class GetUserStoriesQuery : GetDocumentsQuery
    {
        [DataMember] public string ProjectId { get; set; } = "";
        [DataMember] public string IterationPath { get; set; } = "";
    }
}