namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Kgidno = c.String(nullable: false, maxLength: 25),
                        HK = c.Boolean(nullable: false),
                        SpouseCadre = c.Boolean(nullable: false),
                        Gender = c.String(nullable: false, maxLength: 6),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateOfJoining = c.DateTime(nullable: false),
                        Address = c.String(),
                        PhoneNumber = c.String(maxLength: 10),
                        Seniority = c.Int(nullable: false),
                        TalukId = c.Int(nullable: false),
                        RankId = c.Int(nullable: false),
                        Rank_Id = c.Guid(),
                        Taluk_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ranks", t => t.Rank_Id)
                .ForeignKey("dbo.Taluks", t => t.Taluk_Id)
                .Index(t => t.Rank_Id)
                .Index(t => t.Taluk_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Taluk_Id", "dbo.Taluks");
            DropForeignKey("dbo.Employees", "Rank_Id", "dbo.Ranks");
            DropIndex("dbo.Employees", new[] { "Taluk_Id" });
            DropIndex("dbo.Employees", new[] { "Rank_Id" });
            DropTable("dbo.Employees");
        }
    }
}
