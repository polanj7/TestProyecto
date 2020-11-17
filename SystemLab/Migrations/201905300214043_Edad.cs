namespace SystemLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Edads",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubRegistro = c.String(maxLength: 30),
                        Dias = c.Int(nullable: false),
                        TotalProbetas = c.Int(nullable: false),
                        CantidadProbetas = c.Int(nullable: false),
                        Dimension = c.String(maxLength: 30),
                        Conduce = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Edads");
        }
    }
}
