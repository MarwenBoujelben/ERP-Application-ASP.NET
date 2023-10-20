namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNotifTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationID = c.Int(nullable: false, identity: true),
                        ActionID = c.Int(nullable: false),
                        Message = c.String(),
                        Username = c.String(),
                        DateTime = c.String(),
                        Access = c.String(),
                    })
                .PrimaryKey(t => t.NotificationID);
            
            CreateTable(
                "dbo.NotificationUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NotificationID = c.Int(nullable: false),
                        UserID = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NotificationUsers");
            DropTable("dbo.Notifications");
        }
    }
}
