using IgrEbillsApi.DTOs;
using IgrEbillsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IgrEbillsApi.Controllers
{
    public class PosController : ApiController
    {
        private PosUtility utility = new PosUtility();


        //Activating pos
        
        [Authorize]
        [HttpPost]
        public IHttpActionResult Activation(PosDTO pos)
        {

            if (!ModelState.IsValid)
            {
                return GetErrorMsg(1, "Activation Code Missing"); 
            }

            PosDTO posDetails = utility.GetPos(pos);

            if (posDetails == null)
            {
                return GetErrorMsg(2, "Invalid Activation Code");
            }

            return Ok(posDetails);
        }

        //pos user login
        [Authorize]
        [HttpPost]
        public IHttpActionResult UserLogin(UserDTO UserRequest)
        {
            if (!ModelState.IsValid)
            {
                return GetErrorMsg(1, "Parameter Missing");
            }

            UserDTO UserResponse = utility.GetPosUser(UserRequest);

            if (UserResponse == null)
            {
                return GetErrorMsg(2, "User Not Found");
            }

            if (UserResponse.MDAStation_ID == null)
            {
                return GetErrorMsg(2, "User Not Assigned to Station");
            }

            return Ok(UserResponse);
        }

        //Verifying Tin
        [Authorize]
        [HttpPost]
        public IHttpActionResult TinVerification(TinDTO TinRequest)
        {
            if (!ModelState.IsValid)
            {
                return GetErrorMsg(1,"Parameter Missing");
            }

            TinDTO TinResponse = utility.GetTin(TinRequest);
            if (TinResponse == null)
            {
                return GetErrorMsg(2, "Invalid Tin Number");
            }

            return Ok(TinResponse);
        }

        //pos collection
        [Authorize]
        [HttpPost]
        public IHttpActionResult PosCollection(CollectionDTO CollectionRequest)
        {
            if (!ModelState.IsValid)
            {
                return GetErrorMsg(1, "Parameter Missing");
            }

            CollectionDTO CollectionResponse = utility.InsertPosCollection(CollectionRequest);
            if (CollectionResponse == null)
            {
                return GetErrorMsg(2, "Unable to insert record");
            }

            if (CollectionResponse.Message == 1)
            {
                return GetErrorMsg(2, "Collection Limit Exceeded");
            }

            if (CollectionResponse.Message == 2)
            {
                return GetErrorMsg(2, "Pinding Remittance");
            }

            return Ok(CollectionResponse);

        }

        //generating remittance
        [Authorize]
        [HttpPost]
        public IHttpActionResult GenerateRemittance(RemittanceDTO RemiteRequest)
        {
            if (!ModelState.IsValid)
            {
                return GetErrorMsg(1, "Parameter Missing");
            }

            RemittanceDTO RemitResponse = utility.GetRemittance(RemiteRequest);
            if (RemitResponse == null)
            {
                return GetErrorMsg(2, "Parameter Missing");
            }

            if (RemitResponse.Message == 1)
            {
                return GetErrorMsg(2, "Pending Remittance");
            }

            if (RemitResponse.Message == 2)
            {
                return GetErrorMsg(2, "No Pending Collection");
            }

            utility.UpdateCollection(RemitResponse);

            return Ok(RemitResponse);
        }

        //generate invoice
        [Authorize]
        [HttpPost]
        public IHttpActionResult GenerateInvoice(InvoceDTO InvoiceRequest)
        {
            if (!ModelState.IsValid)
            {
                return GetErrorMsg(1, "Parameter Missing");
            }

            InvoceDTO InvoiceResponse = utility.GetInvoice(InvoiceRequest);

            if (InvoiceResponse.Message == 1)
            {
                return GetErrorMsg(1, "Pending Remittance");
            }

            return Ok(InvoiceResponse);
        }

        //Getting error messgae
        public IHttpActionResult GetErrorMsg(int num, string msg)
        {
            Dictionary<string, string> error = new Dictionary<string,string>();
            error.Add("Message",msg);

            switch (num)
            {
                case 1:
                    return BadRequest(msg);
                case 2:
                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, error));
                default:
                    return NotFound();
            }
        }
    }
}
