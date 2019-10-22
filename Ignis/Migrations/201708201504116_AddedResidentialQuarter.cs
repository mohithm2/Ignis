namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedResidentialQuarter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResidentialQuarters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        FireStationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FireStations", t => t.FireStationId, cascadeDelete: true)
                .Index(t => t.FireStationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResidentialQuarters", "FireStationId", "dbo.FireStations");
            DropIndex("dbo.ResidentialQuarters", new[] { "FireStationId" });
            DropTable("dbo.ResidentialQuarters");
        }
    }
}
