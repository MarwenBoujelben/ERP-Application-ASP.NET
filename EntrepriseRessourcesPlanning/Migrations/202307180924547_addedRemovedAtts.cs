namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRemovedAtts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseOrders", "Invoice_InvoiceID", "dbo.Invoices");
            DropIndex("dbo.PurchaseOrders", new[] { "Invoice_InvoiceID" });
            AddColumn("dbo.Receipts", "Invoice_InvoiceID", c => c.Int());
            CreateIndex("dbo.Receipts", "Invoice_InvoiceID");
            AddForeignKey("dbo.Receipts", "Invoice_InvoiceID", "dbo.Invoices", "InvoiceID");
            DropColumn("dbo.PurchaseOrders", "Invoice_InvoiceID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseOrders", "Invoice_InvoiceID", c => c.Int());
            DropForeignKey("dbo.Receipts", "Invoice_InvoiceID", "dbo.Invoices");
            DropIndex("dbo.Receipts", new[] { "Invoice_InvoiceID" });
            DropColumn("dbo.Receipts", "Invoice_InvoiceID");
            CreateIndex("dbo.PurchaseOrders", "Invoice_InvoiceID");
            AddForeignKey("dbo.PurchaseOrders", "Invoice_InvoiceID", "dbo.Invoices", "InvoiceID");
        }
    }
}
