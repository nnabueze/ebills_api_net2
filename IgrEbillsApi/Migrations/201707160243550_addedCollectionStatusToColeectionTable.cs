namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCollectionStatusToColeectionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.pos_collection", "CollectionStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.pos_collection", "CollectionStatus");
        }
    }
}
