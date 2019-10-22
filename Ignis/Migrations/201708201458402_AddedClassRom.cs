namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClassRom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassRooms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                        FireStationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FireStations", t => t.FireStationId, cascadeDelete: true)
                .Index(t => t.FireStationId);
            
            AlterColumn("dbo.BreakRooms", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Offices", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassRooms", "FireStationId", "dbo.FireStations");
            DropIndex("dbo.ClassRooms", new[] { "FireStationId" });
            AlterColumn("dbo.Offices", "Name", c => c.String());
            AlterColumn("dbo.BreakRooms", "Name", c => c.String());
            DropTable("dbo.ClassRooms");
        }
    }
}
