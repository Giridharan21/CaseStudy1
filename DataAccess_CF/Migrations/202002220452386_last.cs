namespace DataAccess_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class last : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApprovedRequests", "Executive_Id", "dbo.UserInfoes");
            DropForeignKey("dbo.ApprovedRequests", "TrainingRequest_Id", "dbo.UpdatedRequests");
            DropIndex("dbo.ApprovedRequests", new[] { "Executive_Id" });
            DropIndex("dbo.ApprovedRequests", new[] { "TrainingRequest_Id" });
            CreateTable(
                "dbo.TrainerInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Skill = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UpdatedRequests", "Executive_Id", c => c.Int());
            AddColumn("dbo.UpdatedRequests", "Trainer_Id", c => c.Int());
            CreateIndex("dbo.UpdatedRequests", "Executive_Id");
            CreateIndex("dbo.UpdatedRequests", "Trainer_Id");
            AddForeignKey("dbo.UpdatedRequests", "Executive_Id", "dbo.UserInfoes", "Id");
            AddForeignKey("dbo.UpdatedRequests", "Trainer_Id", "dbo.TrainerInfoes", "Id");
            DropColumn("dbo.UpdatedRequests", "Trainer");
            DropTable("dbo.ApprovedRequests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApprovedRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Executive_Id = c.Int(),
                        TrainingRequest_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UpdatedRequests", "Trainer", c => c.String());
            DropForeignKey("dbo.UpdatedRequests", "Trainer_Id", "dbo.TrainerInfoes");
            DropForeignKey("dbo.UpdatedRequests", "Executive_Id", "dbo.UserInfoes");
            DropIndex("dbo.UpdatedRequests", new[] { "Trainer_Id" });
            DropIndex("dbo.UpdatedRequests", new[] { "Executive_Id" });
            DropColumn("dbo.UpdatedRequests", "Trainer_Id");
            DropColumn("dbo.UpdatedRequests", "Executive_Id");
            DropTable("dbo.TrainerInfoes");
            CreateIndex("dbo.ApprovedRequests", "TrainingRequest_Id");
            CreateIndex("dbo.ApprovedRequests", "Executive_Id");
            AddForeignKey("dbo.ApprovedRequests", "TrainingRequest_Id", "dbo.UpdatedRequests", "Id");
            AddForeignKey("dbo.ApprovedRequests", "Executive_Id", "dbo.UserInfoes", "Id");
        }
    }
}
