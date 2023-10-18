
using System.Collections.Generic;
using System.Runtime.Serialization;
using DocumentStore.Entities;
using System;
using Scrum.Core.ValueObjects;

namespace Scrum.Core.Entities
{

    public class Project : BaseEntity
    {

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        public List<Sprint> Sprints { get; set; } = new List<Sprint>();

        [DataMember]
        public List<DropDownItem> ProjectStatusList { get; set; } = new List<DropDownItem>();
        [DataMember]
        public List<DropDownItem> UserStoryStatusList { get; set; } = new List<DropDownItem>();
        [DataMember]
        public List<DropDownItem> TaskStatusList { get; set; } = new List<DropDownItem>();
    }

    [DataContract]
    public class Sprint : BaseEntity
    {
        [DataMember] public string IterationPath { get; set; }
        [DataMember] public int DayCount { get; set; }
        [DataMember] public string Goal { get; set; }
        [DataMember] public int EstEffort { get; set; }        
        [DataMember] public string Tags { get; set; }
    }    
}
