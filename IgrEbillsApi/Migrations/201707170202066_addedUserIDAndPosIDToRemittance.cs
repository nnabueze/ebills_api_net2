namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUserIDAndPosIDToRemittance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.remittances", "USER_ID", c => c.String(nullable: false, maxLength: 38, storeType: "nvarchar"));
            AddColumn("dbo.remittances", "POS_ID", c => c.String(nullable: false, maxLength: 38, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.remittances", "POS_ID");
            DropColumn("dbo.remittances", "USER_ID");
        }
    }
}
