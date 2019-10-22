namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredLand : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RequiredLands",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Address = c.String(nullable: false),
                        Reason = c.String(nullable: false),
                        PotentialCost = c.Double(nullable: false),
                        AreaRequired = c.Double(nullable: false),
                        FireStationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FireStations", t => t.FireStationId, cascadeDelete: true)
                .Index(t => t.FireStationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequiredLands", "FireStationId", "dbo.FireStations");
            DropIndex("dbo.RequiredLands", new[] { "FireStationId" });
            DropTable("dbo.RequiredLands");
        }
    }
}
