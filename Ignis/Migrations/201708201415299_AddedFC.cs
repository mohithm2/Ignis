namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FittnessCertificates",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        Comment = c.String(nullable: false),
                        VehicleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FittnessCertificates", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.FittnessCertificates", new[] { "VehicleId" });
            DropTable("dbo.FittnessCertificates");
        }
    }
}
