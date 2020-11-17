namespace SystemLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Registro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Registroes",
                c => new
                    {
                        RegistroID = c.Int(nullable: false, identity: true),
                        ClientID = c.Int(nullable: false),
                        NoRegistro = c.String(maxLength: 40),
                        Proyecto = c.String(maxLength: 50),
                        Volumen = c.String(maxLength: 15),
                        Hormigonera = c.String(maxLength: 50),
                        Direccion = c.String(),
                    })
                .PrimaryKey(t => t.RegistroID)
                .ForeignKey("dbo.Clientes", t => t.ClientID, cascadeDelete: true)
                .Index(t => t.ClientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registroes", "ClientID", "dbo.Clientes");
            DropIndex("dbo.Registroes", new[] { "ClientID" });
            DropTable("dbo.Registroes");
        }
    }
}
