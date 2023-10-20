namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveProdProvLink : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Providers", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.Providers", new[] { "Product_ProductID" });
            DropColumn("dbo.Providers", "Product_ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Providers", "Product_ProductID", c => c.Int());
            CreateIndex("dbo.Providers", "Product_ProductID");
            AddForeignKey("dbo.Providers", "Product_ProductID", "dbo.Products", "ProductID");
        }
    }
}
