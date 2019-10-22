namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFireStation3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Hoblis", new[] { "Id" });
            AlterColumn("dbo.FireStations", "HobliId", c => c.Guid());
            CreateIndex("dbo.FireStations", "Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FireStations", new[] { "Id" });
            AlterColumn("dbo.FireStations", "HobliId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Hoblis", "Id");
        }
    }
}
