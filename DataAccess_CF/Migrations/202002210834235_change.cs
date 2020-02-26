namespace DataAccess_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "Job", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoes", "Job");
        }
    }
}
