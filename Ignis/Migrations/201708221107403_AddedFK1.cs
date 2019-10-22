namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFK1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Repairs", "VehicleEquipmentDamage_Id", "dbo.Damages");
            RenameColumn(table: "dbo.Repairs", name: "VehicleEquipmentDamage_Id", newName: "VehicleEquipmentDamageId");
            RenameIndex(table: "dbo.Repairs", name: "IX_VehicleEquipmentDamage_Id", newName: "IX_VehicleEquipmentDamageId");
            AddForeignKey("dbo.Repairs", "VehicleEquipmentDamageId", "dbo.Damages", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Repairs", "VehicleEquipmentDamageId", "dbo.Damages");
            RenameIndex(table: "dbo.Repairs", name: "IX_VehicleEquipmentDamageId", newName: "IX_VehicleEquipmentDamage_Id");
            RenameColumn(table: "dbo.Repairs", name: "VehicleEquipmentDamageId", newName: "VehicleEquipmentDamage_Id");
            AddForeignKey("dbo.Repairs", "VehicleEquipmentDamage_Id", "dbo.Damages", "Id");
        }
    }
}
