namespace DataAccess_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UpdatedRequests", "Status", c => c.String());
            DropColumn("dbo.ApprovedRequests", "TrainingStatus");
            DropColumn("dbo.UpdatedRequests", "ApprovalStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UpdatedRequests", "ApprovalStatus", c => c.String());
            AddColumn("dbo.ApprovedRequests", "TrainingStatus", c => c.String());
            DropColumn("dbo.UpdatedRequests", "Status");
        }
    }
}
