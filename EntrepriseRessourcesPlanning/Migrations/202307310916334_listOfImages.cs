namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class listOfImages : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "ProdImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ProdImage", c => c.Binary());
        }
    }
}
