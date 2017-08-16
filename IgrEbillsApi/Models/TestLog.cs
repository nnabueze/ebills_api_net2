using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IgrEbillsApi.Models
{
    public class TestLog
    {
        public int Id { get; set; }
        [JsonProperty("Content")]
        public string Content { get; set; }
    }
}