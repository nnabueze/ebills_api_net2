namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkingMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.pos_collection", "Phone", c => c.String(nullable: false, maxLength: 38, storeType: "nvarchar"));
            AlterColumn("dbo.pos_collection", "Name", c => c.String(nullable: false, maxLength: 200, storeType: "nvarchar"));
            AlterColumn("dbo.pos_collection", "USER_ID", c => c.String(nullable: false, maxLength: 38, storeType: "nvarchar"));
            AlterColumn("dbo.pos_collection", "MDAStation_ID", c => c.String(nullable: false, maxLength: 38, storeType: "nvarchar"));
            AlterColumn("dbo.pos_collection", "SubHead_ID", c => c.String(nullable: false, maxLength: 38, storeType: "nvarchar"));
            AlterColumn("dbo.pos_collection", "POS_ID", c => c.String(nullable: false, maxLength: 38, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.pos_collection", "POS_ID", c => c.String(maxLength: 38, storeType: "nvarchar"));
            AlterColumn("dbo.pos_collection", "SubHead_ID", c => c.String(maxLength: 38, storeType: "nvarchar"));
            AlterColumn("dbo.pos_collection", "MDAStation_ID", c => c.String(maxLength: 38, storeType: "nvarchar"));
            AlterColumn("dbo.pos_collection", "USER_ID", c => c.String(maxLength: 38, storeType: "nvarchar"));
            AlterColumn("dbo.pos_collection", "Name", c => c.String(maxLength: 200, storeType: "nvarchar"));
            AlterColumn("dbo.pos_collection", "Phone", c => c.String(maxLength: 38, storeType: "nvarchar"));
        }
    }
}
