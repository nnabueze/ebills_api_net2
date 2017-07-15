namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedTinIgrRelationShip : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("tins", "IGR_Code", "igr");
            DropIndex("tins", new[] { "IGR_Code" });
        }
        
        public override void Down()
        {
            CreateIndex("tins", "IGR_Code");
            AddForeignKey("tins", "IGR_Code", "igr", "IGR_Code");
        }
    }
}
