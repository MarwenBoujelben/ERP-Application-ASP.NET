namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        RegistrationNumber = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Description = c.String(),
                        ContactEmail = c.String(),
                        TurnOver = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RegistrationNumber);
            
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        UnitPriceHT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        TotalPriceHT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TVA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalTTC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Company_RegistrationNumber = c.Int(),
                        Quotation_NumQuotation = c.Int(),
                        PurchaseOrder_OrderNum = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.Company_RegistrationNumber)
                .ForeignKey("dbo.Quotations", t => t.Quotation_NumQuotation)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrder_OrderNum)
                .Index(t => t.Company_RegistrationNumber)
                .Index(t => t.Quotation_NumQuotation)
                .Index(t => t.PurchaseOrder_OrderNum);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Stock = c.Int(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                        Category = c.Int(nullable: false),
                        Company_RegistrationNumber = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Companies", t => t.Company_RegistrationNumber)
                .Index(t => t.Company_RegistrationNumber);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        ProviderID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        ContactEmail = c.String(),
                    })
                .PrimaryKey(t => t.ProviderID);
            
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
                .PrimaryKey(t => t.NumQuotation)
                .ForeignKey("dbo.Companies", t => t.Company_RegistrationNumber)
                .ForeignKey("dbo.Providers", t => t.Provider_ProviderID)
                .Index(t => t.Company_RegistrationNumber)
                .Index(t => t.Provider_ProviderID);
            
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        ReceiptID = c.Int(nullable: false, identity: true),
                        ReceptionDate = c.DateTime(nullable: false),
                        AdrCompany = c.String(),
                        IsReceived = c.Boolean(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Company_RegistrationNumber = c.Int(),
                        Provider_ProviderID = c.Int(),
                    })
                .PrimaryKey(t => t.ReceiptID)
                .ForeignKey("dbo.Companies", t => t.Company_RegistrationNumber)
                .ForeignKey("dbo.Providers", t => t.Provider_ProviderID)
                .Index(t => t.Company_RegistrationNumber)
                .Index(t => t.Provider_ProviderID);
            
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        OrderNum = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        AdrProvider = c.String(),
                        AdrCompany = c.String(),
                        PaymentMethod = c.String(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Company_RegistrationNumber = c.Int(),
                        Invoice_InvoiceID = c.Int(),
                        Provider_ProviderID = c.Int(),
                        Receipt_ReceiptID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderNum)
                .ForeignKey("dbo.Companies", t => t.Company_RegistrationNumber)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceID)
                .ForeignKey("dbo.Providers", t => t.Provider_ProviderID)
                .ForeignKey("dbo.Receipts", t => t.Receipt_ReceiptID)
                .Index(t => t.Company_RegistrationNumber)
                .Index(t => t.Invoice_InvoiceID)
                .Index(t => t.Provider_ProviderID)
                .Index(t => t.Receipt_ReceiptID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        InvoiceDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        PaymentMethod = c.String(),
                        AdrCompany = c.String(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Company_RegistrationNumber = c.Int(),
                        Provider_ProviderID = c.Int(),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.Companies", t => t.Company_RegistrationNumber)
                .ForeignKey("dbo.Providers", t => t.Provider_ProviderID)
                .Index(t => t.Company_RegistrationNumber)
                .Index(t => t.Provider_ProviderID);
            
            CreateTable(
                "dbo.ProviderProducts",
                c => new
                    {
                        Provider_ProviderID = c.Int(nullable: false),
                        Product_ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Provider_ProviderID, t.Product_ProductID })
                .ForeignKey("dbo.Providers", t => t.Provider_ProviderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductID, cascadeDelete: true)
                .Index(t => t.Provider_ProviderID)
                .Index(t => t.Product_ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseOrders", "Receipt_ReceiptID", "dbo.Receipts");
            DropForeignKey("dbo.PurchaseOrders", "Provider_ProviderID", "dbo.Providers");
            DropForeignKey("dbo.ProductOrders", "PurchaseOrder_OrderNum", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrders", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "Provider_ProviderID", "dbo.Providers");
            DropForeignKey("dbo.Invoices", "Company_RegistrationNumber", "dbo.Companies");
            DropForeignKey("dbo.PurchaseOrders", "Company_RegistrationNumber", "dbo.Companies");
            DropForeignKey("dbo.Receipts", "Provider_ProviderID", "dbo.Providers");
            DropForeignKey("dbo.Receipts", "Company_RegistrationNumber", "dbo.Companies");
            DropForeignKey("dbo.Quotations", "Provider_ProviderID", "dbo.Providers");
            DropForeignKey("dbo.ProductOrders", "Quotation_NumQuotation", "dbo.Quotations");
            DropForeignKey("dbo.Quotations", "Company_RegistrationNumber", "dbo.Companies");
            DropForeignKey("dbo.ProviderProducts", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.ProviderProducts", "Provider_ProviderID", "dbo.Providers");
            DropForeignKey("dbo.Products", "Company_RegistrationNumber", "dbo.Companies");
            DropForeignKey("dbo.ProductOrders", "Company_RegistrationNumber", "dbo.Companies");
            DropIndex("dbo.ProviderProducts", new[] { "Product_ProductID" });
            DropIndex("dbo.ProviderProducts", new[] { "Provider_ProviderID" });
            DropIndex("dbo.Invoices", new[] { "Provider_ProviderID" });
            DropIndex("dbo.Invoices", new[] { "Company_RegistrationNumber" });
            DropIndex("dbo.PurchaseOrders", new[] { "Receipt_ReceiptID" });
            DropIndex("dbo.PurchaseOrders", new[] { "Provider_ProviderID" });
            DropIndex("dbo.PurchaseOrders", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.PurchaseOrders", new[] { "Company_RegistrationNumber" });
            DropIndex("dbo.Receipts", new[] { "Provider_ProviderID" });
            DropIndex("dbo.Receipts", new[] { "Company_RegistrationNumber" });
            DropIndex("dbo.Quotations", new[] { "Provider_ProviderID" });
            DropIndex("dbo.Quotations", new[] { "Company_RegistrationNumber" });
            DropIndex("dbo.Products", new[] { "Company_RegistrationNumber" });
            DropIndex("dbo.ProductOrders", new[] { "PurchaseOrder_OrderNum" });
            DropIndex("dbo.ProductOrders", new[] { "Quotation_NumQuotation" });
            DropIndex("dbo.ProductOrders", new[] { "Company_RegistrationNumber" });
            DropTable("dbo.ProviderProducts");
            DropTable("dbo.Invoices");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.Receipts");
            DropTable("dbo.Quotations");
            DropTable("dbo.Providers");
            DropTable("dbo.Products");
            DropTable("dbo.ProductOrders");
            DropTable("dbo.Companies");
        }
    }
}
