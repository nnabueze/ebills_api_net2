using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IgrEbillsApi.DTOs
{
    public class TinDTO
    {

        [StringLength(200)]
        public string name { get; set; }

        [StringLength(200)]
        public string email { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string address { get; set; }

        [Required]
        [StringLength(200)]
        public string TinNo { get; set; }

        [Required]
        public string USER_ID { get; set; }

        [Required]
        public string POS_ID { get; set; }

        [StringLength(200)]
        public string phone { get; set; }


    }
}