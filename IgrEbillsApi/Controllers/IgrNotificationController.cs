using IgrEbillsApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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
            log(obj);
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

        private void log(string obj)
        {

            string sPathName = HttpContext.Current.Server.MapPath("/Content/Notification");
            string ipath = Path.Combine(sPathName, DateTime.Today.ToString("dd-MM-yy") + ".txt");

            try
            {
                using (StreamWriter w = new StreamWriter(ipath, true))
                {
                    w.WriteLine(Environment.NewLine + "New Log Entry: ");
                    w.WriteLine(DateTime.Now.ToString());
                    w.WriteLine(obj);
                    w.WriteLine("__________________________");
                    w.WriteLine(" ");
                    w.Flush();
                    w.Close();
                }
            }
            catch (Exception)
            {
                //LogErr(ipath, ex.Message, CStr(myErr.Source))
            }
        }
    }
}
