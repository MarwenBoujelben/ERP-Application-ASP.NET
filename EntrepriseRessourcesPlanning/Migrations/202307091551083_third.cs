namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Photo");
        }
    }
}
