namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedAttReceipt : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Receipts", "AdrCompany");
            DropColumn("dbo.Receipts", "IsReceived");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Receipts", "IsReceived", c => c.Boolean(nullable: false));
            AddColumn("dbo.Receipts", "AdrCompany", c => c.String());
        }
    }
}
