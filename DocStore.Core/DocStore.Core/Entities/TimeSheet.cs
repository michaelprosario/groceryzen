using System.Collections.Generic;
using System.Runtime.Serialization;
using DocumentStore.Entities;

namespace DocStore.Core.Entities
{
    [DataContract]
    public class TimeSheet : BaseEntity
    {
        [DataMember] public List<TimeEntry> Entries { get; set; }
        [DataMember] public string Notes { get; set; } = "";
        [DataMember] public string WeekEnding { get; set; } = "";
    }

    [DataContract]
    public class TimeEntry : BaseEntity
    {
        [DataMember] public string Date { get; set; } = "";
        [DataMember] public string EndTime { get; set; } = "";
        [DataMember] public float Hours { get; set; }
        [DataMember] public string Notes { get; set; } = "";
        [DataMember] public string ProjectId { get; set; } = "";
        [DataMember] public string StartTime { get; set; } = "";
        [DataMember] public string StoryId { get; set; } = "";
    }
}