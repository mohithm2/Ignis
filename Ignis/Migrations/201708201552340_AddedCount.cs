namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Counts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Sanctioned = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Alloted = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RankId = c.Guid(nullable: false),
                        FireStationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FireStations", t => t.FireStationId, cascadeDelete: true)
                .ForeignKey("dbo.Ranks", t => t.RankId, cascadeDelete: true)
                .Index(t => t.RankId)
                .Index(t => t.FireStationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Counts", "RankId", "dbo.Ranks");
            DropForeignKey("dbo.Counts", "FireStationId", "dbo.FireStations");
            DropIndex("dbo.Counts", new[] { "FireStationId" });
            DropIndex("dbo.Counts", new[] { "RankId" });
            DropTable("dbo.Counts");
        }
    }
}
