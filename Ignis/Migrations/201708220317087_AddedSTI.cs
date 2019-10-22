namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSTI : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.VehicleDamages", newName: "Damages");
            DropIndex("dbo.Damages", new[] { "VehicleId" });
            DropIndex("dbo.Damages", new[] { "VehicleDamageTypeId" });
            AddColumn("dbo.Damages", "VehicleEquipmentId", c => c.Guid());
            AddColumn("dbo.Damages", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Damages", "VehicleId", c => c.Guid());
            AlterColumn("dbo.Damages", "VehicleDamageTypeId", c => c.Guid());
            CreateIndex("dbo.Damages", "VehicleId");
            CreateIndex("dbo.Damages", "VehicleDamageTypeId");
            CreateIndex("dbo.Damages", "VehicleEquipmentId");
            AddForeignKey("dbo.Damages", "VehicleEquipmentId", "dbo.VehicleEquipments", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Damages", "VehicleEquipmentId", "dbo.VehicleEquipments");
            DropIndex("dbo.Damages", new[] { "VehicleEquipmentId" });
            DropIndex("dbo.Damages", new[] { "VehicleDamageTypeId" });
            DropIndex("dbo.Damages", new[] { "VehicleId" });
            AlterColumn("dbo.Damages", "VehicleDamageTypeId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Damages", "VehicleId", c => c.Guid(nullable: false));
            DropColumn("dbo.Damages", "Discriminator");
            DropColumn("dbo.Damages", "VehicleEquipmentId");
            CreateIndex("dbo.Damages", "VehicleDamageTypeId");
            CreateIndex("dbo.Damages", "VehicleId");
            RenameTable(name: "dbo.Damages", newName: "VehicleDamages");
        }
    }
}
