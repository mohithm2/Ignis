namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFireStation4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FireStations", "HobliId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FireStations", "HobliId", c => c.Guid());
        }
    }
}
