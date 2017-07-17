namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedInvoiceStatus : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("invoices", "MDA_ID", "mda");
            DropIndex("invoices", new[] { "MDA_ID" });
            DropColumn("invoices", "invoice_status");
        }
        
        public override void Down()
        {
            AddColumn("invoices", "invoice_status", c => c.String(storeType: "enum"));
            CreateIndex("invoices", "MDA_ID");
            AddForeignKey("invoices", "MDA_ID", "mda", "MDA_ID");
        }
    }
}
