namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOilChanges2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OilChanges",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OdometerReading = c.Double(nullable: false),
                        RoadRunKilometer = c.Double(nullable: false),
                        PumpRunKilometer = c.Double(nullable: false),
                        DateOfChange = c.DateTime(nullable: false),
                        OilTypeId = c.Guid(nullable: false),
                        VehicleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OilTypes", t => t.OilTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.OilTypeId)
                .Index(t => t.VehicleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OilChanges", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.OilChanges", "OilTypeId", "dbo.OilTypes");
            DropIndex("dbo.OilChanges", new[] { "VehicleId" });
            DropIndex("dbo.OilChanges", new[] { "OilTypeId" });
            DropTable("dbo.OilChanges");
        }
    }
}
