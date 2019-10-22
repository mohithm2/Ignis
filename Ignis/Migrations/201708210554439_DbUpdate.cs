namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "FireStationId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Employees", "FireStationId");
            AddForeignKey("dbo.Employees", "FireStationId", "dbo.FireStations", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "FireStationId", "dbo.FireStations");
            DropIndex("dbo.Employees", new[] { "FireStationId" });
            DropColumn("dbo.Employees", "FireStationId");
        }
    }
}
