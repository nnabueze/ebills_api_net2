namespace IgrEbillsApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IgrAdo : DbContext
    {
        public IgrAdo()
            : base("name=IgrAdo1")
        {
        }

        public virtual DbSet<beneficiary> beneficiaries { get; set; }
        public virtual DbSet<igr> igrs { get; set; }
        public virtual DbSet<invoice> invoices { get; set; }
        public virtual DbSet<mda> mdas { get; set; }
        public virtual DbSet<mda_category> mda_category { get; set; }
        public virtual DbSet<mda_stations> mda_stations { get; set; }
        public virtual DbSet<notification> notifications { get; set; }
        public virtual DbSet<pos> pos { get; set; }
        public virtual DbSet<remittance> remittances { get; set; }
        public virtual DbSet<reportslisting> reportslistings { get; set; }
        public virtual DbSet<revenuehead> revenueheads { get; set; }
        public virtual DbSet<subhead> subheads { get; set; }
        public virtual DbSet<tin> tins { get; set; }

        public virtual DbSet<pos_collection> pos_collections { get; set; }

        public virtual DbSet<agent> agents { get; set; }
        public virtual DbSet<aspnetrole> aspnetroles { get; set; }
        public virtual DbSet<aspnetuserclaim> aspnetuserclaims { get; set; }
        public virtual DbSet<aspnetuser> aspnetusers { get; set; }
        public virtual DbSet<bank> banks { get; set; }
        public virtual DbSet<aspnetuserlogin> aspnetuserlogins { get; set; }
        public virtual DbSet<aspnetuserrole> aspnetuserroles { get; set; }

        public virtual DbSet<UserModel> UserModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<beneficiary>()
                .Property(e => e.Benefuciary_ID)
                .IsUnicode(false);

            modelBuilder.Entity<beneficiary>()
                .Property(e => e.MDA_ID)
                .IsUnicode(false);

            modelBuilder.Entity<beneficiary>()
                .Property(e => e.Account_Number)
                .IsUnicode(false);

            modelBuilder.Entity<beneficiary>()
                .Property(e => e.AccountName)
                .IsUnicode(false);

            modelBuilder.Entity<beneficiary>()
                .Property(e => e.BankID)
                .IsUnicode(false);

            modelBuilder.Entity<beneficiary>()
                .Property(e => e.Narration)
                .IsUnicode(false);

            modelBuilder.Entity<beneficiary>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<beneficiary>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<igr>()
                .Property(e => e.IGR_Code)
                .IsUnicode(false);

            modelBuilder.Entity<igr>()
                .Property(e => e.IGR_Name)
                .IsUnicode(false);

            modelBuilder.Entity<igr>()
                .Property(e => e.Logo)
                .IsUnicode(false);

            modelBuilder.Entity<igr>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<igr>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<invoice>()
                .Property(e => e.invoice_id)
                .IsUnicode(false);

            modelBuilder.Entity<invoice>()
                .Property(e => e.invoice_status)
                .IsUnicode(false);

            modelBuilder.Entity<invoice>()
                .Property(e => e.MDA_ID)
                .IsUnicode(false);

            modelBuilder.Entity<invoice>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<invoice>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<invoice>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<mda>()
                .Property(e => e.MDA_ID)
                .IsUnicode(false);

            modelBuilder.Entity<mda>()
                .Property(e => e.IGR_ID)
                .IsUnicode(false);

            modelBuilder.Entity<mda>()
                .Property(e => e.MDA_Category)
                .IsUnicode(false);

            modelBuilder.Entity<mda>()
                .Property(e => e.MDA_DetailedCategory)
                .IsUnicode(false);

            modelBuilder.Entity<mda>()
                .Property(e => e.MDA_Name)
                .IsUnicode(false);

            modelBuilder.Entity<mda>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<mda>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<mda_category>()
                .Property(e => e.Category_ID)
                .IsUnicode(false);

            modelBuilder.Entity<mda_category>()
                .Property(e => e.Category_Name)
                .IsUnicode(false);

            modelBuilder.Entity<mda_category>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<mda_category>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<mda_stations>()
                .Property(e => e.MDAStation_ID)
                .IsUnicode(false);

            modelBuilder.Entity<mda_stations>()
                .Property(e => e.MDA_ID)
                .IsUnicode(false);

            modelBuilder.Entity<mda_stations>()
                .Property(e => e.MDAStation_Name)
                .IsUnicode(false);

            modelBuilder.Entity<mda_stations>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<mda_stations>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.sessionID)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.SourceBankCode)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.DestinationBankCode)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.IGR_Code)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.MDA_ID)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.SubHead_ID)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.productType)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.tin)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.remittance_id)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.invoice_id)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.refcode)
                .IsUnicode(false);

            modelBuilder.Entity<pos>()
                .Property(e => e.POS_ID)
                .IsUnicode(false);

            modelBuilder.Entity<pos>()
                .Property(e => e.POS_imei)
                .IsUnicode(false);

            modelBuilder.Entity<pos>()
                .Property(e => e.POS_Name)
                .IsUnicode(false);

            modelBuilder.Entity<pos>()
                .Property(e => e.ActivationCode)
                .IsUnicode(false);

            modelBuilder.Entity<pos>()
                .Property(e => e.MDA_ID)
                .IsUnicode(false);

            modelBuilder.Entity<pos>()
                .Property(e => e.Station_ID)
                .IsUnicode(false);

            modelBuilder.Entity<pos>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<pos>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<remittance>()
                .Property(e => e.remittance_id)
                .IsUnicode(false);

            modelBuilder.Entity<remittance>()
                .Property(e => e.MDA_ID)
                .IsUnicode(false);

            modelBuilder.Entity<reportslisting>()
                .Property(e => e.listing_ID)
                .IsUnicode(false);

            modelBuilder.Entity<reportslisting>()
                .Property(e => e.MenuName)
                .IsUnicode(false);

            modelBuilder.Entity<reportslisting>()
                .Property(e => e.ReportServerURL)
                .IsUnicode(false);

            modelBuilder.Entity<reportslisting>()
                .Property(e => e.MenuUrl)
                .IsUnicode(false);

            modelBuilder.Entity<reportslisting>()
                .Property(e => e.ParentID)
                .IsUnicode(false);

            modelBuilder.Entity<reportslisting>()
                .Property(e => e.UpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<revenuehead>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<revenuehead>()
                .Property(e => e.RevenueCode)
                .IsUnicode(false);

            modelBuilder.Entity<revenuehead>()
                .Property(e => e.Biller_ID)
                .IsUnicode(false);

            modelBuilder.Entity<revenuehead>()
                .Property(e => e.MDA_ID)
                .IsUnicode(false);

            modelBuilder.Entity<revenuehead>()
                .Property(e => e.RevenueName)
                .IsUnicode(false);

            modelBuilder.Entity<revenuehead>()
                .Property(e => e.Taxable)
                .IsUnicode(false);

            modelBuilder.Entity<revenuehead>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<revenuehead>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<subhead>()
                .Property(e => e.SubHead_ID)
                .IsUnicode(false);

            modelBuilder.Entity<subhead>()
                .Property(e => e.SubHead_Code)
                .IsUnicode(false);

            modelBuilder.Entity<subhead>()
                .Property(e => e.RevHead_ID)
                .IsUnicode(false);

            modelBuilder.Entity<subhead>()
                .Property(e => e.SubHead_Name)
                .IsUnicode(false);

            modelBuilder.Entity<subhead>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<subhead>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tin>()
                .Property(e => e.tin_id)
                .IsUnicode(false);

            modelBuilder.Entity<tin>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tin>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tin>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<tin>()
                .Property(e => e.IGR_Code)
                .IsUnicode(false);

            modelBuilder.Entity<tin>()
                .Property(e => e.tin_no)
                .IsUnicode(false);

            modelBuilder.Entity<tin>()
                .Property(e => e.temporary_tin)
                .IsUnicode(false);

            modelBuilder.Entity<tin>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<tin>()
                .Property(e => e.nationality)
                .IsUnicode(false);

            modelBuilder.Entity<tin>()
                .Property(e => e.identification)
                .IsUnicode(false);

            modelBuilder.Entity<tin>()
                .Property(e => e.bussiness_type)
                .IsUnicode(false);

            modelBuilder.Entity<tin>()
                .Property(e => e.bussinesss_name)
                .IsUnicode(false);

            modelBuilder.Entity<tin>()
                .Property(e => e.bussiness_address)
                .IsUnicode(false);

            modelBuilder.Entity<tin>()
                .Property(e => e.bussiness_no)
                .IsUnicode(false);

            modelBuilder.Entity<tin>()
                .Property(e => e.reg_bus_name)
                .IsUnicode(false);

            modelBuilder.Entity<aspnetuserrole>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<aspnetuserrole>()
                .Property(e => e.RoleId)
                .IsUnicode(false);
        }
    }
}
