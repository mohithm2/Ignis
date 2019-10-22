namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoreSTL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Damages", "FireExtinguishingEquipmentId", c => c.Guid());
            AddColumn("dbo.Damages", "FireExtinguishingEquipmentDamageTypeId", c => c.Guid());
            AddColumn("dbo.DamageStatus", "FireExtinguishingEquipmentDamageId", c => c.Guid());
            AddColumn("dbo.Repairs", "FireExtinguishingEquipmentDamageId", c => c.Guid());
            CreateIndex("dbo.Damages", "FireExtinguishingEquipmentId");
            CreateIndex("dbo.Damages", "FireExtinguishingEquipmentDamageTypeId");
            CreateIndex("dbo.Repairs", "FireExtinguishingEquipmentDamageId");
            CreateIndex("dbo.DamageStatus", "FireExtinguishingEquipmentDamageId");
            AddForeignKey("dbo.Damages", "FireExtinguishingEquipmentId", "dbo.FireExtinguishingEquipments", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Damages", "FireExtinguishingEquipmentDamageTypeId", "dbo.DamageTypes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Repairs", "FireExtinguishingEquipmentDamageId", "dbo.Damages", "Id", cascadeDelete: false);
            AddForeignKey("dbo.DamageStatus", "FireExtinguishingEquipmentDamageId", "dbo.Damages", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DamageStatus", "FireExtinguishingEquipmentDamageId", "dbo.Damages");
            DropForeignKey("dbo.Repairs", "FireExtinguishingEquipmentDamageId", "dbo.Damages");
            DropForeignKey("dbo.Damages", "FireExtinguishingEquipmentDamageTypeId", "dbo.DamageTypes");
            DropForeignKey("dbo.Damages", "FireExtinguishingEquipmentId", "dbo.FireExtinguishingEquipments");
            DropIndex("dbo.DamageStatus", new[] { "FireExtinguishingEquipmentDamageId" });
            DropIndex("dbo.Repairs", new[] { "FireExtinguishingEquipmentDamageId" });
            DropIndex("dbo.Damages", new[] { "FireExtinguishingEquipmentDamageTypeId" });
            DropIndex("dbo.Damages", new[] { "FireExtinguishingEquipmentId" });
            DropColumn("dbo.Repairs", "FireExtinguishingEquipmentDamageId");
            DropColumn("dbo.DamageStatus", "FireExtinguishingEquipmentDamageId");
            DropColumn("dbo.Damages", "FireExtinguishingEquipmentDamageTypeId");
            DropColumn("dbo.Damages", "FireExtinguishingEquipmentId");
        }
    }
}
