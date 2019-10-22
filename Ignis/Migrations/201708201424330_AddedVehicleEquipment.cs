namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVehicleEquipment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleEquipments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateofPurchase = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        VehicleId = c.Guid(nullable: false),
                        VehicleEquipmentTypeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleEquipmentTypes", t => t.VehicleEquipmentTypeId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.VehicleEquipmentTypeId);
            
            CreateTable(
                "dbo.VehicleEquipmentTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Make = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        YearOfManufacture = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                        IsFuelRequired = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleEquipments", "VehicleEquipmentTypeId", "dbo.VehicleEquipmentTypes");
            DropForeignKey("dbo.VehicleEquipments", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.VehicleEquipments", new[] { "VehicleEquipmentTypeId" });
            DropIndex("dbo.VehicleEquipments", new[] { "VehicleId" });
            DropTable("dbo.VehicleEquipmentTypes");
            DropTable("dbo.VehicleEquipments");
        }
    }
}
