namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVehicleReapir : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleRepairs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BillTIN = c.String(nullable: false),
                        Cost = c.Double(nullable: false),
                        AgencyName = c.String(nullable: false),
                        AgencyContact = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleDamages", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleRepairs", "Id", "dbo.VehicleDamages");
            DropIndex("dbo.VehicleRepairs", new[] { "Id" });
            DropTable("dbo.VehicleRepairs");
        }
    }
}
