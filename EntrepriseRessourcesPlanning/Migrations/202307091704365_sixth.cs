namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Number", c => c.Int(nullable: false));
        }
    }
}
