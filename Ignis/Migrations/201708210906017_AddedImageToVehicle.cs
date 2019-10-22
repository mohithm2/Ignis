namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageToVehicle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "PhotoNorth", c => c.String());
            AddColumn("dbo.Vehicles", "PhotoEast", c => c.String());
            AddColumn("dbo.Vehicles", "PhotoWest", c => c.String());
            AddColumn("dbo.Vehicles", "PhotoSouth", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "PhotoSouth");
            DropColumn("dbo.Vehicles", "PhotoWest");
            DropColumn("dbo.Vehicles", "PhotoEast");
            DropColumn("dbo.Vehicles", "PhotoNorth");
        }
    }
}
