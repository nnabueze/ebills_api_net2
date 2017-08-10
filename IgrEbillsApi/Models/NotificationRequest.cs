using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IgrEbillsApi.Models
{
    public class NotificationRequest
    {

        [JsonProperty("Step")]
        public int Step { get; set; }
        [JsonProperty("ProductName")]
        public string ProductName { get; set; }
        [JsonProperty("BillerID")]
        public string BillerID { get; set; }
        [JsonProperty("BillerName")]
        public string BillerName { get; set; }
        [JsonProperty("SessionID")]
        public string SessionID { get; set; }
        [JsonProperty("SourceBankCode")]
        public string SourceBankCode { get; set; }

        public string productType { get; set; }
        [JsonProperty("DestinationBankCode")]
        public string DestinationBankCode { get; set; }
        [JsonProperty("Param")]
        public IList<Param> Param { get; set; }
    }
}