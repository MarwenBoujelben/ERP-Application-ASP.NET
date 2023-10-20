namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Img", c => c.Binary());
            DropColumn("dbo.Products", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Photo", c => c.Binary());
            DropColumn("dbo.Products", "Img");
        }
    }
}
