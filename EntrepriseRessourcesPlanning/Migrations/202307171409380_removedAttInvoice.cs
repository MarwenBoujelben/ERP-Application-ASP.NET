namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedAttInvoice : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Invoices", "AdrCompany");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "AdrCompany", c => c.String());
        }
    }
}
