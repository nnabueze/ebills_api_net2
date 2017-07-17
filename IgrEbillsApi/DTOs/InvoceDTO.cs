using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IgrEbillsApi.DTOs
{
    public class InvoceDTO
    {
        [Key]
        [StringLength(38)]
        public string invoice_id { get; set; }

        [Required]
        public decimal? amount { get; set; }

        [StringLength(38)]
        public string MDA_ID { get; set; }

        [Required]
        [StringLength(200)]
        public string name { get; set; }

        [StringLength(200)]
        public string email { get; set; }

        [StringLength(200)]
        public string phone { get; set; }

        [Required]
        public string USER_ID { get; set; }

        [Required]
        public string POS_ID { get; set; }

        public int Message { get; set; }
    }
}