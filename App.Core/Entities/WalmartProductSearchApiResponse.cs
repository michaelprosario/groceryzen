using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace App.Core.Entities
{
    [DataContract]
    public class WalmartProductSearchApiResponse
    {
        [DataMember]
        public int TotalResults { get; set; }

        [DataMember]
        public int Start { get; set; }

        [DataMember]
        public int NumItems { get; set; }

        [DataMember(Name = "items")]
        public IList<WalmartProductSearchApiItem> Items; 
    }

    [DataContract]
    public class WalmartProductSearchApiItem
    {
        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name = "msrp")]
        public float Msrp { get; set; }

        [DataMember(Name = "salePrice")]
        public float SalePrice { get; set; }

        [DataMember(Name = "categoryPath")]
        public string CategoryPath { get; set; }

        [DataMember(Name = "shortDescription")]
        public string ShortDescription { get; set; }

        [DataMember(Name = "thumbnailImage")]
        public string ThumbnailImage { get; set; }

        [DataMember(Name = "productUrl")]
        public string ProductUrl { get; internal set; }
    }
}

