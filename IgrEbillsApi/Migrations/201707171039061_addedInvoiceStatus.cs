namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedInvoiceStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.mda", "Invoice_status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.mda", "Invoice_status");
        }
    }
}
