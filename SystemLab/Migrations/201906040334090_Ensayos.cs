namespace SystemLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ensayos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnsayoDetalles",
                c => new
                    {
                        EnsayoDetalleID = c.Int(nullable: false, identity: true),
                        EnsayoID = c.Int(nullable: false),
                        Peso = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Carga = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Falla = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.EnsayoDetalleID)
                .ForeignKey("dbo.Ensayoes", t => t.EnsayoID, cascadeDelete: true)
                .Index(t => t.EnsayoID);
            
            CreateTable(
                "dbo.Ensayoes",
                c => new
                    {
                        EnsayoID = c.Int(nullable: false, identity: true),
                        FechaRegistro = c.DateTime(nullable: false),
                        UsuarioID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EnsayoID)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioID)
                .Index(t => t.UsuarioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnsayoDetalles", "EnsayoID", "dbo.Ensayoes");
            DropForeignKey("dbo.Ensayoes", "UsuarioID", "dbo.AspNetUsers");
            DropIndex("dbo.Ensayoes", new[] { "UsuarioID" });
            DropIndex("dbo.EnsayoDetalles", new[] { "EnsayoID" });
            DropTable("dbo.Ensayoes");
            DropTable("dbo.EnsayoDetalles");
        }
    }
}
