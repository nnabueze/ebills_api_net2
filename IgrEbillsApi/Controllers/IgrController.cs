using IgrEbillsApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
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
        public IHttpActionResult PostRequest(HttpRequestMessage value)
        {

            string obj = getJsonString(value);

            vResponse = JObject.Parse(obj)["ValidationRequest"].ToObject<ValidationRequest>();            

            utility = new Utility(vResponse);

            log(obj);

            switch (vResponse.ProductName)
            {
                case "Non-Tax":

                    return GetNonTax(vResponse);

                case "Tax":

                    return GetTax(vResponse);

                case "Remittance":

                    return GetRemittance(vResponse);

                case "refcode":

                    return RefCode();

                case "Invoice":

                    return GetInvoice(vResponse);

                default: 

                    return GetHttpMsg("ProductName parameter missing");
            }
        }


        //getting NonTax
        private IHttpActionResult GetNonTax(ValidationRequest vResponse)
        {
            ParamToArray(vResponse.Param);

            switch (vResponse.Step)
            {
                case 1:
                    if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(payerid))
                    {
                        return GetHttpMsg("Name or PayerId field can not be empty");
                    }

                    sResponse = utility.GetMdaResponse(2, ercasBillerId);
                    break; 
                case 2:
                    if (string.IsNullOrEmpty(mda) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(payerid) || string.IsNullOrEmpty(ercasBillerId))
                    {
                        return GetHttpMsg("Parameter Missing");
                    }

                    sResponse = utility.GetSubheadResponse(3, mda);
                    break;
                case 3:
                    if (string.IsNullOrEmpty(amount))
                    {
                        return GetHttpMsg("Amount field can not be empty");
                    }

                    sResponse = utility.GetResponse(4);
                    break;
                    
                default:
                    return GetHttpMsg("Next Page Not Included");
            }


            return GetHttpMsg();

        }


        private IHttpActionResult GetTax(ValidationRequest vResponse)
        {
            ParamToArray(vResponse.Param);

            //checking if step is 1
            if (vResponse.Step.Equals(1))
            {
                if (string.IsNullOrEmpty(tin))
                {
                    return GetHttpMsg("Tin field can not be empty");
                }

                var Tin_verify = utility.TinVerify(tin, ercasBillerId);
                if (Tin_verify != null)
                {
                    sResponse = utility.GetTinResponse(2,tin, ercasBillerId);
                }
                else
                {
                    return GetHttpMsg("Invalid Tin Number");
                }
            }

            //check if the step 2
            if (vResponse.Step.Equals(2))
            {
                if (string.IsNullOrEmpty(mda))
                {
                    return GetHttpMsg("Select an MDA");
                }

                sResponse = utility.GetSubheadResponse(3, mda);

            }

            //check if the step3
            if (vResponse.Step.Equals(3))
            {
                if (string.IsNullOrEmpty(amount))
                {
                    return GetHttpMsg("Amonut field can not be empty");
                }

                sResponse = utility.GetResponse(4);

            }

            return GetHttpMsg();
        }

        private IHttpActionResult GetRemittance(ValidationRequest vResponse)
        {
            ParamToArray(vResponse.Param);

            if (string.IsNullOrEmpty(remittance))
            {
                return GetHttpMsg("Remittance field can not be empty");
            }

            var VerifyRemittance = utility.GetRemittanceParam(remittance, ercasBillerId);

            if (VerifyRemittance == null)
            {
                return GetHttpMsg("Invalid Remittance Number");
            }
            sResponse = utility.GetRemittanceResponse(vResponse, 2, remittance, ercasBillerId);

            return GetHttpMsg();
        }


        private IHttpActionResult GetInvoice(ValidationRequest vResponse)
        {
            ParamToArray(vResponse.Param);

            if (string.IsNullOrEmpty(Invoice))
            {
                return GetHttpMsg("Invoice field can not be empty");
            }

            var VerifyInvoice = utility.GetInvoiceParam(Invoice, ercasBillerId);

            if (VerifyInvoice == null)
            {
                return GetHttpMsg("Invalid Invoice Number");
            }
            sResponse = utility.GetInvoiceResponse(2, Invoice, ercasBillerId);

            return GetHttpMsg();
        }


        //creating a refcode
        private IHttpActionResult RefCode()
        {
            tin tin = utility.tinCode();
            if (tin == null)
            {
                return GetHttpMsg("Unable to create tin.");
            }

            return GetHttpMsg();
        }

        public string getJsonString(HttpRequestMessage value)
        {
            var doc = new XmlDocument();
            doc.Load(value.Content.ReadAsStreamAsync().Result);
            var obj = JsonConvert.SerializeXmlNode(doc);

            return obj;
        }


        //get HTTPerrorMessage
        public IHttpActionResult GetHttpMsg(string msg=null)
        {
            if (string.IsNullOrEmpty(msg))
            {
                DataContractSerializer doc = new DataContractSerializer(sResponse.GetType());
                MemoryStream ms = new MemoryStream();
                doc.WriteObject(ms, sResponse);
                var i = Encoding.UTF8.GetString(ms.ToArray());
                var r = i.Replace("xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
                var a = r.Replace("i:nil=\"true\"", "");
                var ss = new XmlDocument();
                ss.LoadXml(a);
                return Content(HttpStatusCode.OK, ss.DocumentElement, Configuration.Formatters.XmlFormatter);
            }
            else
            {

                DataContractSerializer doc = new DataContractSerializer(GetErrorResponse(msg, "400").GetType());
                MemoryStream ms = new MemoryStream();
                doc.WriteObject(ms, GetErrorResponse(msg, "400"));
                var i = Encoding.UTF8.GetString(ms.ToArray());
                var r = i.Replace("xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
                var a = r.Replace("i:nil=\"true\"", "");
                var ss = new XmlDocument(); 
                ss.LoadXml(a); 
                return Content(HttpStatusCode.BadRequest, ss.DocumentElement, Configuration.Formatters.XmlFormatter);

            }
            
        }

        //getting error response
        public ValidationResponse GetErrorResponse(string msg, string code)
        {
            sResponse.ProductName = vResponse.ProductName;
            sResponse.NextStep = vResponse.Step;
            sResponse.ResponseCode = code;
            sResponse.ResponseMessage = msg;
            sResponse.field = null;
            sResponse.Param = null;

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

        private void log(string obj)
        {

            string sPathName = HttpContext.Current.Server.MapPath("/request.txt");

            try
            {
                using (StreamWriter w = new StreamWriter(sPathName, true))
                {
                    w.WriteLine(Environment.NewLine + "New Log Entry: ");
                    w.WriteLine(DateTime.Now.ToString());
                    w.WriteLine(obj);
                    w.WriteLine("__________________________");
                    w.WriteLine(" ");
                    w.Flush();
                }
            }
            catch (Exception)
            {
                //LogErr(ipath, ex.Message, CStr(myErr.Source))
            }
        }
    }
}
