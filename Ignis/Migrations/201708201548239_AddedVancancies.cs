namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVancancies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vacancies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Vacant = c.Decimal(nullable: false, precision: 18, scale: 2),
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
            DropForeignKey("dbo.Vacancies", "RankId", "dbo.Ranks");
            DropForeignKey("dbo.Vacancies", "FireStationId", "dbo.FireStations");
            DropIndex("dbo.Vacancies", new[] { "FireStationId" });
            DropIndex("dbo.Vacancies", new[] { "RankId" });
            DropTable("dbo.Vacancies");
        }
    }
}
