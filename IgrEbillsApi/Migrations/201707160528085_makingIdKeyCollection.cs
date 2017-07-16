namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makingIdKeyCollection : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("pos_collection");
            AlterColumn("pos_collection", "COLLECTION_ID", c => c.String(maxLength: 38, storeType: "nvarchar"));
            AlterColumn("pos_collection", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("pos_collection", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("pos_collection");
            AlterColumn("pos_collection", "Id", c => c.Int(nullable: false));
            AlterColumn("pos_collection", "COLLECTION_ID", c => c.String(nullable: false, maxLength: 38, storeType: "nvarchar"));
            AddPrimaryKey("pos_collection", "COLLECTION_ID");
        }
    }
}
