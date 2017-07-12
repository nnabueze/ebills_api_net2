namespace IgrEbillsApi.Models.auth
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class igrconnect : DbContext
    {
        public igrconnect()
            : base("name=igrconnect")
        {
        }

        public virtual DbSet<agent> agents { get; set; }
        public virtual DbSet<aspnetrole> aspnetroles { get; set; }
        public virtual DbSet<aspnetuserclaim> aspnetuserclaims { get; set; }
        public virtual DbSet<aspnetuser> aspnetusers { get; set; }
        public virtual DbSet<bank> banks { get; set; }
        public virtual DbSet<aspnetuserlogin> aspnetuserlogins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<agent>()
                .Property(e => e.Agent_ID)
                .IsUnicode(false);

            modelBuilder.Entity<agent>()
                .Property(e => e.AgentName)
                .IsUnicode(false);

            modelBuilder.Entity<agent>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<agent>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<agent>()
                .Property(e => e.MDA_ID)
                .IsUnicode(false);

            modelBuilder.Entity<agent>()
                .Property(e => e.IsConsultant)
                .IsUnicode(false);

            modelBuilder.Entity<agent>()
                .Property(e => e.PIN)
                .IsUnicode(false);

            modelBuilder.Entity<agent>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<agent>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<aspnetrole>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<aspnetrole>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<aspnetrole>()
                .Property(e => e.Priviledges)
                .IsUnicode(false);

            modelBuilder.Entity<aspnetrole>()
                .HasMany(e => e.aspnetusers)
                .WithMany(e => e.aspnetroles)
                .Map(m => m.ToTable("aspnetuserroles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<aspnetuserclaim>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<aspnetuserclaim>()
                .Property(e => e.ClaimType)
                .IsUnicode(false);

            modelBuilder.Entity<aspnetuserclaim>()
                .Property(e => e.ClaimValue)
                .IsUnicode(false);

            modelBuilder.Entity<aspnetuser>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<aspnetuser>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<aspnetuser>()
                .Property(e => e.PasswordHash)
                .IsUnicode(false);

            modelBuilder.Entity<aspnetuser>()
                .Property(e => e.SecurityStamp)
                .IsUnicode(false);

            modelBuilder.Entity<aspnetuser>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<aspnetuser>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<aspnetuser>()
                .Property(e => e.IGRCode)
                .IsUnicode(false);

            modelBuilder.Entity<aspnetuser>()
                .Property(e => e.MDACode)
                .IsUnicode(false);

            modelBuilder.Entity<aspnetuser>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<bank>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<bank>()
                .Property(e => e.Bank_Code)
                .IsUnicode(false);

            modelBuilder.Entity<bank>()
                .Property(e => e.BankName)
                .IsUnicode(false);

            modelBuilder.Entity<bank>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<bank>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<aspnetuserlogin>()
                .Property(e => e.LoginProvider)
                .IsUnicode(false);

            modelBuilder.Entity<aspnetuserlogin>()
                .Property(e => e.ProviderKey)
                .IsUnicode(false);

            modelBuilder.Entity<aspnetuserlogin>()
                .Property(e => e.UserId)
                .IsUnicode(false);
        }
    }
}
