namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFirstNameColumnAsNameInHelperTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Helper", "Name", c => c.String());
            DropColumn("dbo.Helper", "HelperFirstName");
            DropColumn("dbo.Helper", "HelperLastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Helper", "HelperLastName", c => c.String());
            AddColumn("dbo.Helper", "HelperFirstName", c => c.String());
            DropColumn("dbo.Helper", "Name");
        }
    }
}
