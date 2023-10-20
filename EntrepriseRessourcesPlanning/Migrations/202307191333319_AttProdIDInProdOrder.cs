namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttProdIDInProdOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductOrders", "ProductID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductOrders", "ProductID");
        }
    }
}
