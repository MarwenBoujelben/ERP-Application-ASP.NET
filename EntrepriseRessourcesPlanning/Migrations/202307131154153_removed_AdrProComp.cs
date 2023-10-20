namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_AdrProComp : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductProviders", newName: "ProviderProducts");
            DropPrimaryKey("dbo.ProviderProducts");
            AddPrimaryKey("dbo.ProviderProducts", new[] { "Provider_ProviderID", "Product_ProductID" });
            DropColumn("dbo.PurchaseOrders", "AdrProvider");
            DropColumn("dbo.PurchaseOrders", "AdrCompany");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseOrders", "AdrCompany", c => c.String());
            AddColumn("dbo.PurchaseOrders", "AdrProvider", c => c.String());
            DropPrimaryKey("dbo.ProviderProducts");
            AddPrimaryKey("dbo.ProviderProducts", new[] { "Product_ProductID", "Provider_ProviderID" });
            RenameTable(name: "dbo.ProviderProducts", newName: "ProductProviders");
        }
    }
}
