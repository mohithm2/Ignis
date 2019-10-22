namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Repairs", "VehicleDamage_Id", "dbo.Damages");
            RenameColumn(table: "dbo.Repairs", name: "VehicleDamage_Id", newName: "VehicleDamageId");
            RenameIndex(table: "dbo.Repairs", name: "IX_VehicleDamage_Id", newName: "IX_VehicleDamageId");
            AddForeignKey("dbo.Repairs", "VehicleDamageId", "dbo.Damages", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Repairs", "VehicleDamageId", "dbo.Damages");
            RenameIndex(table: "dbo.Repairs", name: "IX_VehicleDamageId", newName: "IX_VehicleDamage_Id");
            RenameColumn(table: "dbo.Repairs", name: "VehicleDamageId", newName: "VehicleDamage_Id");
            AddForeignKey("dbo.Repairs", "VehicleDamage_Id", "dbo.Damages", "Id");
        }
    }
}
