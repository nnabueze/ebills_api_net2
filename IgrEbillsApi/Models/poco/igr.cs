namespace IgrEbillsApi.Models.poco
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("igrdb.igr")]
    public partial class igr
    {
        [Key]
        public int Id { get; set; }

        [StringLength(38)]
        public string IGR_Code { get; set; }

        [StringLength(200)]
        public string IGR_Name { get; set; }

        [StringLength(100)]
        public string Logo { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }
    }
}
