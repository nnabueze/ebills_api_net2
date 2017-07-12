namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "beneficiaries",
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
                "igr",
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
                "tins",
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
                .PrimaryKey(t => t.tin_id)
                .ForeignKey("igr", t => t.IGR_Code)
                .Index(t => t.IGR_Code);
            
            CreateTable(
                "invoices",
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
                .ForeignKey("mda", t => t.MDA_ID)
                .Index(t => t.MDA_ID);
            
            CreateTable(
                "mda",
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
                "remittances",
                c => new
                    {
                        remittance_id = c.String(nullable: false, maxLength: 38, unicode: false),
                        amount = c.Decimal(precision: 18, scale: 2),
                        remittance_status = c.String(storeType: "enum"),
                        MDA_ID = c.String(maxLength: 38, unicode: false),
                        remtted_date = c.DateTime(precision: 0),
                        create_at = c.DateTime(precision: 0),
                        updated_at = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.remittance_id)
                .ForeignKey("mda", t => t.MDA_ID)
                .Index(t => t.MDA_ID);
            
            CreateTable(
                "mda_category",
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
                "mda_stations",
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
                "notification",
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
                "pos",
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
                "reportslisting",
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
                "revenueheads",
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
                "subheads",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("remittances", "MDA_ID", "mda");
            DropForeignKey("invoices", "MDA_ID", "mda");
            DropForeignKey("tins", "IGR_Code", "igr");
            DropIndex("remittances", new[] { "MDA_ID" });
            DropIndex("invoices", new[] { "MDA_ID" });
            DropIndex("tins", new[] { "IGR_Code" });
            DropTable("subheads");
            DropTable("revenueheads");
            DropTable("reportslisting");
            DropTable("pos");
            DropTable("notification");
            DropTable("mda_stations");
            DropTable("mda_category");
            DropTable("remittances");
            DropTable("mda");
            DropTable("invoices");
            DropTable("tins");
            DropTable("igr");
            DropTable("beneficiaries");
        }
    }
}