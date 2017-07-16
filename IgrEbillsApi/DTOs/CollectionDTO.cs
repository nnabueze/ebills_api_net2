using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IgrEbillsApi.DTOs
{
    public class CollectionDTO
    {
        [StringLength(38)]
        public string COLLECTION_ID { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(38)]
        public string Phone { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(38)]
        public string USER_ID { get; set; }

        [StringLength(38)]
        public string MDA_ID { get; set; }

        [Required]
        [StringLength(38)]
        public string MDAStation_ID { get; set; }

        [Required]
        [StringLength(38)]
        public string SubHead_ID { get; set; }

        [Required]
        [StringLength(38)]
        public string POS_ID { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        public bool Type { get; set; }
    }
}