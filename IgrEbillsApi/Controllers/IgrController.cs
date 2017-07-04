using IgrEbillsApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;

namespace IgrEbillsApi.Controllers
{
    public class IgrController : ApiController
    {

        private ValidationRequest vResponse = new ValidationRequest();
        private ValidationResponse sResponse = new ValidationResponse();

        private string name;
        private string payerid;
        private string ercasBillerId;
        private string mda;
        private string amount;
        private string tin;
        private string remittance;
        private string Invoice;

        Utility utility;


        //Posting request from Nibss
        [HttpPost]
        public HttpResponseMessage PostRequest(HttpRequestMessage value)
        {
            var doc = new XmlDocument();
            doc.Load(value.Content.ReadAsStreamAsync().Result);

            var obj = JsonConvert.SerializeXmlNode(doc);
            vResponse = JObject.Parse(obj)["ValidationRequest"].ToObject<ValidationRequest>();

            utility = new Utility(vResponse);

            //checking if the productname is empty
            if (string.IsNullOrEmpty(vResponse.ProductName))
            {
                return GetHttpMsg("ProductName parameter missing");
            }

            //checking if the product is non-tax
            if (vResponse.ProductName.Equals("Non-Tax"))
                return GetNonTax(vResponse);

            //check if product is tax
            //if (vResponse.ProductName.Equals("Tax"))
            //    return GetTax(vResponse);

            //check if product is remittance
            //if (vResponse.ProductName.Equals("Remittance"))
            //    return GetRemittance(vResponse);

            //check if product is invoice
            //if (vResponse.ProductName.Equals("Invoice"))
            //    return GetInvoice(vResponse);

            //check if product is refcode
            //if ()
            //sResponse = GetNonTax();

            return GetHttpMsg("ProductName paramter missing");
        }


        //getting NonTax
        private HttpResponseMessage GetNonTax(ValidationRequest vResponse)
        {
            ParamToArray(vResponse.Param);

            //checking if step is 1
            if (vResponse.Step.Equals(1))
            {
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(payerid))
                {
                    return GetHttpMsg("Name or PayerId field can not be empty");
                }

                sResponse = utility.GetMdaResponse(2, ercasBillerId);
            }

            //checking if step is 2
            if (vResponse.Step.Equals(2))
            {
                if (string.IsNullOrEmpty(mda) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(payerid) || string.IsNullOrEmpty(ercasBillerId))
                {
                    return GetHttpMsg("Parameter Missing");
                }

                sResponse = utility.GetSubheadResponse(3, mda);

            }

            //checking if step is 3
            //if (vResponse.Step.Equals(3))
            //{
            //    if (string.IsNullOrEmpty(amount))
            //    {
            //        return GetHttpMsg(vResponse, "Amount field can not be empty");
            //    }

            //    sResponse = utility.GetResponse(vResponse, 4);
            //}

            return GetHttpMsg();

        }



        //get HTTPerrorMessage
        public HttpResponseMessage GetHttpMsg(string msg=null)
        {
            if (string.IsNullOrEmpty(msg))
            {
                return Request.CreateResponse<ValidationResponse>(HttpStatusCode.OK, sResponse);
            }
            else
            {
                return Request.CreateResponse<ValidationResponse>(HttpStatusCode.BadRequest, GetErrorResponse(msg, "400"));
                
            }
            
        }

        //getting error response
        public ValidationResponse GetErrorResponse(string msg, string code)
        {
            sResponse.ProductName = vResponse.ProductName;
            sResponse.NextStep = vResponse.Step;
            sResponse.ResponseCode = code;
            sResponse.ResponseMessage = msg;

            return sResponse;
        }

                //converting param to array
        private void ParamToArray(IList<Param> sList)
        {
            for (int i = 0; i < sList.Count; i++)
            {
                if (sList[i].key.Equals("name"))
                {
                    name = sList[i].value;
                }

                if (sList[i].key.Equals("payerid"))
                {
                    payerid = sList[i].value;
                }

                if (sList[i].key.Equals("ercasBillerId")) 
                {
                    ercasBillerId = sList[i].value;
                }

                if (sList[i].key.Equals("mda")) 
                {
                    mda = sList[i].value;
                }

                if (sList[i].key.Equals("amount")) 
                {
                    amount = sList[i].value;
                }

                if (sList[i].key.Equals("Tin")) 
                {
                    tin = sList[i].value;
                }

                if (sList[i].key.Equals("Remittance")) 
                {
                    remittance = sList[i].value;
                }

                if (sList[i].key.Equals("Invoice"))
                {
                    Invoice = sList[i].value;
                }
            }
        }
    }
}
