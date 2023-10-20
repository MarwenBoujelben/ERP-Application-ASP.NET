namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategToProdOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductOrders", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductOrders", "Category");
        }
    }
}
