namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovedProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Damages", "OdometerReading", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Damages", "OdometerReading", c => c.Double(nullable: false));
        }
    }
}
