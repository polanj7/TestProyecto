namespace SystemLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEnsayo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ensayoes", "EdadID", c => c.Int(nullable: false));
            CreateIndex("dbo.Ensayoes", "EdadID");
            AddForeignKey("dbo.Ensayoes", "EdadID", "dbo.Edads", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ensayoes", "EdadID", "dbo.Edads");
            DropIndex("dbo.Ensayoes", new[] { "EdadID" });
            DropColumn("dbo.Ensayoes", "EdadID");
        }
    }
}
