namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVehicleDamage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleDamages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateNoticed = c.DateTime(nullable: false),
                        OdometerReading = c.Double(nullable: false),
                        Report = c.String(nullable: false),
                        CostEstimate = c.Double(nullable: false),
                        VehicleId = c.Guid(nullable: false),
                        VehicleDamageTypeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleDamageTypes", t => t.VehicleDamageTypeId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.VehicleDamageTypeId);
            
            CreateTable(
                "dbo.VehicleDamageTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(nullable: false),
                        IsMajor = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleDamages", "VehicleDamageTypeId", "dbo.VehicleDamageTypes");
            DropForeignKey("dbo.VehicleDamages", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.VehicleDamages", new[] { "VehicleDamageTypeId" });
            DropIndex("dbo.VehicleDamages", new[] { "VehicleId" });
            DropTable("dbo.VehicleDamageTypes");
            DropTable("dbo.VehicleDamages");
        }
    }
}
