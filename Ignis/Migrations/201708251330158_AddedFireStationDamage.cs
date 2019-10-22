namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFireStationDamage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Damages", "FireStationId", c => c.Guid());
            AddColumn("dbo.Damages", "FireStationDamageTypeId", c => c.Guid());
            AddColumn("dbo.DamageStatus", "FireStationDamageId", c => c.Guid());
            AddColumn("dbo.Repairs", "FireStationDamageId", c => c.Guid());
            CreateIndex("dbo.Damages", "FireStationId");
            CreateIndex("dbo.Damages", "FireStationDamageTypeId");
            CreateIndex("dbo.DamageStatus", "FireStationDamageId");
            CreateIndex("dbo.Repairs", "FireStationDamageId");
            AddForeignKey("dbo.Damages", "FireStationId", "dbo.FireStations", "Id", cascadeDelete: false);
            AddForeignKey("dbo.DamageStatus", "FireStationDamageId", "dbo.Damages", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Damages", "FireStationDamageTypeId", "dbo.DamageTypes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Repairs", "FireStationDamageId", "dbo.Damages", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Repairs", "FireStationDamageId", "dbo.Damages");
            DropForeignKey("dbo.Damages", "FireStationDamageTypeId", "dbo.DamageTypes");
            DropForeignKey("dbo.DamageStatus", "FireStationDamageId", "dbo.Damages");
            DropForeignKey("dbo.Damages", "FireStationId", "dbo.FireStations");
            DropIndex("dbo.Repairs", new[] { "FireStationDamageId" });
            DropIndex("dbo.DamageStatus", new[] { "FireStationDamageId" });
            DropIndex("dbo.Damages", new[] { "FireStationDamageTypeId" });
            DropIndex("dbo.Damages", new[] { "FireStationId" });
            DropColumn("dbo.Repairs", "FireStationDamageId");
            DropColumn("dbo.DamageStatus", "FireStationDamageId");
            DropColumn("dbo.Damages", "FireStationDamageTypeId");
            DropColumn("dbo.Damages", "FireStationId");
        }
    }
}
