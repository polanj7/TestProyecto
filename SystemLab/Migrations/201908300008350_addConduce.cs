namespace SystemLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addConduce : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegistroDetalles", "Conduce", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegistroDetalles", "Conduce");
        }
    }
}
