namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDiscAttProd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "DiscountPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "DiscountPrice");
        }
    }
}
