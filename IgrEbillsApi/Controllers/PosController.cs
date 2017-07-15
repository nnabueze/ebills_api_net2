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
