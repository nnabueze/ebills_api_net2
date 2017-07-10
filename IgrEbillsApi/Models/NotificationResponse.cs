using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IgrEbillsApi.Models
{
    public class NotificationResponse
    {

        public string SessionID { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}