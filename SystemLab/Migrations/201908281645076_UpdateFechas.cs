namespace SystemLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFechas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegistroDetalles", "FechaEntrega", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RegistroDetalles", "FechaVaciado", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegistroDetalles", "FechaVaciado", c => c.DateTime());
            AlterColumn("dbo.RegistroDetalles", "FechaEntrega", c => c.DateTime());
        }
    }
}
