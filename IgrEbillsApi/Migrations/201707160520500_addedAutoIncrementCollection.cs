namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAutoIncrementCollection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.pos_collection", "Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.pos_collection", "Id");
        }
    }
}
