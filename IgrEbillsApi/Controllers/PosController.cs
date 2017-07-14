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
                return BadRequest("Activation Code Missing");
            }

            PosDTO posDetails = utility.GetPos(pos);

            if (posDetails == null)
            {
                return NotFound();
            }

            return Ok(posDetails);
        }

        //pos user login
        [HttpPost]
        public IHttpActionResult UserLog(UserDTO UserDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Parameter Missing");
            }

            aspnetuser user = utility.GetPosUser(UserDTO);

            if (user == null)
            {
                return NotFound();
            }

            UserDTO UserDto = utility.GetUserDTO(user);

            return Ok(UserDto);
        }
    }
}
