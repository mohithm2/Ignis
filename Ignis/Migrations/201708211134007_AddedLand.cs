namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLand : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lands",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Address = c.String(nullable: false),
                        Area = c.Double(nullable: false),
                        DateOfPurchase = c.DateTime(nullable: false),
                        Cost = c.Double(nullable: false),
                        GovernmentSactionNumber = c.String(nullable: false),
                        IsEncroached = c.Boolean(nullable: false),
                        FireStationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FireStations", t => t.FireStationId, cascadeDelete: true)
                .Index(t => t.FireStationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lands", "FireStationId", "dbo.FireStations");
            DropIndex("dbo.Lands", new[] { "FireStationId" });
            DropTable("dbo.Lands");
        }
    }
}
