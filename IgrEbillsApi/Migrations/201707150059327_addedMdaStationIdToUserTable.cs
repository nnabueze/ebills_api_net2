namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedMdaStationIdToUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.aspnetusers", "MDAStation_ID", c => c.String(maxLength: 38, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.aspnetusers", "MDAStation_ID");
        }
    }
}
