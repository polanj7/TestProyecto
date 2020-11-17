namespace SystemLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sda : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Clients", newName: "Clientes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Clientes", newName: "Clients");
        }
    }
}
