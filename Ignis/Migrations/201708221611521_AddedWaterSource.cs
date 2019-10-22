namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedWaterSource : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WaterSources",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        IsOwned = c.Boolean(nullable: false),
                        Capacity = c.Double(nullable: false),
                        FireStationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FireStations", t => t.FireStationId, cascadeDelete: true)
                .Index(t => t.FireStationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WaterSources", "FireStationId", "dbo.FireStations");
            DropIndex("dbo.WaterSources", new[] { "FireStationId" });
            DropTable("dbo.WaterSources");
        }
    }
}
