namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFireStation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FireStations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        NumberOfBays = c.Int(nullable: false),
                        SanctionNumber = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        PhoneNumber = c.Long(nullable: false),
                        LandArea = c.Double(nullable: false),
                        DateOfEstablishment = c.DateTime(nullable: false),
                        CostOfEstablishment = c.Double(nullable: false),
                        SanctionedStrength = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        HobliId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hoblis", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FireStations", "Id", "dbo.Hoblis");
            DropIndex("dbo.FireStations", new[] { "Id" });
            DropTable("dbo.FireStations");
        }
    }
}
