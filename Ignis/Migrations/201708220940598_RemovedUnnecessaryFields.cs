namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedUnnecessaryFields : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Damages", "QuantityDamaged");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Damages", "QuantityDamaged", c => c.Int());
        }
    }
}
