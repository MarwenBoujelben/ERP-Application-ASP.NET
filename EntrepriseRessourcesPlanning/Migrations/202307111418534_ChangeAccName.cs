namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAccName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessClasses",
                c => new
                    {
                        AccessId = c.Int(nullable: false, identity: true),
                        Acc_Role = c.String(),
                    })
                .PrimaryKey(t => t.AccessId);
            
            DropTable("dbo.Accesses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Accesses",
                c => new
                    {
                        AccessId = c.Int(nullable: false, identity: true),
                        AccRole = c.String(),
                    })
                .PrimaryKey(t => t.AccessId);
            
            DropTable("dbo.AccessClasses");
        }
    }
}
