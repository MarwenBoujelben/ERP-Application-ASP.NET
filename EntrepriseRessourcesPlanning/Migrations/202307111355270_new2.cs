namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new2 : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.Users");
        }
    }
}
