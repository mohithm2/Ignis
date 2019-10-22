namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTelephoneRoomDamage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Damages", "TelephoneRoomId", c => c.Guid());
            AddColumn("dbo.Damages", "TelephoneRoomDamageTypeId", c => c.Guid());
            AddColumn("dbo.DamageStatus", "TelephoneRoomDamageId", c => c.Guid());
            AddColumn("dbo.Repairs", "TelephoneRoomDamageId", c => c.Guid());
            CreateIndex("dbo.Damages", "TelephoneRoomId");
            CreateIndex("dbo.Damages", "TelephoneRoomDamageTypeId");
            CreateIndex("dbo.DamageStatus", "TelephoneRoomDamageId");
            CreateIndex("dbo.Repairs", "TelephoneRoomDamageId");
            AddForeignKey("dbo.Damages", "TelephoneRoomId", "dbo.TelephoneRooms", "Id", cascadeDelete: false);
            AddForeignKey("dbo.DamageStatus", "TelephoneRoomDamageId", "dbo.Damages", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Damages", "TelephoneRoomDamageTypeId", "dbo.DamageTypes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Repairs", "TelephoneRoomDamageId", "dbo.Damages", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Repairs", "TelephoneRoomDamageId", "dbo.Damages");
            DropForeignKey("dbo.Damages", "TelephoneRoomDamageTypeId", "dbo.DamageTypes");
            DropForeignKey("dbo.DamageStatus", "TelephoneRoomDamageId", "dbo.Damages");
            DropForeignKey("dbo.Damages", "TelephoneRoomId", "dbo.TelephoneRooms");
            DropIndex("dbo.Repairs", new[] { "TelephoneRoomDamageId" });
            DropIndex("dbo.DamageStatus", new[] { "TelephoneRoomDamageId" });
            DropIndex("dbo.Damages", new[] { "TelephoneRoomDamageTypeId" });
            DropIndex("dbo.Damages", new[] { "TelephoneRoomId" });
            DropColumn("dbo.Repairs", "TelephoneRoomDamageId");
            DropColumn("dbo.DamageStatus", "TelephoneRoomDamageId");
            DropColumn("dbo.Damages", "TelephoneRoomDamageTypeId");
            DropColumn("dbo.Damages", "TelephoneRoomId");
        }
    }
}
