namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStationIdToInvoice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.invoices", "MDAStation_ID", c => c.String(maxLength: 200, storeType: "nvarchar"));
            AddColumn("dbo.invoices", "USER_ID", c => c.String(unicode: false));
            AddColumn("dbo.invoices", "POS_ID", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.invoices", "POS_ID");
            DropColumn("dbo.invoices", "USER_ID");
            DropColumn("dbo.invoices", "MDAStation_ID");
        }
    }
}
