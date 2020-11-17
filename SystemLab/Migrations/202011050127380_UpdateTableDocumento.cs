namespace SystemLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableDocumento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documentos", "Nombre", c => c.String());
            AddColumn("dbo.Documentos", "Ext", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documentos", "Ext");
            DropColumn("dbo.Documentos", "Nombre");
        }
    }
}
