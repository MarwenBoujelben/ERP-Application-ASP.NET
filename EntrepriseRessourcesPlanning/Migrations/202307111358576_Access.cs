namespace EntrepriseRessourcesPlanning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Access : DbMigration
    {
        public string Acc { get; internal set; }
        public string AccRole { get; internal set; }

        public override void Up()
        {
            CreateTable(
                "dbo.Accesses",
                c => new
                    {
                        AccessId = c.Int(nullable: false, identity: true),
                        Acc_Role = c.String(),
                    })
                .PrimaryKey(t => t.AccessId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Accesses");
        }
    }
}
