namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedWorksFors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorksFors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        End = c.DateTime(),
                        NoOfYears = c.Decimal(precision: 18, scale: 2),
                        EmployeeId = c.Guid(nullable: false),
                        FireStationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.FireStations", t => t.FireStationId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.FireStationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorksFors", "FireStationId", "dbo.FireStations");
            DropForeignKey("dbo.WorksFors", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.WorksFors", new[] { "FireStationId" });
            DropIndex("dbo.WorksFors", new[] { "EmployeeId" });
            DropTable("dbo.WorksFors");
        }
    }
}
