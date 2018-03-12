namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFirstNameColumnAsNameInDriverTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Driver", "Name", c => c.String());
            DropColumn("dbo.Driver", "FirstName");
            DropColumn("dbo.Driver", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Driver", "LastName", c => c.String());
            AddColumn("dbo.Driver", "FirstName", c => c.String());
            DropColumn("dbo.Driver", "Name");
        }
    }
}
