namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seventh : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Img");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Img", c => c.Binary());
        }
    }
}
