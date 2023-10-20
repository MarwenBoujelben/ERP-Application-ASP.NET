namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eleventh : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProviderProducts", newName: "ProductProviders");
            DropPrimaryKey("dbo.ProductProviders");
            AddPrimaryKey("dbo.ProductProviders", new[] { "Product_ProductID", "Provider_ProviderID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProductProviders");
            AddPrimaryKey("dbo.ProductProviders", new[] { "Provider_ProviderID", "Product_ProductID" });
            RenameTable(name: "dbo.ProductProviders", newName: "ProviderProducts");
        }
    }
}
