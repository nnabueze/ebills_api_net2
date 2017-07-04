using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IgrEbillsApi.Models
{
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
}