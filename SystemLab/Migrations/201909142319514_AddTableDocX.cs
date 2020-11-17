namespace SystemLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableDocX : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documentos",
                c => new
                    {
                        DocumentosID = c.Int(nullable: false, identity: true),
                        ProyectoID = c.Int(nullable: false),
                        DocXHash = c.Binary(),
                        PathDocX = c.String(),
                    })
                .PrimaryKey(t => t.DocumentosID)
                .ForeignKey("dbo.Registroes", t => t.ProyectoID, cascadeDelete: true)
                .Index(t => t.ProyectoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documentos", "ProyectoID", "dbo.Registroes");
            DropIndex("dbo.Documentos", new[] { "ProyectoID" });
            DropTable("dbo.Documentos");
        }
    }
}
