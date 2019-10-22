namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedZoneRange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ranges",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ZoneRanges",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ZoneId = c.Guid(nullable: false),
                        RangeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ranges", t => t.RangeId, cascadeDelete: true)
                .ForeignKey("dbo.Zones", t => t.ZoneId, cascadeDelete: true)
                .Index(t => t.ZoneId)
                .Index(t => t.RangeId);
            
            CreateTable(
                "dbo.Zones",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZoneRanges", "ZoneId", "dbo.Zones");
            DropForeignKey("dbo.ZoneRanges", "RangeId", "dbo.Ranges");
            DropIndex("dbo.ZoneRanges", new[] { "RangeId" });
            DropIndex("dbo.ZoneRanges", new[] { "ZoneId" });
            DropTable("dbo.Zones");
            DropTable("dbo.ZoneRanges");
            DropTable("dbo.Ranges");
        }
    }
}
