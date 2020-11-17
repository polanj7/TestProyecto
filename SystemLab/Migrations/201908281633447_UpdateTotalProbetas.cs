namespace SystemLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTotalProbetas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegistroDetalles", "TotalProbetas", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Edads", "TotalProbetas");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Edads", "TotalProbetas", c => c.Int(nullable: false));
            DropColumn("dbo.RegistroDetalles", "TotalProbetas");
        }
    }
}
