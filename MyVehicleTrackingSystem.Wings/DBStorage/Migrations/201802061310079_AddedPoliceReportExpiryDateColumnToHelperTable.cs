namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPoliceReportExpiryDateColumnToHelperTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Helper", "PoliceReportExpiryDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Helper", "PoliceReportExpiryDate");
        }
    }
}
