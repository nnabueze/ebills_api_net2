namespace IgrEbillsApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("invoices")]
    public partial class invoice
    {
        [Key]
        [StringLength(38)]
        public string invoice_id { get; set; }

        public decimal? amount { get; set; }

        [StringLength(38)]
        public string MDA_ID { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        [StringLength(200)]
        public string email { get; set; }

        [StringLength(200)]
        public string phone { get; set; }

        public DateTime? create_at { get; set; }

        public DateTime? updated_at { get; set; }
    }
}
