namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPoliceReportExpiryDateColumnToDriverTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Driver", "PoliceReportExpiryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Helper", "HelperFirstName", c => c.String());
            AddColumn("dbo.Helper", "HelperLastName", c => c.String());
            DropColumn("dbo.Helper", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Helper", "Name", c => c.String());
            DropColumn("dbo.Helper", "HelperLastName");
            DropColumn("dbo.Helper", "HelperFirstName");
            DropColumn("dbo.Driver", "PoliceReportExpiryDate");
        }
    }
}
