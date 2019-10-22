namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCaseId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleDamageStatus", "CaseId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VehicleDamageStatus", "CaseId");
        }
    }
}
