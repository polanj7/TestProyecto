namespace SystemLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEdad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Edads", "SubRegistroID", c => c.Int(nullable: false));
            CreateIndex("dbo.Edads", "SubRegistroID");
            AddForeignKey("dbo.Edads", "SubRegistroID", "dbo.RegistroDetalles", "ID", cascadeDelete: true);
            DropColumn("dbo.Edads", "SubRegistro");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Edads", "SubRegistro", c => c.String(maxLength: 30));
            DropForeignKey("dbo.Edads", "SubRegistroID", "dbo.RegistroDetalles");
            DropIndex("dbo.Edads", new[] { "SubRegistroID" });
            DropColumn("dbo.Edads", "SubRegistroID");
        }
    }
}
