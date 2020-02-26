namespace DataAccess_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApprovedRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Executive = c.String(),
                        TrainingStatus = c.String(),
                        TrainingRequest_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UpdatedRequests", t => t.TrainingRequest_Id)
                .Index(t => t.TrainingRequest_Id);
            
            CreateTable(
                "dbo.UpdatedRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Trainer = c.String(),
                        ApprovalStatus = c.String(),
                        Request_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewRequests", t => t.Request_Id)
                .Index(t => t.Request_Id);
            
            CreateTable(
                "dbo.NewRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Skill = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Pass = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApprovedRequests", "TrainingRequest_Id", "dbo.UpdatedRequests");
            DropForeignKey("dbo.UpdatedRequests", "Request_Id", "dbo.NewRequests");
            DropIndex("dbo.ApprovedRequests", new[] { "TrainingRequest_Id" });
            DropIndex("dbo.UpdatedRequests", new[] { "Request_Id" });
            DropTable("dbo.UserInfoes");
            DropTable("dbo.NewRequests");
            DropTable("dbo.UpdatedRequests");
            DropTable("dbo.ApprovedRequests");
        }
    }
}
