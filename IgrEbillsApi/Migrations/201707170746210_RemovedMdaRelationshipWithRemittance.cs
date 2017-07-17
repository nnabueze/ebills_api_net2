namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedMdaRelationshipWithRemittance : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("remittances", "MDA_ID", "mda");
            DropIndex("remittances", new[] { "MDA_ID" });
        }
        
        public override void Down()
        {
            CreateIndex("remittances", "MDA_ID");
            AddForeignKey("remittances", "MDA_ID", "mda", "MDA_ID");
        }
    }
}
