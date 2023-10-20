namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedProdOrderFromCompany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductOrders", "Company_RegistrationNumber", "dbo.Companies");
            DropIndex("dbo.ProductOrders", new[] { "Company_RegistrationNumber" });
            DropColumn("dbo.ProductOrders", "Company_RegistrationNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductOrders", "Company_RegistrationNumber", c => c.Int());
            CreateIndex("dbo.ProductOrders", "Company_RegistrationNumber");
            AddForeignKey("dbo.ProductOrders", "Company_RegistrationNumber", "dbo.Companies", "RegistrationNumber");
        }
    }
}
