namespace SystemLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegistroDetalle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegistroDetalles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegistroID = c.Int(nullable: false),
                        SubRegistro = c.String(),
                        HoraInicial = c.String(),
                        HoraFinal = c.String(),
                        Resistencia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Slump = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Temp = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Elemento = c.String(),
                        Sector = c.String(),
                        Elaboracion = c.String(),
                        Curado = c.String(),
                        Agregado = c.String(),
                        FechaEntrega = c.DateTime(),
                        FechaVaciado = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Registroes", t => t.RegistroID, cascadeDelete: true)
                .Index(t => t.RegistroID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegistroDetalles", "RegistroID", "dbo.Registroes");
            DropIndex("dbo.RegistroDetalles", new[] { "RegistroID" });
            DropTable("dbo.RegistroDetalles");
        }
    }
}
