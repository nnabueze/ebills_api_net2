namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterAspNetUser : DbMigration
    {
        public override void Up()
        {

            DropColumn("aspnetusers", "IGRCode");
            DropColumn("aspnetusers", "MDACode");
        }
        
        public override void Down()
        {
            AddColumn("aspnetusers", "MDACode", c => c.String(nullable: false, maxLength: 38, storeType: "nvarchar"));
            AddColumn("aspnetusers", "IGRCode", c => c.String(nullable: false, maxLength: 38, storeType: "nvarchar"));

        }
    }
}
