namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newUserTableRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "agents",
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
                "aspnetroles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        Priviledges = c.String(maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "aspnetusers",
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
                        DateCreated = c.DateTime(precision: 0),
                        CreatedBy = c.String(maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "aspnetuserclaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "aspnetuserlogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });
            
            CreateTable(
                "bank",
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
                "aspnetuseraspnetroles",
                c => new
                    {
                        aspnetuser_Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        aspnetrole_Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.aspnetuser_Id, t.aspnetrole_Id })
                .ForeignKey("aspnetusers", t => t.aspnetuser_Id, cascadeDelete: true)
                .ForeignKey("aspnetroles", t => t.aspnetrole_Id, cascadeDelete: true)
                .Index(t => t.aspnetuser_Id)
                .Index(t => t.aspnetrole_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.aspnetuseraspnetroles", "aspnetrole_Id", "aspnetroles");
            DropForeignKey("dbo.aspnetuseraspnetroles", "aspnetuser_Id", "aspnetusers");
            DropIndex("dbo.aspnetuseraspnetroles", new[] { "aspnetrole_Id" });
            DropIndex("dbo.aspnetuseraspnetroles", new[] { "aspnetuser_Id" });
            DropTable("dbo.aspnetuseraspnetroles");
            DropTable("bank");
            DropTable("aspnetuserlogins");
            DropTable("aspnetuserclaims");
            DropTable("aspnetusers");
            DropTable("aspnetroles");
            DropTable("agents");
        }
    }
}
