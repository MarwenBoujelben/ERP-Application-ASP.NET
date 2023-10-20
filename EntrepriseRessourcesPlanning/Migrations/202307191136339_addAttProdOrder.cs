namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAttProdOrder : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ProductOrders", name: "PurchaseOrder_OrderNum", newName: "Purchase_OrderNum");
            RenameIndex(table: "dbo.ProductOrders", name: "IX_PurchaseOrder_OrderNum", newName: "IX_Purchase_OrderNum");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ProductOrders", name: "IX_Purchase_OrderNum", newName: "IX_PurchaseOrder_OrderNum");
            RenameColumn(table: "dbo.ProductOrders", name: "Purchase_OrderNum", newName: "PurchaseOrder_OrderNum");
        }
    }
}
