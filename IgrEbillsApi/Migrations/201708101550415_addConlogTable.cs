namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addConlogTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "logs", newName: "Conlogs");
        }
        
        public override void Down()
        {
            RenameTable(name: "Conlogs", newName: "logs");
        }
    }
}
