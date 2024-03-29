namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOilChanges11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OilTypes",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.OilTypes");

        }
    }
}
