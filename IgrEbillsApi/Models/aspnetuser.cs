namespace IgrEbillsApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("aspnetusers")]
    public partial class aspnetuser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public aspnetuser()
        {
            aspnetroles = new HashSet<aspnetrole>();
        }

        public string Id { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        [Column(TypeName = "bit")]
        public bool EmailConfirmed { get; set; }

        [StringLength(1073741823)]
        public string PasswordHash { get; set; }

        [StringLength(1073741823)]
        public string SecurityStamp { get; set; }

        [StringLength(1073741823)]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "bit")]
        public bool PhoneNumberConfirmed { get; set; }

        [Column(TypeName = "bit")]
        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        [Column(TypeName = "bit")]
        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [Required]
        [StringLength(38)]
        public string IGRCode { get; set; }

        [Required]
        [StringLength(38)]
        public string MDACode { get; set; }

        public string Pin { get; set; }



        public DateTime? DateCreated { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aspnetrole> aspnetroles { get; set; }
    }
}
