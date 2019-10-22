namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBatteryChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BatteryChanges",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OdometerReading = c.Double(nullable: false),
                        RoadRunKilometer = c.Double(nullable: false),
                        PumpRunKilometer = c.Double(nullable: false),
                        VehicleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BatteryChanges", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.BatteryChanges", new[] { "VehicleId" });
            DropTable("dbo.BatteryChanges");
        }
    }
}
