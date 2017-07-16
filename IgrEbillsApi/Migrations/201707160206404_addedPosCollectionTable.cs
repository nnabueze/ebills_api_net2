namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPosCollectionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.pos_collection",
                c => new
                    {
                        COLLECTION_ID = c.String(nullable: false, maxLength: 38, storeType: "nvarchar"),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Phone = c.String(maxLength: 38, storeType: "nvarchar"),
                        Name = c.String(maxLength: 200, storeType: "nvarchar"),
                        USER_ID = c.String(maxLength: 38, storeType: "nvarchar"),
                        remittance_id = c.String(maxLength: 38, storeType: "nvarchar"),
                        MDA_ID = c.String(maxLength: 38, storeType: "nvarchar"),
                        MDAStation_ID = c.String(maxLength: 38, storeType: "nvarchar"),
                        SubHead_ID = c.String(maxLength: 38, storeType: "nvarchar"),
                        POS_ID = c.String(maxLength: 38, storeType: "nvarchar"),
                        Email = c.String(maxLength: 200, storeType: "nvarchar"),
                        create_at = c.DateTime(precision: 0),
                        updated_at = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.COLLECTION_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.pos_collection");
        }
    }
}
