namespace DataAccess_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewRequests", "Status", c => c.String(defaultValue :"Created"));
            DropColumn("dbo.UpdatedRequests", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UpdatedRequests", "Status", c => c.String());
            DropColumn("dbo.NewRequests", "Status");
        }
    }
}
