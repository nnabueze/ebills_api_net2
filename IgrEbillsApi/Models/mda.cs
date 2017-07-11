namespace IgrEbillsApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("igrdb.mda")]
    public partial class mda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mda()
        {
            invoices = new HashSet<invoice>();
            remittances = new HashSet<remittance>();
        }

        [Key]
        [StringLength(38)]
        public string MDA_ID { get; set; }

        [Required]
        [StringLength(38)]
        public string IGR_ID { get; set; }

        [Required]
        [StringLength(38)]
        public string MDA_Category { get; set; }

        [StringLength(38)]
        public string MDA_DetailedCategory { get; set; }

        [StringLength(100)]
        public string MDA_Name { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<invoice> invoices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<remittance> remittances { get; set; }
    }
}
