namespace IgrEbillsApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("igrdb.notification")]
    public partial class notification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string sessionID { get; set; }

        [StringLength(50)]
        public string SourceBankCode { get; set; }

        [StringLength(50)]
        public string DestinationBankCode { get; set; }

        [StringLength(200)]
        public string phone { get; set; }

        public decimal? amount { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        [StringLength(38)]
        public string IGR_Code { get; set; }

        [StringLength(38)]
        public string MDA_ID { get; set; }

        [StringLength(38)]
        public string SubHead_ID { get; set; }

        [Column(TypeName = "enum")]
        [StringLength(65532)]
        public string productType { get; set; }

        [StringLength(100)]
        public string tin { get; set; }

        [StringLength(38)]
        public string remittance_id { get; set; }

        [StringLength(38)]
        public string invoice_id { get; set; }

        [StringLength(200)]
        public string refcode { get; set; }

        public DateTime? create_at { get; set; }

        public DateTime? updated_at { get; set; }
    }
}
