namespace SystemLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SysOptiona : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SysOptions",
                c => new
                    {
                        SysOptionsID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Key = c.String(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.SysOptionsID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SysOptions");
        }
    }
}
