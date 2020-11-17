namespace SystemLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Responsables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Responsables",
                c => new
                    {
                        ResponsablesID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ResponsablesID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Responsables");
        }
    }
}
