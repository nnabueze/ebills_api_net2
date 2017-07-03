namespace IgrEbillsApi.Models.poco
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IgrAdo : DbContext
    {
        public IgrAdo()
            : base("name=IgrAdo")
        {
        }

        public virtual DbSet<beneficiary> beneficiaries { get; set; }
        public virtual DbSet<igr> igrs { get; set; }
        public virtual DbSet<mda> mdas { get; set; }
        public virtual DbSet<mda_category> mda_category { get; set; }
        public virtual DbSet<mda_stations> mda_stations { get; set; }
        public virtual DbSet<pos> pos { get; set; }
        public virtual DbSet<reportslisting> reportslistings { get; set; }
        public virtual DbSet<revenuehead> revenueheads { get; set; }
        public virtual DbSet<subhead> subheads { get; set; }

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
        }
    }
}
