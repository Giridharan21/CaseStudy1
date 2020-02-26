namespace DataAccess_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewRequests", "PMId_Id", c => c.Int());
            CreateIndex("dbo.NewRequests", "PMId_Id");
            AddForeignKey("dbo.NewRequests", "PMId_Id", "dbo.UserInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewRequests", "PMId_Id", "dbo.UserInfoes");
            DropIndex("dbo.NewRequests", new[] { "PMId_Id" });
            DropColumn("dbo.NewRequests", "PMId_Id");
        }
    }
}
