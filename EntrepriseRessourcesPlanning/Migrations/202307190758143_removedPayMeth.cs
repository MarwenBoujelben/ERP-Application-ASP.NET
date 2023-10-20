namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedPayMeth : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PurchaseOrders", "PaymentMethod");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseOrders", "PaymentMethod", c => c.String());
        }
    }
}
