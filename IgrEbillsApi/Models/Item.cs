using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace IgrEbillsApi.Models
{
    [DataContract(Namespace = "")]
    public class Item
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string value { get; set; }
    }
}