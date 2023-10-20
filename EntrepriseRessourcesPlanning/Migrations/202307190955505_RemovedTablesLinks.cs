namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedTablesLinks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "Company_RegistrationNumber", "dbo.Companies");
            DropForeignKey("dbo.ProductProviders", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductProviders", "Provider_ProviderID", "dbo.Providers");
            DropForeignKey("dbo.Invoices", "Provider_ProviderID", "dbo.Providers");
            DropForeignKey("dbo.Receipts", "Company_RegistrationNumber", "dbo.Companies");
            DropForeignKey("dbo.Receipts", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.Receipts", "Provider_ProviderID", "dbo.Providers");
            DropForeignKey("dbo.PurchaseOrders", "Company_RegistrationNumber", "dbo.Companies");
            DropForeignKey("dbo.PurchaseOrders", "Provider_ProviderID", "dbo.Providers");
            DropForeignKey("dbo.PurchaseOrders", "Receipt_ReceiptID", "dbo.Receipts");
            DropForeignKey("dbo.Quotations", "Company_RegistrationNumber", "dbo.Companies");
            DropForeignKey("dbo.ProductOrders", "Quotation_NumQuotation", "dbo.Quotations");
            DropForeignKey("dbo.Quotations", "Provider_ProviderID", "dbo.Providers");
            DropIndex("dbo.Invoices", new[] { "Company_RegistrationNumber" });
            DropIndex("dbo.Invoices", new[] { "Provider_ProviderID" });
            DropIndex("dbo.Receipts", new[] { "Company_RegistrationNumber" });
            DropIndex("dbo.Receipts", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.Receipts", new[] { "Provider_ProviderID" });
            DropIndex("dbo.PurchaseOrders", new[] { "Company_RegistrationNumber" });
            DropIndex("dbo.PurchaseOrders", new[] { "Provider_ProviderID" });
            DropIndex("dbo.PurchaseOrders", new[] { "Receipt_ReceiptID" });
            DropIndex("dbo.ProductOrders", new[] { "Quotation_NumQuotation" });
            DropIndex("dbo.Quotations", new[] { "Company_RegistrationNumber" });
            DropIndex("dbo.Quotations", new[] { "Provider_ProviderID" });
            DropIndex("dbo.ProductProviders", new[] { "Product_ProductID" });
            DropIndex("dbo.ProductProviders", new[] { "Provider_ProviderID" });
            AddColumn("dbo.Invoices", "ProviderID", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "CompanyID", c => c.Int(nullable: false));
            AddColumn("dbo.Providers", "Product_ProductID", c => c.Int());
            AddColumn("dbo.Receipts", "ProviderID", c => c.Int(nullable: false));
            AddColumn("dbo.Receipts", "CompanyID", c => c.Int(nullable: false));
            AddColumn("dbo.Receipts", "InvoiceID", c => c.Int(nullable: false));
            AddColumn("dbo.PurchaseOrders", "CompanyID", c => c.Int(nullable: false));
            AddColumn("dbo.PurchaseOrders", "ProviderID", c => c.Int(nullable: false));
            AddColumn("dbo.PurchaseOrders", "ReceiptID", c => c.Int(nullable: false));
            CreateIndex("dbo.Providers", "Product_ProductID");
            AddForeignKey("dbo.Providers", "Product_ProductID", "dbo.Products", "ProductID");
            DropColumn("dbo.Invoices", "Company_RegistrationNumber");
            DropColumn("dbo.Invoices", "Provider_ProviderID");
            DropColumn("dbo.Receipts", "Company_RegistrationNumber");
            DropColumn("dbo.Receipts", "Invoice_InvoiceID");
            DropColumn("dbo.Receipts", "Provider_ProviderID");
            DropColumn("dbo.PurchaseOrders", "Company_RegistrationNumber");
            DropColumn("dbo.PurchaseOrders", "Provider_ProviderID");
            DropColumn("dbo.PurchaseOrders", "Receipt_ReceiptID");
            DropColumn("dbo.ProductOrders", "Quotation_NumQuotation");
            DropTable("dbo.Quotations");
            DropTable("dbo.ProductProviders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductProviders",
                c => new
                    {
                        Product_ProductID = c.Int(nullable: false),
                        Provider_ProviderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductID, t.Provider_ProviderID });
            
            CreateTable(
                "dbo.Quotations",
                c => new
                    {
                        NumQuotation = c.Int(nullable: false, identity: true),
                        DateQuotation = c.DateTime(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Company_RegistrationNumber = c.Int(),
                        Provider_ProviderID = c.Int(),
                    })
                .PrimaryKey(t => t.NumQuotation);
            
            AddColumn("dbo.ProductOrders", "Quotation_NumQuotation", c => c.Int());
            AddColumn("dbo.PurchaseOrders", "Receipt_ReceiptID", c => c.Int());
            AddColumn("dbo.PurchaseOrders", "Provider_ProviderID", c => c.Int());
            AddColumn("dbo.PurchaseOrders", "Company_RegistrationNumber", c => c.Int());
            AddColumn("dbo.Receipts", "Provider_ProviderID", c => c.Int());
            AddColumn("dbo.Receipts", "Invoice_InvoiceID", c => c.Int());
            AddColumn("dbo.Receipts", "Company_RegistrationNumber", c => c.Int());
            AddColumn("dbo.Invoices", "Provider_ProviderID", c => c.Int());
            AddColumn("dbo.Invoices", "Company_RegistrationNumber", c => c.Int());
            DropForeignKey("dbo.Providers", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.Providers", new[] { "Product_ProductID" });
            DropColumn("dbo.PurchaseOrders", "ReceiptID");
            DropColumn("dbo.PurchaseOrders", "ProviderID");
            DropColumn("dbo.PurchaseOrders", "CompanyID");
            DropColumn("dbo.Receipts", "InvoiceID");
            DropColumn("dbo.Receipts", "CompanyID");
            DropColumn("dbo.Receipts", "ProviderID");
            DropColumn("dbo.Providers", "Product_ProductID");
            DropColumn("dbo.Invoices", "CompanyID");
            DropColumn("dbo.Invoices", "ProviderID");
            CreateIndex("dbo.ProductProviders", "Provider_ProviderID");
            CreateIndex("dbo.ProductProviders", "Product_ProductID");
            CreateIndex("dbo.Quotations", "Provider_ProviderID");
            CreateIndex("dbo.Quotations", "Company_RegistrationNumber");
            CreateIndex("dbo.ProductOrders", "Quotation_NumQuotation");
            CreateIndex("dbo.PurchaseOrders", "Receipt_ReceiptID");
            CreateIndex("dbo.PurchaseOrders", "Provider_ProviderID");
            CreateIndex("dbo.PurchaseOrders", "Company_RegistrationNumber");
            CreateIndex("dbo.Receipts", "Provider_ProviderID");
            CreateIndex("dbo.Receipts", "Invoice_InvoiceID");
            CreateIndex("dbo.Receipts", "Company_RegistrationNumber");
            CreateIndex("dbo.Invoices", "Provider_ProviderID");
            CreateIndex("dbo.Invoices", "Company_RegistrationNumber");
            AddForeignKey("dbo.Quotations", "Provider_ProviderID", "dbo.Providers", "ProviderID");
            AddForeignKey("dbo.ProductOrders", "Quotation_NumQuotation", "dbo.Quotations", "NumQuotation");
            AddForeignKey("dbo.Quotations", "Company_RegistrationNumber", "dbo.Companies", "RegistrationNumber");
            AddForeignKey("dbo.PurchaseOrders", "Receipt_ReceiptID", "dbo.Receipts", "ReceiptID");
            AddForeignKey("dbo.PurchaseOrders", "Provider_ProviderID", "dbo.Providers", "ProviderID");
            AddForeignKey("dbo.PurchaseOrders", "Company_RegistrationNumber", "dbo.Companies", "RegistrationNumber");
            AddForeignKey("dbo.Receipts", "Provider_ProviderID", "dbo.Providers", "ProviderID");
            AddForeignKey("dbo.Receipts", "Invoice_InvoiceID", "dbo.Invoices", "InvoiceID");
            AddForeignKey("dbo.Receipts", "Company_RegistrationNumber", "dbo.Companies", "RegistrationNumber");
            AddForeignKey("dbo.Invoices", "Provider_ProviderID", "dbo.Providers", "ProviderID");
            AddForeignKey("dbo.ProductProviders", "Provider_ProviderID", "dbo.Providers", "ProviderID", cascadeDelete: true);
            AddForeignKey("dbo.ProductProviders", "Product_ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.Invoices", "Company_RegistrationNumber", "dbo.Companies", "RegistrationNumber");
        }
    }
}
