namespace IgrEbillsApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("igrdb.mda_stations")]
    public partial class mda_stations
    {
        [Key]
        [StringLength(38)]
        public string MDAStation_ID { get; set; }

        [Required]
        [StringLength(38)]
        public string MDA_ID { get; set; }

        [StringLength(100)]
        public string MDAStation_Name { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }
    }
}
