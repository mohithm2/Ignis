namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHouse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        NumberOfBedrooms = c.Int(nullable: false),
                        OccupantDesignation = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        ResidentialQuarterId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ResidentialQuarters", t => t.ResidentialQuarterId, cascadeDelete: true)
                .Index(t => t.ResidentialQuarterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Houses", "ResidentialQuarterId", "dbo.ResidentialQuarters");
            DropIndex("dbo.Houses", new[] { "ResidentialQuarterId" });
            DropTable("dbo.Houses");
        }
    }
}
