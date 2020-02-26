namespace DataAccess_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PMForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NewRequests", "PMId_Id", "dbo.UserInfoes");
            DropIndex("dbo.NewRequests", new[] { "PMId_Id" });
            RenameColumn(table: "dbo.NewRequests", name: "PMId_Id", newName: "ProjManID");
            AlterColumn("dbo.NewRequests", "ProjManID", c => c.Int(nullable: false));
            CreateIndex("dbo.NewRequests", "ProjManID");
            AddForeignKey("dbo.NewRequests", "ProjManID", "dbo.UserInfoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewRequests", "ProjManID", "dbo.UserInfoes");
            DropIndex("dbo.NewRequests", new[] { "ProjManID" });
            AlterColumn("dbo.NewRequests", "ProjManID", c => c.Int());
            RenameColumn(table: "dbo.NewRequests", name: "ProjManID", newName: "PMId_Id");
            CreateIndex("dbo.NewRequests", "PMId_Id");
            AddForeignKey("dbo.NewRequests", "PMId_Id", "dbo.UserInfoes", "Id");
        }
    }
}
