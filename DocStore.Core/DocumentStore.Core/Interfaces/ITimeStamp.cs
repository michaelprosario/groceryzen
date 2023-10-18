using System;

namespace DocumentStore.Interfaces
{
    public interface ITimeStampedEntity
    {
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}