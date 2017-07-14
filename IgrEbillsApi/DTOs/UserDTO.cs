using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IgrEbillsApi.DTOs
{
    public class UserDTO
    {        
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
        
        public string UserName { get; set; }

        public string IGRCode { get; set; }

        public string MDACode { get; set; }

        [Required]
        public string Pin { get; set; }

        [Required]
        public string ActivationCode { get; set; }
    }
}