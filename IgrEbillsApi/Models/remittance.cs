namespace IgrEbillsApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("remittances")]
    public partial class remittance
    {
        [Key]
        [StringLength(38)]
        public string remittance_id { get; set; }

        public decimal? amount { get; set; }

        public RemittanceStatus remittance_status { get; set; }

        [StringLength(38)]
        public string MDAStation_ID { get; set; }

        [StringLength(38)]
        public string MDA_ID { get; set; }

        [Required]
        [StringLength(38)]
        public string USER_ID { get; set; }

        [Required]
        [StringLength(38)]
        public string POS_ID { get; set; }

        public DateTime? remtted_date { get; set; }

        public DateTime? create_at { get; set; }

        public DateTime? updated_at { get; set; }
    }

    public enum RemittanceStatus
    {
        NonRemitted=0,
        Remitted=1
    }
}
