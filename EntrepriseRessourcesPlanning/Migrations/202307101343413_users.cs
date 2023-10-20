namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class users : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAccesses",
                c => new
                    {
                        AccessId = c.Int(nullable: false, identity: true),
                        Access = c.String(),
                        User_UserCIN = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AccessId)
                .ForeignKey("dbo.Users", t => t.User_UserCIN)
                .Index(t => t.User_UserCIN);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserCIN = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserCIN);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAccesses", "User_UserCIN", "dbo.Users");
            DropIndex("dbo.UserAccesses", new[] { "User_UserCIN" });
            DropTable("dbo.Users");
            DropTable("dbo.UserAccesses");
        }
    }
}
