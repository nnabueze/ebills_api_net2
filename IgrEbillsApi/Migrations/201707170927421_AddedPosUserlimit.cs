namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPosUserlimit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.aspnetusers", "UserLimit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.aspnetusers", "UserLimit");
        }
    }
}
