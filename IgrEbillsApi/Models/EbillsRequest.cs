using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IgrEbillsApi.Models
{
    public class EbillsRequest
    {
        public class ValidationRequest
        {
            [JsonProperty("Step")]
            public int Step { get; set; }
            [JsonProperty("ProductName")]
            public string ProductName { get; set; }
            [JsonProperty("BillerID")]
            public string BillerID { get; set; }
            [JsonProperty("BillerName")]
            public string BillerName { get; set; }
            [JsonProperty("Param")]
            public IList<Param> Param { get; set; }
        }

        public class ValidationResponse
        {
            public int NextStep { get; set; }
            public string ProductName { get; set; }
            public string BillerID { get; set; }
            public string BillerName { get; set; }
            public string ResponseCode { get; set; }
            public string ResponseMessage { get; set; }
            public IList<Param> Param { get; set; }
            public Field field { get; set; }
        }

        public class Field
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public bool Required { get; set; }
            public bool Readonly { get; set; }
            public int MaxLength { get; set; }
            public int Order { get; set; }
            public bool RequiredInNextStep { get; set; }
            public bool AmountField { get; set; }
            public IList<Item> Item { get; set; }

        }

        public class Item
        {
            public string Name { get; set; }
            public string value { get; set; }
        }

        public class Param
        {
            public string key { get; set; }
            public string value { get; set; }
        }
    }
}