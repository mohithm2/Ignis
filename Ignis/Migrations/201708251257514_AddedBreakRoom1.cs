namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBreakRoom1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Damages", "BreakRoomId", c => c.Guid());
            AddColumn("dbo.Damages", "BreakRoomDamageTypeId", c => c.Guid());
            AddColumn("dbo.DamageStatus", "BreakRoomDamageId", c => c.Guid());
            AddColumn("dbo.Repairs", "BreakRoomDamageId", c => c.Guid());
            CreateIndex("dbo.Damages", "BreakRoomId");
            CreateIndex("dbo.Damages", "BreakRoomDamageTypeId");
            CreateIndex("dbo.DamageStatus", "BreakRoomDamageId");
            CreateIndex("dbo.Repairs", "BreakRoomDamageId");
            AddForeignKey("dbo.Damages", "BreakRoomId", "dbo.BreakRooms", "Id", cascadeDelete: false);
            AddForeignKey("dbo.DamageStatus", "BreakRoomDamageId", "dbo.Damages", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Damages", "BreakRoomDamageTypeId", "dbo.DamageTypes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Repairs", "BreakRoomDamageId", "dbo.Damages", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Repairs", "BreakRoomDamageId", "dbo.Damages");
            DropForeignKey("dbo.Damages", "BreakRoomDamageTypeId", "dbo.DamageTypes");
            DropForeignKey("dbo.DamageStatus", "BreakRoomDamageId", "dbo.Damages");
            DropForeignKey("dbo.Damages", "BreakRoomId", "dbo.BreakRooms");
            DropIndex("dbo.Repairs", new[] { "BreakRoomDamageId" });
            DropIndex("dbo.DamageStatus", new[] { "BreakRoomDamageId" });
            DropIndex("dbo.Damages", new[] { "BreakRoomDamageTypeId" });
            DropIndex("dbo.Damages", new[] { "BreakRoomId" });
            DropColumn("dbo.Repairs", "BreakRoomDamageId");
            DropColumn("dbo.DamageStatus", "BreakRoomDamageId");
            DropColumn("dbo.Damages", "BreakRoomDamageTypeId");
            DropColumn("dbo.Damages", "BreakRoomId");
        }
    }
}
