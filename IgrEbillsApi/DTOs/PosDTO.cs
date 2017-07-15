using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IgrEbillsApi.DTOs
{
    public class PosDTO
    {

        [StringLength(50)]
        [Required]
        public string ActivationCode { get; set; }

        [StringLength(38)]
        public string POS_ID { get; set; }


    }
}