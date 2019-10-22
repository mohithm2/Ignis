namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EvenMoreSTI : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.VehicleDamageTypes", newName: "DamageTypes");
            AddColumn("dbo.Damages", "VehicleEquipmentDamageTypeId", c => c.Guid());
            AddColumn("dbo.DamageTypes", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Damages", "VehicleEquipmentDamageTypeId");
            AddForeignKey("dbo.Damages", "VehicleEquipmentDamageTypeId", "dbo.DamageTypes", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Damages", "VehicleEquipmentDamageTypeId", "dbo.DamageTypes");
            DropIndex("dbo.Damages", new[] { "VehicleEquipmentDamageTypeId" });
            DropColumn("dbo.DamageTypes", "Discriminator");
            DropColumn("dbo.Damages", "VehicleEquipmentDamageTypeId");
            RenameTable(name: "dbo.DamageTypes", newName: "VehicleDamageTypes");
        }
    }
}
