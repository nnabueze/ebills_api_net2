namespace IgrEbillsApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("igrdb.revenueheads")]
    public partial class revenuehead
    {
        [StringLength(38)]
        public string ID { get; set; }

        [StringLength(20)]
        public string RevenueCode { get; set; }

        [Required]
        [StringLength(38)]
        public string Biller_ID { get; set; }

        [Required]
        [StringLength(38)]
        public string MDA_ID { get; set; }

        [StringLength(200)]
        public string RevenueName { get; set; }

        public decimal? Amount { get; set; }

        [Column(TypeName = "enum")]
        [StringLength(65532)]
        public string Taxable { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
