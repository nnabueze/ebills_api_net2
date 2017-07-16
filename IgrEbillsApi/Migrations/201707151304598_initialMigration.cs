namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.agents",
                c => new
                    {
                        Agent_ID = c.String(nullable: false, maxLength: 38, storeType: "nvarchar"),
                        AgentName = c.String(maxLength: 100, storeType: "nvarchar"),
                        CollectLimit = c.Decimal(precision: 18, scale: 2),
                        Telephone = c.String(maxLength: 20, storeType: "nvarchar"),
                        Email = c.String(maxLength: 200, storeType: "nvarchar"),
                        MDA_ID = c.String(maxLength: 38, storeType: "nvarchar"),
                        PIN = c.String(maxLength: 10, storeType: "nvarchar"),
                        CreatedBy = c.String(maxLength: 100, storeType: "nvarchar"),
                        CreatedDate = c.DateTime(precision: 0),
                        ModifiedBy = c.String(maxLength: 100, storeType: "nvarchar"),
                        ModifiedDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Agent_ID);
            
            CreateTable(
                "dbo.aspnetroles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        Priviledges = c.String(maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.aspnetusers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Email = c.String(maxLength: 256, storeType: "nvarchar"),
                        EmailConfirmed = c.Boolean(nullable: false, storeType: "bit"),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false, storeType: "bit"),
                        TwoFactorEnabled = c.Boolean(nullable: false, storeType: "bit"),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false, storeType: "bit"),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        IGRCode = c.String(nullable: false, maxLength: 38, storeType: "nvarchar"),
                        MDACode = c.String(nullable: false, maxLength: 38, storeType: "nvarchar"),
                        Pin = c.String(unicode: false),
                        MDAStation_ID = c.String(maxLength: 38, storeType: "nvarchar"),
                        DateCreated = c.DateTime(precision: 0),
                        CreatedBy = c.String(maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.aspnetuserclaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.aspnetuserlogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });
            
            CreateTable(
                "dbo.aspnetuserroles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, unicode: false),
                        RoleId = c.String(nullable: false, maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.bank",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 38, storeType: "nvarchar"),
                        Bank_Code = c.String(maxLength: 10, storeType: "nvarchar"),
                        BankName = c.String(maxLength: 100, storeType: "nvarchar"),
                        CreatedBy = c.String(maxLength: 100, storeType: "nvarchar"),
                        CreatedDate = c.DateTime(precision: 0),
                        ModifiedBy = c.String(maxLength: 100, storeType: "nvarchar"),
                        ModifiedDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.beneficiaries",
                c => new
                    {
                        Benefuciary_ID = c.String(nullable: false, maxLength: 38, unicode: false),
                        MDA_ID = c.String(maxLength: 38, unicode: false),
                        Account_Number = c.String(maxLength: 20, unicode: false),
                        AccountName = c.String(maxLength: 250, unicode: false),
                        BankID = c.String(maxLength: 38, unicode: false),
                        Narration = c.String(maxLength: 200, unicode: false),
                        CreatedBy = c.String(maxLength: 100, unicode: false),
                        CreatedDate = c.DateTime(precision: 0),
                        ModifiedBy = c.String(maxLength: 200, unicode: false),
                        ModifiedDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Benefuciary_ID);
            
            CreateTable(
                "dbo.igr",
                c => new
                    {
                        IGR_Code = c.String(nullable: false, maxLength: 38, unicode: false),
                        IGR_Name = c.String(maxLength: 200, unicode: false),
                        Logo = c.String(maxLength: 100, unicode: false),
                        CreatedBy = c.String(maxLength: 100, unicode: false),
                        ModifiedBy = c.String(maxLength: 100, unicode: false),
                        DateCreated = c.DateTime(precision: 0),
                        DateUpdated = c.DateTime(precision: 0),
                        Id = c.Int(),
                    })
                .PrimaryKey(t => t.IGR_Code);
            
            CreateTable(
                "dbo.invoices",
                c => new
                    {
                        invoice_id = c.String(nullable: false, maxLength: 38, unicode: false),
                        amount = c.Decimal(precision: 18, scale: 2),
                        MDA_ID = c.String(maxLength: 38, unicode: false),
                        name = c.String(maxLength: 200, unicode: false),
                        email = c.String(maxLength: 200, unicode: false),
                        phone = c.String(maxLength: 200, unicode: false),
                        create_at = c.DateTime(precision: 0),
                        updated_at = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.invoice_id)
                .ForeignKey("dbo.mda", t => t.MDA_ID)
                .Index(t => t.MDA_ID);
            
            CreateTable(
                "dbo.mda",
                c => new
                    {
                        MDA_ID = c.String(nullable: false, maxLength: 38, unicode: false),
                        IGR_ID = c.String(nullable: false, maxLength: 38, unicode: false),
                        MDA_Category = c.String(nullable: false, maxLength: 38, unicode: false),
                        MDA_DetailedCategory = c.String(maxLength: 38, unicode: false),
                        MDA_Name = c.String(maxLength: 100, unicode: false),
                        CreatedBy = c.String(maxLength: 100, unicode: false),
                        ModifiedBy = c.String(maxLength: 100, unicode: false),
                        DateCreated = c.DateTime(precision: 0),
                        DateUpdated = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.MDA_ID);
            
            CreateTable(
                "dbo.remittances",
                c => new
                    {
                        remittance_id = c.String(nullable: false, maxLength: 38, unicode: false),
                        amount = c.Decimal(precision: 18, scale: 2),
                        MDA_ID = c.String(maxLength: 38, unicode: false),
                        remtted_date = c.DateTime(precision: 0),
                        create_at = c.DateTime(precision: 0),
                        updated_at = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.remittance_id)
                .ForeignKey("dbo.mda", t => t.MDA_ID)
                .Index(t => t.MDA_ID);
            
            CreateTable(
                "dbo.mda_category",
                c => new
                    {
                        Category_ID = c.String(nullable: false, maxLength: 38, unicode: false),
                        Category_Name = c.String(maxLength: 100, unicode: false),
                        CreatedBy = c.String(maxLength: 100, unicode: false),
                        ModifiedBy = c.String(maxLength: 100, unicode: false),
                        DateCreated = c.DateTime(precision: 0),
                        DateUpdated = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Category_ID);
            
            CreateTable(
                "dbo.mda_stations",
                c => new
                    {
                        MDAStation_ID = c.String(nullable: false, maxLength: 38, unicode: false),
                        MDA_ID = c.String(nullable: false, maxLength: 38, unicode: false),
                        MDAStation_Name = c.String(maxLength: 100, unicode: false),
                        CreatedBy = c.String(maxLength: 100, unicode: false),
                        ModifiedBy = c.String(maxLength: 100, unicode: false),
                        DateCreated = c.DateTime(precision: 0),
                        DateUpdated = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.MDAStation_ID);
            
            CreateTable(
                "dbo.notification",
                c => new
                    {
                        id = c.Int(nullable: false),
                        sessionID = c.String(maxLength: 255, unicode: false),
                        SourceBankCode = c.String(maxLength: 50, unicode: false),
                        DestinationBankCode = c.String(maxLength: 50, unicode: false),
                        phone = c.String(maxLength: 200, unicode: false),
                        amount = c.Decimal(precision: 18, scale: 2),
                        name = c.String(maxLength: 200, unicode: false),
                        IGR_Code = c.String(maxLength: 38, unicode: false),
                        MDA_ID = c.String(maxLength: 38, unicode: false),
                        SubHead_ID = c.String(maxLength: 38, unicode: false),
                        tin = c.String(maxLength: 100, unicode: false),
                        remittance_id = c.String(maxLength: 38, unicode: false),
                        invoice_id = c.String(maxLength: 38, unicode: false),
                        refcode = c.String(maxLength: 200, unicode: false),
                        create_at = c.DateTime(precision: 0),
                        updated_at = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.pos",
                c => new
                    {
                        POS_ID = c.String(nullable: false, maxLength: 38, unicode: false),
                        POS_imei = c.String(nullable: false, maxLength: 50, unicode: false),
                        POS_Name = c.String(maxLength: 100, unicode: false),
                        ActivationCode = c.String(maxLength: 50, unicode: false),
                        Activation = c.Boolean(storeType: "bit"),
                        MDA_ID = c.String(maxLength: 38, unicode: false),
                        Station_ID = c.String(maxLength: 38, unicode: false),
                        CreatedBy = c.String(maxLength: 100, unicode: false),
                        CreatedDate = c.DateTime(precision: 0),
                        ModifiedBy = c.String(maxLength: 100, unicode: false),
                        ModifiedDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.POS_ID);
            
            CreateTable(
                "dbo.reportslisting",
                c => new
                    {
                        listing_ID = c.String(nullable: false, maxLength: 38, unicode: false),
                        MenuName = c.String(maxLength: 50, unicode: false),
                        ReportServerURL = c.String(maxLength: 200, unicode: false),
                        MenuUrl = c.String(maxLength: 50, unicode: false),
                        ParentID = c.String(maxLength: 38, unicode: false),
                        UpdatedBy = c.String(maxLength: 38, unicode: false),
                        UpdatedDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.listing_ID);
            
            CreateTable(
                "dbo.revenueheads",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 38, unicode: false),
                        RevenueCode = c.String(maxLength: 20, unicode: false),
                        Biller_ID = c.String(nullable: false, maxLength: 38, unicode: false),
                        MDA_ID = c.String(nullable: false, maxLength: 38, unicode: false),
                        RevenueName = c.String(maxLength: 200, unicode: false),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        CreatedBy = c.String(maxLength: 100, unicode: false),
                        ModifiedBy = c.String(maxLength: 100, unicode: false),
                        CreatedDate = c.DateTime(precision: 0),
                        ModifiedDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.subheads",
                c => new
                    {
                        SubHead_ID = c.String(nullable: false, maxLength: 38, unicode: false),
                        SubHead_Code = c.String(maxLength: 50, unicode: false),
                        RevHead_ID = c.String(nullable: false, maxLength: 38, unicode: false),
                        SubHead_Name = c.String(maxLength: 200, unicode: false),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Government = c.Decimal(precision: 18, scale: 2),
                        Agency = c.Decimal(precision: 18, scale: 2),
                        CreatedBy = c.String(maxLength: 100, unicode: false),
                        ModifiedBy = c.String(maxLength: 100, unicode: false),
                        CreatedDate = c.DateTime(precision: 0),
                        ModifiedDate = c.DateTime(precision: 0),
                        Taxable = c.Boolean(storeType: "bit"),
                    })
                .PrimaryKey(t => t.SubHead_ID);
            
            CreateTable(
                "dbo.tins",
                c => new
                    {
                        tin_id = c.String(nullable: false, maxLength: 38, unicode: false),
                        name = c.String(maxLength: 200, unicode: false),
                        email = c.String(maxLength: 200, unicode: false),
                        address = c.String(unicode: false, storeType: "text"),
                        IGR_Code = c.String(maxLength: 38, unicode: false),
                        tin_no = c.String(maxLength: 200, unicode: false),
                        temporary_tin = c.String(maxLength: 200, unicode: false),
                        phone = c.String(maxLength: 200, unicode: false),
                        nationality = c.String(maxLength: 100, unicode: false),
                        identification = c.String(maxLength: 200, unicode: false),
                        bussiness_type = c.String(maxLength: 200, unicode: false),
                        bussinesss_name = c.String(maxLength: 200, unicode: false),
                        bussiness_address = c.String(maxLength: 200, unicode: false),
                        bussiness_no = c.String(maxLength: 200, unicode: false),
                        reg_bus_name = c.String(maxLength: 200, unicode: false),
                        commencement_date = c.DateTime(precision: 0),
                        create_at = c.DateTime(precision: 0),
                        updated_at = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.tin_id);
            
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        UserName = c.String(nullable: false, unicode: false),
                        Password = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.aspnetuseraspnetroles",
                c => new
                    {
                        aspnetuser_Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        aspnetrole_Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.aspnetuser_Id, t.aspnetrole_Id })
                .ForeignKey("dbo.aspnetusers", t => t.aspnetuser_Id, cascadeDelete: true)
                .ForeignKey("dbo.aspnetroles", t => t.aspnetrole_Id, cascadeDelete: true)
                .Index(t => t.aspnetuser_Id)
                .Index(t => t.aspnetrole_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.remittances", "MDA_ID", "dbo.mda");
            DropForeignKey("dbo.invoices", "MDA_ID", "dbo.mda");
            DropForeignKey("dbo.aspnetuseraspnetroles", "aspnetrole_Id", "dbo.aspnetroles");
            DropForeignKey("dbo.aspnetuseraspnetroles", "aspnetuser_Id", "dbo.aspnetusers");
            DropIndex("dbo.aspnetuseraspnetroles", new[] { "aspnetrole_Id" });
            DropIndex("dbo.aspnetuseraspnetroles", new[] { "aspnetuser_Id" });
            DropIndex("dbo.remittances", new[] { "MDA_ID" });
            DropIndex("dbo.invoices", new[] { "MDA_ID" });
            DropTable("dbo.aspnetuseraspnetroles");
            DropTable("dbo.UserModels");
            DropTable("dbo.tins");
            DropTable("dbo.subheads");
            DropTable("dbo.revenueheads");
            DropTable("dbo.reportslisting");
            DropTable("dbo.pos");
            DropTable("dbo.notification");
            DropTable("dbo.mda_stations");
            DropTable("dbo.mda_category");
            DropTable("dbo.remittances");
            DropTable("dbo.mda");
            DropTable("dbo.invoices");
            DropTable("dbo.igr");
            DropTable("dbo.beneficiaries");
            DropTable("dbo.bank");
            DropTable("dbo.aspnetuserroles");
            DropTable("dbo.aspnetuserlogins");
            DropTable("dbo.aspnetuserclaims");
            DropTable("dbo.aspnetusers");
            DropTable("dbo.aspnetroles");
            DropTable("dbo.agents");
        }
    }
}
