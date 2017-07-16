namespace IgrEbillsApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("reportslisting")]
    public partial class reportslisting
    {
        [Key]
        [StringLength(38)]
        public string listing_ID { get; set; }

        [StringLength(50)]
        public string MenuName { get; set; }

        [StringLength(200)]
        public string ReportServerURL { get; set; }

        [StringLength(50)]
        public string MenuUrl { get; set; }

        [StringLength(38)]
        public string ParentID { get; set; }

        [StringLength(38)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
