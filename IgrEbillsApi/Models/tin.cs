namespace IgrEbillsApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("igrdb.tins")]
    public partial class tin
    {
        [Key]
        [StringLength(38)]
        public string tin_id { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        [StringLength(200)]
        public string email { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string address { get; set; }

        [StringLength(38)]
        public string IGR_Code { get; set; }

        [StringLength(200)]
        public string tin_no { get; set; }

        [StringLength(200)]
        public string temporary_tin { get; set; }

        [StringLength(200)]
        public string phone { get; set; }

        [StringLength(100)]
        public string nationality { get; set; }

        [StringLength(200)]
        public string identification { get; set; }

        [StringLength(200)]
        public string bussiness_type { get; set; }

        [StringLength(200)]
        public string bussinesss_name { get; set; }

        [StringLength(200)]
        public string bussiness_address { get; set; }

        [StringLength(200)]
        public string bussiness_no { get; set; }

        [StringLength(200)]
        public string reg_bus_name { get; set; }

        public DateTime? commencement_date { get; set; }

        [Column(TypeName = "enum")]
        [StringLength(65532)]
        public string tin_type { get; set; }

        public DateTime? create_at { get; set; }

        public DateTime? updated_at { get; set; }

        public virtual igr igr { get; set; }
    }
}
