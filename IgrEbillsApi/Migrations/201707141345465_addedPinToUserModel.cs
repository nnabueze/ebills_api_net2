namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPinToUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.aspnetusers", "IGRCode", c => c.String(nullable: false, maxLength: 38, storeType: "nvarchar"));
            AddColumn("dbo.aspnetusers", "MDACode", c => c.String(nullable: false, maxLength: 38, storeType: "nvarchar"));
            AddColumn("dbo.aspnetusers", "Pin", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.aspnetusers", "Pin");
            DropColumn("dbo.aspnetusers", "MDACode");
            DropColumn("dbo.aspnetusers", "IGRCode");
        }
    }
}
