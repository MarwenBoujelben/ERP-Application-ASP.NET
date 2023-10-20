namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linksAccUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAccessClasses",
                c => new
                    {
                        User_UserCIN = c.String(nullable: false, maxLength: 128),
                        AccessClass_AccessId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserCIN, t.AccessClass_AccessId })
                .ForeignKey("dbo.Users", t => t.User_UserCIN, cascadeDelete: true)
                .ForeignKey("dbo.AccessClasses", t => t.AccessClass_AccessId, cascadeDelete: true)
                .Index(t => t.User_UserCIN)
                .Index(t => t.AccessClass_AccessId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAccessClasses", "AccessClass_AccessId", "dbo.AccessClasses");
            DropForeignKey("dbo.UserAccessClasses", "User_UserCIN", "dbo.Users");
            DropIndex("dbo.UserAccessClasses", new[] { "AccessClass_AccessId" });
            DropIndex("dbo.UserAccessClasses", new[] { "User_UserCIN" });
            DropTable("dbo.UserAccessClasses");
        }
    }
}
