
using System.Runtime.Serialization;
using DocumentStore.Entities;

namespace Scrum.Core.Entities
{
  [DataContract]
  public class ScrumTask : BaseEntity
  {
    [DataMember]
    public string State { get; set; }

    [DataMember]
    public string Name { get; set; }

    [DataMember]
    public string Description { get; set; }
    
    [DataMember]
    public string Notes { get; set; }

    [DataMember]
    public float EstimateHours { get; set; }
    [DataMember]
    public float HoursRemaining { get; set; }
    [DataMember]
    public string Owner { get; set; }
    [DataMember]
    public string Tags { get; set; }
  }

}