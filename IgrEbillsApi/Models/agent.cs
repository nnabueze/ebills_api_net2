namespace IgrEbillsApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("agents")]
    public partial class agent
    {
        [Key]
        [StringLength(38)]
        public string Agent_ID { get; set; }

        [StringLength(100)]
        public string AgentName { get; set; }

        public decimal? CollectLimit { get; set; }

        [StringLength(20)]
        public string Telephone { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(38)]
        public string MDA_ID { get; set; }

        [Column(TypeName = "enum")]
        [StringLength(65532)]
        public string IsConsultant { get; set; }

        [StringLength(10)]
        public string PIN { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
