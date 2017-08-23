using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace IgrEbillsApi.Models
{
    [DataContract(Namespace = "")]
    public class ValidationResponse
    {
        [DataMember]
        public int NextStep { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string BillerID { get; set; }
        [DataMember]
        public string BillerName { get; set; }
        [DataMember]
        public string ResponseCode { get; set; }
        [DataMember]
        public string ResponseMessage { get; set; }
        [DataMember]
        public IList<Param> Param { get; set; }
        [DataMember]
        public Field field { get; set; }
    }
}