using System.Runtime.Serialization;
using System;

namespace App.Core.Entities
{
    [DataContract]
    public class WalmartProductSearchItem
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public float SalePrice { get; set; }

        [DataMember]
        public string CategoryPath { get; set; }

        [DataMember]
        public string ShortDescription { get; set; }

        [DataMember]
        public string ProductUrl { get; set; }

        [DataMember]
        public string ThumbnailImage { get; set; }
    }
}
