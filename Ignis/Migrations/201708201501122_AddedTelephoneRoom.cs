namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTelephoneRoom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TelephoneRooms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        FireStationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FireStations", t => t.FireStationId, cascadeDelete: true)
                .Index(t => t.FireStationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TelephoneRooms", "FireStationId", "dbo.FireStations");
            DropIndex("dbo.TelephoneRooms", new[] { "FireStationId" });
            DropTable("dbo.TelephoneRooms");
        }
    }
}
