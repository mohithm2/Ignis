namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClassRoomDamage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Damages", "ClassRoomId", c => c.Guid());
            AddColumn("dbo.Damages", "ClassRoomDamageTypeId", c => c.Guid());
            AddColumn("dbo.Repairs", "ClassRoomDamageId", c => c.Guid());
            AddColumn("dbo.DamageStatus", "ClassRoomDamageId", c => c.Guid());
            CreateIndex("dbo.Damages", "ClassRoomId");
            CreateIndex("dbo.Damages", "ClassRoomDamageTypeId");
            CreateIndex("dbo.Repairs", "ClassRoomDamageId");
            CreateIndex("dbo.DamageStatus", "ClassRoomDamageId");
            AddForeignKey("dbo.Damages", "ClassRoomId", "dbo.ClassRooms", "Id", cascadeDelete: false);
            AddForeignKey("dbo.DamageStatus", "ClassRoomDamageId", "dbo.Damages", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Damages", "ClassRoomDamageTypeId", "dbo.DamageTypes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Repairs", "ClassRoomDamageId", "dbo.Damages", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Repairs", "ClassRoomDamageId", "dbo.Damages");
            DropForeignKey("dbo.Damages", "ClassRoomDamageTypeId", "dbo.DamageTypes");
            DropForeignKey("dbo.DamageStatus", "ClassRoomDamageId", "dbo.Damages");
            DropForeignKey("dbo.Damages", "ClassRoomId", "dbo.ClassRooms");
            DropIndex("dbo.DamageStatus", new[] { "ClassRoomDamageId" });
            DropIndex("dbo.Repairs", new[] { "ClassRoomDamageId" });
            DropIndex("dbo.Damages", new[] { "ClassRoomDamageTypeId" });
            DropIndex("dbo.Damages", new[] { "ClassRoomId" });
            DropColumn("dbo.DamageStatus", "ClassRoomDamageId");
            DropColumn("dbo.Repairs", "ClassRoomDamageId");
            DropColumn("dbo.Damages", "ClassRoomDamageTypeId");
            DropColumn("dbo.Damages", "ClassRoomId");
        }
    }
}
