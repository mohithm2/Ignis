namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoreSTI : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.VehicleDamageStatus", newName: "DamageStatus");
            RenameTable(name: "dbo.VehicleRepairs", newName: "Repairs");
            DropForeignKey("dbo.VehicleRepairs", "Id", "dbo.Damages");
            DropIndex("dbo.DamageStatus", new[] { "VehicleDamageId" });
            DropIndex("dbo.Repairs", new[] { "Id" });
            AddColumn("dbo.DamageStatus", "VehicleEquipmentDamageId", c => c.Guid());
            AddColumn("dbo.DamageStatus", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Repairs", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Repairs", "VehicleDamage_Id", c => c.Guid());
            AddColumn("dbo.Repairs", "VehicleEquipmentDamage_Id", c => c.Guid());
            AlterColumn("dbo.DamageStatus", "VehicleDamageId", c => c.Guid());
            CreateIndex("dbo.DamageStatus", "VehicleDamageId");
            CreateIndex("dbo.DamageStatus", "VehicleEquipmentDamageId");
            CreateIndex("dbo.Repairs", "VehicleDamage_Id");
            CreateIndex("dbo.Repairs", "VehicleEquipmentDamage_Id");
            AddForeignKey("dbo.DamageStatus", "VehicleEquipmentDamageId", "dbo.Damages", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Repairs", "VehicleEquipmentDamage_Id", "dbo.Damages", "Id");
            AddForeignKey("dbo.Repairs", "VehicleDamage_Id", "dbo.Damages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Repairs", "VehicleDamage_Id", "dbo.Damages");
            DropForeignKey("dbo.Repairs", "VehicleEquipmentDamage_Id", "dbo.Damages");
            DropForeignKey("dbo.DamageStatus", "VehicleEquipmentDamageId", "dbo.Damages");
            DropIndex("dbo.Repairs", new[] { "VehicleEquipmentDamage_Id" });
            DropIndex("dbo.Repairs", new[] { "VehicleDamage_Id" });
            DropIndex("dbo.DamageStatus", new[] { "VehicleEquipmentDamageId" });
            DropIndex("dbo.DamageStatus", new[] { "VehicleDamageId" });
            AlterColumn("dbo.DamageStatus", "VehicleDamageId", c => c.Guid(nullable: false));
            DropColumn("dbo.Repairs", "VehicleEquipmentDamage_Id");
            DropColumn("dbo.Repairs", "VehicleDamage_Id");
            DropColumn("dbo.Repairs", "Discriminator");
            DropColumn("dbo.DamageStatus", "Discriminator");
            DropColumn("dbo.DamageStatus", "VehicleEquipmentDamageId");
            CreateIndex("dbo.Repairs", "Id");
            CreateIndex("dbo.DamageStatus", "VehicleDamageId");
            AddForeignKey("dbo.VehicleRepairs", "Id", "dbo.Damages", "Id");
            RenameTable(name: "dbo.Repairs", newName: "VehicleRepairs");
            RenameTable(name: "dbo.DamageStatus", newName: "VehicleDamageStatus");
        }
    }
}
