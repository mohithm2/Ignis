namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFireStation2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.FireStations", new[] { "Id" });
            CreateIndex("dbo.Hoblis", "Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Hoblis", new[] { "Id" });
            CreateIndex("dbo.FireStations", "Id");
        }
    }
}
