namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeDateTimeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehicleDamageStatus", "DateOfLeaving", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleDamageStatus", "DateOfLeaving", c => c.DateTime(nullable: false));
        }
    }
}
