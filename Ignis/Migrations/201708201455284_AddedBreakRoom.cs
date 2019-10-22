namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBreakRoom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BreakRooms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        FireStationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FireStations", t => t.FireStationId, cascadeDelete: true)
                .Index(t => t.FireStationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BreakRooms", "FireStationId", "dbo.FireStations");
            DropIndex("dbo.BreakRooms", new[] { "FireStationId" });
            DropTable("dbo.BreakRooms");
        }
    }
}
