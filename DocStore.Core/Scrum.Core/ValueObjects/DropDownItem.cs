using System.Runtime.Serialization;

namespace Scrum.Core.ValueObjects{

    [DataContract]
    public class DropDownItem
    {
        [DataMember]
        public string Key { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public int SortOrder { get; set; }
    }
}