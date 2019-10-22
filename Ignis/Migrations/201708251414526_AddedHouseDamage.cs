namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHouseDamage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Damages", "HouseId", c => c.Guid());
            AddColumn("dbo.Damages", "HouseDamageTypeId", c => c.Guid());
            AddColumn("dbo.DamageStatus", "HouseDamageId", c => c.Guid());
            AddColumn("dbo.Repairs", "HouseDamageId", c => c.Guid());
            CreateIndex("dbo.Damages", "HouseId");
            CreateIndex("dbo.Damages", "HouseDamageTypeId");
            CreateIndex("dbo.DamageStatus", "HouseDamageId");
            CreateIndex("dbo.Repairs", "HouseDamageId");
            AddForeignKey("dbo.Damages", "HouseId", "dbo.Houses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.DamageStatus", "HouseDamageId", "dbo.Damages", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Damages", "HouseDamageTypeId", "dbo.DamageTypes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Repairs", "HouseDamageId", "dbo.Damages", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Repairs", "HouseDamageId", "dbo.Damages");
            DropForeignKey("dbo.Damages", "HouseDamageTypeId", "dbo.DamageTypes");
            DropForeignKey("dbo.DamageStatus", "HouseDamageId", "dbo.Damages");
            DropForeignKey("dbo.Damages", "HouseId", "dbo.Houses");
            DropIndex("dbo.Repairs", new[] { "HouseDamageId" });
            DropIndex("dbo.DamageStatus", new[] { "HouseDamageId" });
            DropIndex("dbo.Damages", new[] { "HouseDamageTypeId" });
            DropIndex("dbo.Damages", new[] { "HouseId" });
            DropColumn("dbo.Repairs", "HouseDamageId");
            DropColumn("dbo.DamageStatus", "HouseDamageId");
            DropColumn("dbo.Damages", "HouseDamageTypeId");
            DropColumn("dbo.Damages", "HouseId");
        }
    }
}
