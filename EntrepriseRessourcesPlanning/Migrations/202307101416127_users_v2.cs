namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class users_v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAccesses", "User_UserCIN", "dbo.Users");
            DropIndex("dbo.UserAccesses", new[] { "User_UserCIN" });
            DropColumn("dbo.UserAccesses", "User_UserCIN");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAccesses", "User_UserCIN", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserAccesses", "User_UserCIN");
            AddForeignKey("dbo.UserAccesses", "User_UserCIN", "dbo.Users", "UserCIN");
        }
    }
}
