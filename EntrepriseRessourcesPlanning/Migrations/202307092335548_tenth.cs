namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tenth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProdImage", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProdImage");
        }
    }
}
