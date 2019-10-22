namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDistrict : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RangeDistricts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RangeId = c.Guid(nullable: false),
                        DistrictId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.Ranges", t => t.RangeId, cascadeDelete: true)
                .Index(t => t.RangeId)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RangeDistricts", "RangeId", "dbo.Ranges");
            DropForeignKey("dbo.RangeDistricts", "DistrictId", "dbo.Districts");
            DropIndex("dbo.RangeDistricts", new[] { "DistrictId" });
            DropIndex("dbo.RangeDistricts", new[] { "RangeId" });
            DropTable("dbo.Districts");
            DropTable("dbo.RangeDistricts");
        }
    }
}
