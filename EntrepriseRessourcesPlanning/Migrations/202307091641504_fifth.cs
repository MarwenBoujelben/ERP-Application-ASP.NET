namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Number", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Category", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Category", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "Number");
        }
    }
}
