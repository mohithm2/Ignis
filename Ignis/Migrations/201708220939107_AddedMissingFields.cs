namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMissingFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Damages", "QuantityDamaged", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Damages", "QuantityDamaged");
        }
    }
}
