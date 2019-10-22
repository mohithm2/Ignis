namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMissingProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BatteryChanges", "DateOfChange", c => c.DateTime(nullable: false));
            AddColumn("dbo.TyreChanges", "DateOfChange", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TyreChanges", "DateOfChange");
            DropColumn("dbo.BatteryChanges", "DateOfChange");
        }
    }
}
