namespace DataAccess_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApprovedRequests", "Executive_Id", c => c.Int());
            CreateIndex("dbo.ApprovedRequests", "Executive_Id");
            AddForeignKey("dbo.ApprovedRequests", "Executive_Id", "dbo.UserInfoes", "Id");
            DropColumn("dbo.ApprovedRequests", "Executive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApprovedRequests", "Executive", c => c.String());
            DropForeignKey("dbo.ApprovedRequests", "Executive_Id", "dbo.UserInfoes");
            DropIndex("dbo.ApprovedRequests", new[] { "Executive_Id" });
            DropColumn("dbo.ApprovedRequests", "Executive_Id");
        }
    }
}
