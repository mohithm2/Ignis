namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHobli : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hoblis",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        TalukId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Taluks", t => t.TalukId, cascadeDelete: true)
                .Index(t => t.TalukId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hoblis", "TalukId", "dbo.Taluks");
            DropIndex("dbo.Hoblis", new[] { "TalukId" });
            DropTable("dbo.Hoblis");
        }
    }
}
