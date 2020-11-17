namespace SystemLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFeildFechaUltimoEmailAndConteo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registroes", "FechaUltimoEmail", c => c.String());
            AddColumn("dbo.Registroes", "CantidadEmailEnviados", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registroes", "CantidadEmailEnviados");
            DropColumn("dbo.Registroes", "FechaUltimoEmail");
        }
    }
}
