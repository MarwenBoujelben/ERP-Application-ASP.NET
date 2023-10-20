namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttToNotif : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "NotificationAction", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "NotificationAction");
        }
    }
}
