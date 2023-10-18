using System.Collections.Generic;
using System.Runtime.Serialization;
using DocumentStore.Entities;

namespace Scrum.Core.Entities
{

  [DataContract]
  public class UserStory : BaseEntity
  {
    public UserStory()
    {

    }

    [DataMember]
    public string State { get; set; }

    [DataMember]
    public string Name { get; set; }

    [DataMember]
    public string Description { get; set; }

    [DataMember]
    public string Notes { get; set; }

    [DataMember]
    public string DoneConditions { get; set; }

    [DataMember]
    public int Size { get; set; } = 1;

    [DataMember]
    public int Priority { get; set; } = 1;

    [DataMember]
    public string Moscow { get; set; }

    [DataMember]
    public string Owner { get; set; }

    [DataMember]
    public string ProjectId { get; set; }

    [DataMember]
    public string Tags { get; set; }

    [DataMember] public string IterationPath { get; set; }

    [DataMember] public List<ScrumTask> Tasks { get; set; } = new List<ScrumTask>();
  }

}