namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.OilTypes", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OilTypes", "Name", c => c.String());
            AlterColumn("dbo.Employees", "Address", c => c.String());
        }
    }
}
