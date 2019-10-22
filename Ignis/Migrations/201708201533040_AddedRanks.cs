namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRanks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ranks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RankName = c.String(nullable: false),
                        GroupId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ranks", "GroupId", "dbo.Groups");
            DropIndex("dbo.Ranks", new[] { "GroupId" });
            DropTable("dbo.Ranks");
        }
    }
}
