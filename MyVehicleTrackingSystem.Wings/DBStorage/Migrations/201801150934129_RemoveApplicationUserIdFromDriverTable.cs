namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveApplicationUserIdFromDriverTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Driver", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Driver", "ApplicationUserId", c => c.String());
        }
    }
}
