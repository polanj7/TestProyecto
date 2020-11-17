namespace SystemLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableRegistroAndDetalle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registroes", "Contacto", c => c.String());
            AddColumn("dbo.Registroes", "Elaboracion", c => c.String());
            DropColumn("dbo.RegistroDetalles", "Elaboracion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegistroDetalles", "Elaboracion", c => c.String());
            DropColumn("dbo.Registroes", "Elaboracion");
            DropColumn("dbo.Registroes", "Contacto");
        }
    }
}
