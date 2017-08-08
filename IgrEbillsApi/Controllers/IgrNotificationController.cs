using IgrEbillsApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;

namespace IgrEbillsApi.Controllers
{
    public class IgrNotificationController : ApiController
    {
        private NotificationRequest vResponse = new NotificationRequest();
        private NotificationResponse nResponse = new NotificationResponse();
        private notification notify = new notification();

        Utility utility = new Utility();



        //Posting request from Nibss
        [HttpPost]
        public HttpResponseMessage PostRequest(HttpRequestMessage value)
        {
            var doc = new XmlDocument();
            doc.Load(value.Content.ReadAsStreamAsync().Result);

            var obj = JsonConvert.SerializeXmlNode(doc);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\EZE\Documents\Visual Studio 2015\Projects\igr2\IgrEbillsApi\LogNotification.txt", true))
            {

                DateTime today = DateTime.UtcNow.Date;
                file.WriteLine(today);
                for (int i = 0; i < 50; i++)
                {
                    file.Write("=");
                }
                file.WriteLine(" ");
                file.Write(obj);
                file.WriteLine(" ");

            }
            vResponse = JObject.Parse(obj)["NotificationRequest"].ToObject<NotificationRequest>();

            notify.sessionID = vResponse.SessionID;
            notify.productType = vResponse.ProductName;
            notify.SourceBankCode = vResponse.SourceBankCode;
            notify.DestinationBankCode = vResponse.DestinationBankCode;

            var notifyResponse = utility.InsertNotification(notify);

            if (notifyResponse == null)
            {
                return GetHttpMsg("Unable to insert record");
            }

            return GetHttpMsg();
        }


        //get HTTPerrorMessage
        public HttpResponseMessage GetHttpMsg(string msg = null)
        {
            if (string.IsNullOrEmpty(msg))
            {
                return Request.CreateResponse<NotificationResponse>(HttpStatusCode.OK, GetResponse());
            }
            else
            {
                return Request.CreateResponse<NotificationResponse>(HttpStatusCode.BadRequest, GetErrorResponse(msg, "400"));

            }

        }

        //getting error response
        public NotificationResponse GetErrorResponse(string msg, string code)
        {
            nResponse.SessionID = vResponse.SessionID;
            nResponse.ResponseCode = code;
            nResponse.ResponseMessage = msg;

            return nResponse;
        }

        //getting error response
        public NotificationResponse GetResponse()
        {
            nResponse.SessionID = vResponse.SessionID;
            nResponse.ResponseCode = "00";
            nResponse.ResponseMessage = "Payment Notification Successful";

            return nResponse;
        }

        //converting param to array
        private void ParamToArray(IList<Param> sList)
        {
            for (int i = 0; i < sList.Count; i++)
            {
                if (sList[i].key.Equals("ercasBillerId"))
                {
                    notify.IGR_Code = sList[i].value;
                }

                if (sList[i].key.Equals("mda_key"))
                {
                    notify.MDA_ID = sList[i].value;
                }

                if (sList[i].key.Equals("subhead_key"))
                {
                    notify.SubHead_ID = sList[i].value;
                }

                if (sList[i].key.Equals("Refcode"))
                {
                    notify.refcode = sList[i].value;
                }

                if (sList[i].key.Equals("Tin"))
                {
                    notify.tin = sList[i].value;
                }

                if (sList[i].key.Equals("name"))
                {
                    notify.name = sList[i].value;
                }

                if (sList[i].key.Equals("phone"))
                {
                    notify.phone = sList[i].value;
                }

                if (sList[i].key.Equals("Invoice"))
                {
                    notify.invoice_id = sList[i].value;
                }

                if (sList[i].key.Equals("Remittance"))
                {
                    notify.remittance_id = sList[i].value;
                }

                if (sList[i].key.Equals("amount"))
                {
                    notify.amount = Decimal.Parse(sList[i].value);
                }
            }
        }
    }
}
