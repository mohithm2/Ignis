namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTaluk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Taluks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        DistrictId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Taluks", "DistrictId", "dbo.Districts");
            DropIndex("dbo.Taluks", new[] { "DistrictId" });
            DropTable("dbo.Taluks");
        }
    }
}
