using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IgrEbillsApi.DTOs
{
    public class RemittanceDTO
    {
        public string remittance_id { get; set; }

        public decimal? amount { get; set; }

        [Required]
        public string USER_ID { get; set; }

        [Required]
        public string POS_ID { get; set; }

        public string MDA_ID { get; set; }

        [Required]
        public string MDAStation_ID { get; set; }

        public int Message { get; set; }
    }
}