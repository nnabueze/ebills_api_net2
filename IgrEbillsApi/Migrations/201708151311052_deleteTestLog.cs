namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteTestLog : DbMigration
    {
        public override void Up()
        {
            DropTable("TestLogs");
        }
        
        public override void Down()
        {
            CreateTable(
                "TestLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
