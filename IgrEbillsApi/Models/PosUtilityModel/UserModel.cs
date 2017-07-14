using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IgrEbillsApi.Models.PosUtilityModel
{
    public class UserModel
    {
        [Required]
        public string Phone { get; set; }

        [Required]
        public string Pin { get; set; }

        [Required]
        public string ActivationCode { get; set; }
    }
}