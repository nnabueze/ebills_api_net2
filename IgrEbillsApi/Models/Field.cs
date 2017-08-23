using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace IgrEbillsApi.Models
{
    [DataContract(Namespace = "")]
    public class Field
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public bool Required { get; set; }
        [DataMember]
        public bool Readonly { get; set; }
        [DataMember]
        public int MaxLength { get; set; }
        [DataMember]
        public int Order { get; set; }
        [DataMember]
        public bool RequiredInNextStep { get; set; }
        [DataMember]
        public bool AmountField { get; set; }
        [DataMember]
        public IList<Item> Item { get; set; }
    }
}