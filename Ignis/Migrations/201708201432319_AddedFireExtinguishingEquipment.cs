namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFireExtinguishingEquipment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FireExtinguishingEquipments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateofPurchase = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        FireExtinguishingEquipmentTypeId = c.Guid(nullable: false),
                        FireStationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FireExtinguishingEquipmentTypes", t => t.FireExtinguishingEquipmentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.FireStations", t => t.FireStationId, cascadeDelete: true)
                .Index(t => t.FireExtinguishingEquipmentTypeId)
                .Index(t => t.FireStationId);
            
            CreateTable(
                "dbo.FireExtinguishingEquipmentTypes",
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
            DropForeignKey("dbo.FireExtinguishingEquipments", "FireStationId", "dbo.FireStations");
            DropForeignKey("dbo.FireExtinguishingEquipments", "FireExtinguishingEquipmentTypeId", "dbo.FireExtinguishingEquipmentTypes");
            DropIndex("dbo.FireExtinguishingEquipments", new[] { "FireStationId" });
            DropIndex("dbo.FireExtinguishingEquipments", new[] { "FireExtinguishingEquipmentTypeId" });
            DropTable("dbo.FireExtinguishingEquipmentTypes");
            DropTable("dbo.FireExtinguishingEquipments");
        }
    }
}
