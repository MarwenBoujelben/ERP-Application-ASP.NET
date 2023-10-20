namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAccLine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accesses", "AccRole", c => c.String());
            DropColumn("dbo.Accesses", "Acc_Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accesses", "Acc_Role", c => c.String());
            DropColumn("dbo.Accesses", "AccRole");
        }
    }
}
