namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOfficeDamage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Damages", "OfficeId", c => c.Guid());
            AddColumn("dbo.Damages", "OfficeDamageTypeId", c => c.Guid());
            AddColumn("dbo.DamageStatus", "OfficeDamageId", c => c.Guid());
            AddColumn("dbo.Repairs", "OfficeDamageId", c => c.Guid());
            CreateIndex("dbo.Damages", "OfficeId");
            CreateIndex("dbo.Damages", "OfficeDamageTypeId");
            CreateIndex("dbo.DamageStatus", "OfficeDamageId");
            CreateIndex("dbo.Repairs", "OfficeDamageId");
            AddForeignKey("dbo.Damages", "OfficeId", "dbo.Offices", "Id", cascadeDelete: false);
            AddForeignKey("dbo.DamageStatus", "OfficeDamageId", "dbo.Damages", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Damages", "OfficeDamageTypeId", "dbo.DamageTypes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Repairs", "OfficeDamageId", "dbo.Damages", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Repairs", "OfficeDamageId", "dbo.Damages");
            DropForeignKey("dbo.Damages", "OfficeDamageTypeId", "dbo.DamageTypes");
            DropForeignKey("dbo.DamageStatus", "OfficeDamageId", "dbo.Damages");
            DropForeignKey("dbo.Damages", "OfficeId", "dbo.Offices");
            DropIndex("dbo.Repairs", new[] { "OfficeDamageId" });
            DropIndex("dbo.DamageStatus", new[] { "OfficeDamageId" });
            DropIndex("dbo.Damages", new[] { "OfficeDamageTypeId" });
            DropIndex("dbo.Damages", new[] { "OfficeId" });
            DropColumn("dbo.Repairs", "OfficeDamageId");
            DropColumn("dbo.DamageStatus", "OfficeDamageId");
            DropColumn("dbo.Damages", "OfficeDamageTypeId");
            DropColumn("dbo.Damages", "OfficeId");
        }
    }
}
