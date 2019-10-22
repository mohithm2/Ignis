namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVehicleDamageStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleDamageStatus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateOfArrival = c.DateTime(nullable: false),
                        DateOfLeaving = c.DateTime(nullable: false),
                        Comment = c.String(),
                        Action = c.Int(nullable: false),
                        Official = c.Int(nullable: false),
                        VehicleDamageId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleDamages", t => t.VehicleDamageId, cascadeDelete: true)
                .Index(t => t.VehicleDamageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleDamageStatus", "VehicleDamageId", "dbo.VehicleDamages");
            DropIndex("dbo.VehicleDamageStatus", new[] { "VehicleDamageId" });
            DropTable("dbo.VehicleDamageStatus");
        }
    }
}
