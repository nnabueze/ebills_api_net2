namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.remittances", "remittance_status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.remittances", "remittance_status", c => c.String(storeType: "enum"));
        }
    }
}
