namespace Ignis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmployee1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Rank_Id", "dbo.Ranks");
            DropForeignKey("dbo.Employees", "Taluk_Id", "dbo.Taluks");
            DropIndex("dbo.Employees", new[] { "Rank_Id" });
            DropIndex("dbo.Employees", new[] { "Taluk_Id" });
            DropColumn("dbo.Employees", "RankId");
            DropColumn("dbo.Employees", "TalukId");
            RenameColumn(table: "dbo.Employees", name: "Rank_Id", newName: "RankId");
            RenameColumn(table: "dbo.Employees", name: "Taluk_Id", newName: "TalukId");
            AlterColumn("dbo.Employees", "TalukId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Employees", "RankId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Employees", "RankId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Employees", "TalukId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Employees", "TalukId");
            CreateIndex("dbo.Employees", "RankId");
            AddForeignKey("dbo.Employees", "RankId", "dbo.Ranks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "TalukId", "dbo.Taluks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "TalukId", "dbo.Taluks");
            DropForeignKey("dbo.Employees", "RankId", "dbo.Ranks");
            DropIndex("dbo.Employees", new[] { "RankId" });
            DropIndex("dbo.Employees", new[] { "TalukId" });
            AlterColumn("dbo.Employees", "TalukId", c => c.Guid());
            AlterColumn("dbo.Employees", "RankId", c => c.Guid());
            AlterColumn("dbo.Employees", "RankId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "TalukId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Employees", name: "TalukId", newName: "Taluk_Id");
            RenameColumn(table: "dbo.Employees", name: "RankId", newName: "Rank_Id");
            AddColumn("dbo.Employees", "TalukId", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "RankId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "Taluk_Id");
            CreateIndex("dbo.Employees", "Rank_Id");
            AddForeignKey("dbo.Employees", "Taluk_Id", "dbo.Taluks", "Id");
            AddForeignKey("dbo.Employees", "Rank_Id", "dbo.Ranks", "Id");
        }
    }
}
