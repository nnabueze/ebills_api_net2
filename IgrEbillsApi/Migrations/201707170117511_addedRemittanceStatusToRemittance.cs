namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRemittanceStatusToRemittance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.remittances", "remittance_status", c => c.Int(nullable: false));
            AddColumn("dbo.remittances", "MDAStation_ID", c => c.String(maxLength: 38, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.remittances", "MDAStation_ID");
            DropColumn("dbo.remittances", "remittance_status");
        }
    }
}
