namespace SystemLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteConcreteraAddConcretera : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegistroDetalles", "Hormigonera", c => c.String(maxLength: 50));
            DropColumn("dbo.Registroes", "Hormigonera");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Registroes", "Hormigonera", c => c.String(maxLength: 50));
            DropColumn("dbo.RegistroDetalles", "Hormigonera");
        }
    }
}
