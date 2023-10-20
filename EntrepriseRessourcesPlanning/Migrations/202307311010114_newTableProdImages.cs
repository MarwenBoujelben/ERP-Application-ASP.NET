namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newTableProdImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProdImages",
                c => new
                    {
                        ProdID = c.Int(nullable: false, identity: true),
                        ProdImg = c.Binary(),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdID);
            
            AddColumn("dbo.Products", "NumImages", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "NumImages");
            DropTable("dbo.ProdImages");
        }
    }
}
