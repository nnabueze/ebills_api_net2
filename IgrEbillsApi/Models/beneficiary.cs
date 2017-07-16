namespace IgrEbillsApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("beneficiaries")]
    public partial class beneficiary
    {
        [Key]
        [StringLength(38)]
        public string Benefuciary_ID { get; set; }

        [StringLength(38)]
        public string MDA_ID { get; set; }

        [StringLength(20)]
        public string Account_Number { get; set; }

        [StringLength(250)]
        public string AccountName { get; set; }

        [StringLength(38)]
        public string BankID { get; set; }

        [StringLength(200)]
        public string Narration { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(200)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
