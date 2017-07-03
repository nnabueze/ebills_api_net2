namespace IgrEbillsApi.Models.poco
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("igrdb.subheads")]
    public partial class subhead
    {
        [Key]
        [StringLength(38)]
        public string SubHead_ID { get; set; }

        [StringLength(50)]
        public string SubHead_Code { get; set; }

        [Required]
        [StringLength(38)]
        public string RevHead_ID { get; set; }

        [StringLength(200)]
        public string SubHead_Name { get; set; }

        public decimal? Amount { get; set; }

        public decimal? Government { get; set; }

        public decimal? Agency { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Column(TypeName = "bit")]
        public bool? Taxable { get; set; }
    }
}
