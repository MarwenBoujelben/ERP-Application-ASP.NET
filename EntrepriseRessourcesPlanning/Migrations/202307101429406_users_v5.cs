namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class users_v5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserUserAccesses",
                c => new
                    {
                        User_UserCIN = c.String(nullable: false, maxLength: 128),
                        UserAccess_AccessId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserCIN, t.UserAccess_AccessId })
                .ForeignKey("dbo.Users", t => t.User_UserCIN, cascadeDelete: true)
                .ForeignKey("dbo.UserAccesses", t => t.UserAccess_AccessId, cascadeDelete: true)
                .Index(t => t.User_UserCIN)
                .Index(t => t.UserAccess_AccessId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserUserAccesses", "UserAccess_AccessId", "dbo.UserAccesses");
            DropForeignKey("dbo.UserUserAccesses", "User_UserCIN", "dbo.Users");
            DropIndex("dbo.UserUserAccesses", new[] { "UserAccess_AccessId" });
            DropIndex("dbo.UserUserAccesses", new[] { "User_UserCIN" });
            DropTable("dbo.UserUserAccesses");
        }
    }
}
