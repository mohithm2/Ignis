namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInsuranceRenewals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InsuranceRenewals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateOfPayment = c.DateTime(nullable: false),
                        AmountPaid = c.Double(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        VehicleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InsuranceRenewals", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.InsuranceRenewals", new[] { "VehicleId" });
            DropTable("dbo.InsuranceRenewals");
        }
    }
}
