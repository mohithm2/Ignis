namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTaxPayment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaxPayments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
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
            DropForeignKey("dbo.TaxPayments", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.TaxPayments", new[] { "VehicleId" });
            DropTable("dbo.TaxPayments");
        }
    }
}
