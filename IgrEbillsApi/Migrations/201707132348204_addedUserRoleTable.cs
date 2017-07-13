namespace IgrEbillsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUserRoleTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "aspnetuserroles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, unicode: false),
                        RoleId = c.String(nullable: false, maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
        }
        
        public override void Down()
        {
            DropTable("aspnetuserroles");
        }
    }
}
