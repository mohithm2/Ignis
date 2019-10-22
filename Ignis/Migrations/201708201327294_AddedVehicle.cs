namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVehicle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Make = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        RegistrationNumber = c.String(nullable: false),
                        Cost = c.Double(nullable: false),
                        DateOfPurchase = c.DateTime(nullable: false),
                        EngineNumber = c.String(nullable: false),
                        CapacityFuelTank = c.Double(nullable: false),
                        TaxCard = c.String(nullable: false),
                        SanctionOrderNumber = c.String(nullable: false),
                        SanctionDate = c.DateTime(nullable: false),
                        TheoreticalMileage = c.Double(nullable: false),
                        KilometersCovered = c.Double(nullable: false),
                        Usage = c.String(nullable: false),
                        CapacityOfAttachement = c.Double(nullable: false),
                        FireStationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FireStations", t => t.FireStationId, cascadeDelete: true)
                .Index(t => t.FireStationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "FireStationId", "dbo.FireStations");
            DropIndex("dbo.Vehicles", new[] { "FireStationId" });
            DropTable("dbo.Vehicles");
        }
    }
}
